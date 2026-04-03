Imports Microsoft.AnalysisServices.AdomdClient
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing

Public Class Form1

    ' matrix(r,c): row 0 = month captions, col 0 = country names, rest = numeric values as strings
    Dim matrix(0, 0) As String
    Dim noLines, noCols As Integer

    Dim suppressRedraw As Boolean = False

    ' =========================================================================
    '  DATA LOADING
    ' =========================================================================
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        lblStatus.Text = "  Connecting..."
        lblStatus.ForeColor = Color.Gold
        Application.DoEvents()
        Try
            Dim conn As New AdomdConnection(
                "Provider=MSOLAP;Data Source=BUMBLEBEE;Catalog=WinesDW;Integrated Security=SSPI;")
            conn.Open()

            'In loc de conexiunea mea ti-o pui pe a ta: Provider=MSOLAP;Data Source=localhost\MSSQLSERVER01;Catalog=ProiectDWh1;Integrated Security=SSPI;, si jos la query conecteaza te la cubul tau
            Dim cmd As New AdomdCommand("
SELECT ORDER(
    Descendants([Dim Date].[Hierarchy].[Year].&[2018],
                [Dim Date].[Hierarchy].[Month]),
    [Dim Date].[Hierarchy].CurrentMember.MemberValue,
    BASC
) ON COLUMNS,
NON EMPTY [Dim Customer].[Hierarchy].[Country Name].MEMBERS ON ROWS
FROM [WinesSales]
WHERE [Measures].[Net Revenue];", conn)
            Dim cstres As CellSet = cmd.ExecuteCellSet()
            conn.Close()

            PopulateMatrix(cstres)
            PopulateGrid()
            InitSidebar()
            RefreshChart()

            lblStatus.Text = $"  Loaded {noLines} countries x {noCols} months.  Last refresh: {DateTime.Now:HH:mm:ss}"
            lblStatus.ForeColor = Color.FromArgb(130, 195, 130)
        Catch ex As Exception
            lblStatus.Text = "  Error: " & ex.Message
            lblStatus.ForeColor = Color.FromArgb(255, 110, 90)
            MessageBox.Show("Connection / query error:" & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateMatrix(cs As CellSet)
        noCols = cs.Axes(0).Positions.Count
        noLines = cs.Axes(1).Positions.Count
        ReDim matrix(noLines, noCols)
        For c = 0 To noCols - 1
            matrix(0, c + 1) = cs.Axes(0).Positions(c).Members(0).Caption
        Next
        For r = 0 To noLines - 1
            matrix(r + 1, 0) = cs.Axes(1).Positions(r).Members(0).Caption
            For c = 0 To noCols - 1
                Dim v As Object = cs.Cells(c, r).Value
                matrix(r + 1, c + 1) = If(v Is Nothing, "0", v.ToString())
            Next
        Next
    End Sub

    Private Sub PopulateGrid()
        dgvData.Columns.Clear()
        dgvData.Rows.Clear()

        ' Country column
        dgvData.Columns.Add("Country", "Country")
        dgvData.Columns(0).DefaultCellStyle.ForeColor = Color.FromArgb(220, 175, 120)
        dgvData.Columns(0).DefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.0F)
        dgvData.Columns(0).Width = 130

        ' Month columns – name comes from matrix row 0
        For c = 1 To noCols
            Dim colIdx As Integer = dgvData.Columns.Add("m" & c, matrix(0, c))
            dgvData.Columns(colIdx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvData.Columns(colIdx).DefaultCellStyle.ForeColor = Color.FromArgb(185, 215, 255)
            dgvData.Columns(colIdx).Width = 85   ' fixed width so all months are visible
        Next

        ' Data rows
        For r = 1 To noLines
            Dim rowData(noCols) As Object
            rowData(0) = matrix(r, 0)
            For c = 1 To noCols
                Dim n As Double = 0
                Double.TryParse(matrix(r, c), n)
                rowData(c) = If(n = 0, "", n.ToString("N0"))
            Next
            dgvData.Rows.Add(rowData)
            If r Mod 2 = 0 Then
                dgvData.Rows(r - 1).DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 48)
            End If
        Next
    End Sub

    Private Sub InitSidebar()
        suppressRedraw = True
        clbCountries.Items.Clear()
        For r = 1 To noLines
            clbCountries.Items.Add(matrix(r, 0), True)
        Next
        trkMonthFrom.Maximum = noCols
        trkMonthFrom.Value = 1
        trkMonthTo.Maximum = noCols
        trkMonthTo.Value = noCols
        suppressRedraw = False
        UpdateMonthRangeLabel()
    End Sub

    ' =========================================================================
    '  CHART REFRESH
    '  Uses integer X values (1, 2, 3...) so the chart treats the axis as
    '  numeric (ordered, evenly spaced). Month name is set as AxisLabel on
    '  each DataPoint so it appears correctly on the X axis.
    ' =========================================================================
    Private Sub RefreshChart()
        If suppressRedraw Then Return
        If noLines = 0 OrElse noCols = 0 Then Return

        chartMain.Series.Clear()

        Dim fromM As Integer = Math.Min(trkMonthFrom.Value, trkMonthTo.Value)
        Dim toM As Integer = Math.Max(trkMonthFrom.Value, trkMonthTo.Value)

        Dim palette() As Color = {
            Color.FromArgb(230, 90, 90),
            Color.FromArgb(80, 165, 230),
            Color.FromArgb(90, 205, 115),
            Color.FromArgb(230, 170, 50),
            Color.FromArgb(185, 85, 185),
            Color.FromArgb(50, 205, 205),
            Color.FromArgb(245, 125, 55),
            Color.FromArgb(155, 205, 75),
            Color.FromArgb(255, 160, 160),
            Color.FromArgb(120, 200, 255),
            Color.FromArgb(170, 255, 170),
            Color.FromArgb(255, 220, 100),
            Color.FromArgb(220, 140, 255),
            Color.FromArgb(100, 255, 230),
            Color.FromArgb(255, 180, 80),
            Color.FromArgb(200, 255, 120)
        }

        Dim si As Integer = 0
        For r = 1 To noLines
            Dim country As String = matrix(r, 0)
            Dim itemIdx As Integer = clbCountries.Items.IndexOf(country)
            If itemIdx >= 0 AndAlso Not clbCountries.GetItemChecked(itemIdx) Then Continue For

            Dim s As New Series(country)
            s.ChartType = SeriesChartType.Line
            s.Color = palette(si Mod palette.Length)
            s.BorderWidth = 2
            s.MarkerStyle = MarkerStyle.Circle
            s.MarkerSize = 7
            s.MarkerColor = palette(si Mod palette.Length)
            s.MarkerBorderColor = palette(si Mod palette.Length)
            s.IsValueShownAsLabel = False

            ' Add points using integer X (1-based position in selected range)
            ' and set the AxisLabel to the month name so it shows on X axis
            Dim xPos As Integer = 1
            For c = fromM To toM
                Dim n As Double = 0
                Double.TryParse(matrix(r, c), n)
                Dim pt As New DataPoint(xPos, n)
                pt.AxisLabel = matrix(0, c)   ' month name shown on X axis
                s.Points.Add(pt)
                xPos += 1
            Next

            chartMain.Series.Add(s)
            si += 1
        Next

        ' Make sure X axis shows every tick
        Dim ca As ChartArea = chartMain.ChartAreas("main")
        ca.AxisX.Minimum = 1
        ca.AxisX.Maximum = (toM - fromM) + 1
        ca.AxisX.Interval = 1
        ca.AxisX.LabelStyle.ForeColor = Color.White
        ca.AxisX.LabelStyle.Font = New Font("Segoe UI Semibold", 9.0F)
        ca.AxisX.LabelStyle.Angle = -30
    End Sub

    ' =========================================================================
    '  EVENT HANDLERS
    ' =========================================================================
    Private Sub clbCountries_ItemCheck(sender As Object, e As ItemCheckEventArgs) _
            Handles clbCountries.ItemCheck
        If suppressRedraw Then Return
        BeginInvoke(Sub() RefreshChart())
    End Sub

    Private Sub btnAllCountries_Click(sender As Object, e As EventArgs) Handles btnAllCountries.Click
        suppressRedraw = True
        For i = 0 To clbCountries.Items.Count - 1
            clbCountries.SetItemChecked(i, True)
        Next
        suppressRedraw = False
        RefreshChart()
    End Sub

    Private Sub btnNoneCountries_Click(sender As Object, e As EventArgs) Handles btnNoneCountries.Click
        suppressRedraw = True
        For i = 0 To clbCountries.Items.Count - 1
            clbCountries.SetItemChecked(i, False)
        Next
        suppressRedraw = False
        RefreshChart()
    End Sub

    Private Sub trkMonthFrom_Scroll(sender As Object, e As EventArgs) Handles trkMonthFrom.Scroll
        If trkMonthFrom.Value > trkMonthTo.Value Then trkMonthTo.Value = trkMonthFrom.Value
        UpdateMonthRangeLabel()
        RefreshChart()
    End Sub

    Private Sub trkMonthTo_Scroll(sender As Object, e As EventArgs) Handles trkMonthTo.Scroll
        If trkMonthTo.Value < trkMonthFrom.Value Then trkMonthFrom.Value = trkMonthTo.Value
        UpdateMonthRangeLabel()
        RefreshChart()
    End Sub

    Private Sub UpdateMonthRangeLabel()
        If noCols = 0 Then
            lblMonthRange.Text = "From: -   To: -"
            Return
        End If
        Dim f As Integer = Math.Min(trkMonthFrom.Value, trkMonthTo.Value)
        Dim t As Integer = Math.Max(trkMonthFrom.Value, trkMonthTo.Value)
        Dim fromName As String = If(f <= noCols, matrix(0, f), "-")
        Dim toName As String = If(t <= noCols, matrix(0, t), "-")
        lblMonthRange.Text = $"From: {fromName}   To: {toName}"
    End Sub

    ' =========================================================================
    '  EXPORT & CLEAR
    ' =========================================================================
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If noLines = 0 OrElse noCols = 0 Then
            MessageBox.Show("No data loaded yet.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim dlg As New SaveFileDialog
        dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        dlg.FileName = "WinesDW_NetRevenue_2018.csv"
        If dlg.ShowDialog() = DialogResult.OK Then
            Try
                Dim sb As New System.Text.StringBuilder
                sb.Append("Country")
                For c = 1 To noCols : sb.Append("," & matrix(0, c)) : Next
                sb.AppendLine()
                For r = 1 To noLines
                    sb.Append(matrix(r, 0))
                    For c = 1 To noCols : sb.Append("," & matrix(r, c)) : Next
                    sb.AppendLine()
                Next
                IO.File.WriteAllText(dlg.FileName, sb.ToString())
                lblStatus.Text = "  Exported: " & dlg.FileName
                lblStatus.ForeColor = Color.FromArgb(130, 195, 130)
            Catch ex As Exception
                MessageBox.Show("Export failed: " & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        dgvData.Columns.Clear()
        dgvData.Rows.Clear()
        chartMain.Series.Clear()
        clbCountries.Items.Clear()
        ReDim matrix(0, 0)
        noLines = 0 : noCols = 0
        trkMonthFrom.Value = 1 : trkMonthTo.Value = 12
        lblMonthRange.Text = "From: -   To: -"
        lblStatus.Text = "  Cleared."
        lblStatus.ForeColor = Color.Silver
    End Sub

    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellContentClick

    End Sub
End Class
