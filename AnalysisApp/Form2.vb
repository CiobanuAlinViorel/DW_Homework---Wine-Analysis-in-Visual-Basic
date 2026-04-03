Imports Microsoft.AnalysisServices.AdomdClient
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing

Public Class Form2

    Dim matrix(0, 0) As String
    Dim noLines, noCols As Integer
    Dim suppressRedraw As Boolean = False

    Private ReadOnly MeasureMap As New Dictionary(Of String, String) From {
        {"Net Revenue", "[Measures].[Net Revenue]"},
        {"Total Amount", "[Measures].[Total Amount]"},
        {"Quantity", "[Measures].[Quantity]"},
        {"Gross Margin", "[Measures].[Gross Margin]"}
    }

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cmbYear.Items.Count = 0 Then
            For y = 2015 To 2024
                cmbYear.Items.Add(y.ToString())
            Next
        End If

        If cmbMeasure.Items.Count = 0 Then
            For Each k In MeasureMap.Keys
                cmbMeasure.Items.Add(k)
            Next
        End If

        If cmbChartType.Items.Count = 0 Then
            cmbChartType.Items.AddRange({"Line", "Bar", "Column"})
        End If

        If cmbYear.SelectedIndex < 0 Then
            cmbYear.SelectedItem = "2018"
        End If

        If cmbMeasure.SelectedIndex < 0 AndAlso cmbMeasure.Items.Count > 0 Then
            cmbMeasure.SelectedIndex = 0
        End If

        If cmbChartType.SelectedIndex < 0 AndAlso cmbChartType.Items.Count > 0 Then
            cmbChartType.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        lblStatus.Text = "  Connecting..."
        lblStatus.ForeColor = Color.Gold
        Application.DoEvents()
        Try
            Dim selectedYear As String = If(cmbYear.SelectedItem IsNot Nothing, cmbYear.SelectedItem.ToString(), "2018")
            Dim selectedMeasureKey As String = If(cmbMeasure.SelectedItem IsNot Nothing, cmbMeasure.SelectedItem.ToString(), "Net Revenue")
            Dim selectedMeasure As String = MeasureMap(selectedMeasureKey)

            Dim conn As New AdomdConnection(
                "Provider=MSOLAP;Data Source=BUMBLEBEE;Catalog=WinesDW;Integrated Security=SSPI;")
            conn.Open()
            'In loc de conexiunea mea ti-o pui pe a ta: Provider=MSOLAP;Data Source=localhost\MSSQLSERVER01;Catalog=ProiectDWh1;Integrated Security=SSPI;, si jos la query conecteaza te la cubul tau

            ' MDX REPARAT: Folosim .Children în loc de Descendants pentru a aduce nivelul imediat următor (luni)
            Dim mdx As String = $"
            SELECT 
                Descendants([Dim Date].[Hierarchy].[Year].&[{selectedYear}], 2, SELF) ON COLUMNS,
                NON EMPTY [Dim Wine].[Subcategory Name].[Subcategory Name].Members ON ROWS 
            FROM [WinesSales]
            WHERE {selectedMeasure};"



            Dim cmd As New AdomdCommand(mdx, conn)
            Dim cstres As CellSet = cmd.ExecuteCellSet()
            conn.Close()

            PopulateMatrix(cstres)
            PopulateGrid()
            InitSidebar()
            RefreshChart()

            chartMain.Titles(0).Text = $"{selectedMeasureKey} by Subcategory & Month ({selectedYear})"
            chartMain.ChartAreas("main").AxisY.Title = selectedMeasureKey

            lblStatus.Text = $"  Loaded {noLines} subcategories x {noCols} months  |  Year: {selectedYear}  |  Measure: {selectedMeasureKey}  |  {DateTime.Now:HH:mm:ss}"
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

        ' Citim coloanele (Lunile) și le formatăm
        For c = 0 To noCols - 1
            Dim rawCaption As String = cs.Axes(0).Positions(c).Members(0).Caption

            ' Dacă textul adus de cub este un număr între 1 și 12, îl transformăm în nume de lună
            Dim monthNum As Integer
            If Integer.TryParse(rawCaption, monthNum) AndAlso monthNum >= 1 AndAlso monthNum <= 12 Then
                rawCaption = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(monthNum)
            End If

            matrix(0, c + 1) = rawCaption
        Next

        ' Citim rândurile (Vinurile) și valorile
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

        dgvData.Columns.Add("Wine Subcategory", "Wine Subcategory")
        dgvData.Columns(0).DefaultCellStyle.ForeColor = Color.FromArgb(220, 175, 120)
        dgvData.Columns(0).DefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.0F)

        ' Dacă vrei ca doar coloana de vinuri să se potrivească pe conținut, iar lunile să se împartă egal
        dgvData.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        For c = 1 To noCols
            Dim colIdx As Integer = dgvData.Columns.Add("m" & c, matrix(0, c))
            dgvData.Columns(colIdx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvData.Columns(colIdx).DefaultCellStyle.ForeColor = Color.FromArgb(185, 215, 255)
        Next

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
        If dgvData.Rows.Count > 0 Then dgvData.FirstDisplayedScrollingRowIndex = 0
    End Sub

    Private Sub InitSidebar()
        suppressRedraw = True
        clbWines.Items.Clear()
        For r = 1 To noLines
            clbWines.Items.Add(matrix(r, 0), True)
        Next
        trkMonthFrom.Maximum = noCols
        trkMonthFrom.Value = 1
        trkMonthTo.Maximum = noCols
        trkMonthTo.Value = noCols
        suppressRedraw = False
        UpdateMonthRangeLabel()
    End Sub

    Private Sub RefreshChart()
        If suppressRedraw Then Return
        If noLines = 0 OrElse noCols = 0 Then Return

        chartMain.Series.Clear()

        Dim fromM As Integer = Math.Min(trkMonthFrom.Value, trkMonthTo.Value)
        Dim toM As Integer = Math.Max(trkMonthFrom.Value, trkMonthTo.Value)

        Dim chartType As SeriesChartType = SeriesChartType.Line
        If cmbChartType.SelectedItem IsNot Nothing Then
            Select Case cmbChartType.SelectedItem.ToString()
                Case "Bar" : chartType = SeriesChartType.Bar
                Case "Column" : chartType = SeriesChartType.Column
                Case Else : chartType = SeriesChartType.Line
            End Select
        End If

        Dim palette() As Color = {
            Color.FromArgb(230, 90, 90), Color.FromArgb(80, 165, 230),
            Color.FromArgb(90, 205, 115), Color.FromArgb(230, 170, 50),
            Color.FromArgb(185, 85, 185), Color.FromArgb(50, 205, 205),
            Color.FromArgb(245, 125, 55), Color.FromArgb(155, 205, 75),
            Color.FromArgb(255, 160, 160), Color.FromArgb(120, 200, 255),
            Color.FromArgb(170, 255, 170), Color.FromArgb(255, 220, 100),
            Color.FromArgb(220, 140, 255), Color.FromArgb(100, 255, 230),
            Color.FromArgb(255, 180, 80), Color.FromArgb(200, 255, 120)
        }

        Dim si As Integer = 0
        Dim grandTotal As Double = 0

        For r = 1 To noLines
            Dim wineName As String = matrix(r, 0)
            Dim itemIdx As Integer = clbWines.Items.IndexOf(wineName)
            If itemIdx >= 0 AndAlso Not clbWines.GetItemChecked(itemIdx) Then Continue For

            Dim s As New Series(wineName)
            s.ChartType = chartType
            s.Color = palette(si Mod palette.Length)
            s.BorderWidth = 2
            If chartType = SeriesChartType.Line Then
                s.MarkerStyle = MarkerStyle.Circle
                s.MarkerSize = 7
                s.MarkerColor = palette(si Mod palette.Length)
            End If
            s.IsValueShownAsLabel = False

            Dim xPos As Integer = 1
            For c = fromM To toM
                Dim n As Double = 0
                Double.TryParse(matrix(r, c), n)
                grandTotal += n
                Dim pt As New DataPoint(xPos, n)
                pt.AxisLabel = matrix(0, c)
                s.Points.Add(pt)
                xPos += 1
            Next

            chartMain.Series.Add(s)
            si += 1
        Next

        lblTotal.Text = grandTotal.ToString("N0")

        Dim ca As ChartArea = chartMain.ChartAreas("main")
        ca.AxisX.Minimum = 1
        ca.AxisX.Maximum = (toM - fromM) + 1
        ca.AxisX.Interval = 1
        ca.AxisX.LabelStyle.ForeColor = Color.White
        ca.AxisX.LabelStyle.Font = New Font("Segoe UI Semibold", 9.0F)
        ca.AxisX.LabelStyle.Angle = -30
    End Sub

    Private Sub clbWines_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbWines.ItemCheck
        If suppressRedraw Then Return
        BeginInvoke(Sub() RefreshChart())
    End Sub

    Private Sub btnAllWines_Click(sender As Object, e As EventArgs) Handles btnAllWines.Click
        suppressRedraw = True
        For i = 0 To clbWines.Items.Count - 1
            clbWines.SetItemChecked(i, True)
        Next
        suppressRedraw = False
        RefreshChart()
    End Sub

    Private Sub btnNoneWines_Click(sender As Object, e As EventArgs) Handles btnNoneWines.Click
        suppressRedraw = True
        For i = 0 To clbWines.Items.Count - 1
            clbWines.SetItemChecked(i, False)
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

    Private Sub cmbChartType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChartType.SelectedIndexChanged
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

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If noLines = 0 OrElse noCols = 0 Then
            MessageBox.Show("No data loaded yet.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim dlg As New SaveFileDialog
        dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        dlg.FileName = "WinesDW_Export.csv"
        If dlg.ShowDialog() = DialogResult.OK Then
            Try
                Dim sb As New System.Text.StringBuilder
                sb.Append("Subcategory")
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
        clbWines.Items.Clear()
        ReDim matrix(0, 0)
        noLines = 0 : noCols = 0
        trkMonthFrom.Value = 1 : trkMonthTo.Value = 12
        lblMonthRange.Text = "From: -   To: -"
        lblTotal.Text = "-"
        lblStatus.Text = "  Cleared."
        lblStatus.ForeColor = Color.Silver
    End Sub

End Class
