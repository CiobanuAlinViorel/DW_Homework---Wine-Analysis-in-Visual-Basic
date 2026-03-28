Imports Microsoft.AnalysisServices.AdomdClient
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing

Public Class Form1

    ' matrix(r,c): row 0 = month captions, col 0 = country names, rest = numeric values as strings
    Dim matrix(0, 0) As String
    Dim noLines, noCols As Integer

    Dim WithEvents btnLoad As New Button
    Dim WithEvents btnExport As New Button
    Dim WithEvents btnClear As New Button
    Dim WithEvents clbCountries As New CheckedListBox
    Dim WithEvents trkMonthFrom As New TrackBar
    Dim WithEvents trkMonthTo As New TrackBar
    Dim lblMonthRange As New Label
    Dim dgvData As New DataGridView
    Dim chartMain As New Chart
    Dim lblStatus As New Label
    Dim pnlToolbar As New Panel
    Dim pnlBottom As New Panel
    Dim splitOuter As New SplitContainer
    Dim splitMain As New SplitContainer

    Dim suppressRedraw As Boolean = False

    ' =========================================================================
    '  FORM LOAD  – controls must be added in correct z-order:
    '  Bottom → status bar, Top → toolbar, Fill → splitOuter (fills the rest)
    ' =========================================================================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "WinesDW - Net Revenue Analysis 2018"
        Me.Size = New Size(1300, 900)
        Me.MinimumSize = New Size(1000, 750)
        Me.BackColor = Color.FromArgb(18, 18, 28)
        Me.Font = New Font("Segoe UI", 9.5F)

        ' ── 1. Status bar (Bottom) ─────────────────────────────────────────────
        pnlBottom.Height = 26
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.BackColor = Color.FromArgb(12, 12, 20)
        Me.Controls.Add(pnlBottom)

        lblStatus.Text = "  Ready - click Load Data to connect."
        lblStatus.ForeColor = Color.FromArgb(130, 195, 130)
        lblStatus.Font = New Font("Segoe UI", 8.5F)
        lblStatus.Dock = DockStyle.Fill
        lblStatus.TextAlign = ContentAlignment.MiddleLeft
        pnlBottom.Controls.Add(lblStatus)

        ' ── 2. Toolbar (Top) ──────────────────────────────────────────────────
        pnlToolbar.Height = 52
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.BackColor = Color.FromArgb(26, 26, 40)
        Me.Controls.Add(pnlToolbar)

        Dim lblTitle As New Label
        lblTitle.Text = "  WinesDW  -  Net Revenue by Country & Month  (2018)"
        lblTitle.ForeColor = Color.FromArgb(220, 175, 120)
        lblTitle.Font = New Font("Segoe UI Semibold", 12.0F)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 15)
        pnlToolbar.Controls.Add(lblTitle)

        StyleButton(btnLoad, "Load Data", Color.FromArgb(70, 155, 95), Color.White)
        btnLoad.Location = New Point(500, 11)
        pnlToolbar.Controls.Add(btnLoad)

        StyleButton(btnExport, "Export CSV", Color.FromArgb(55, 115, 195), Color.White)
        btnExport.Location = New Point(644, 11)
        pnlToolbar.Controls.Add(btnExport)

        StyleButton(btnClear, "Clear", Color.FromArgb(175, 55, 55), Color.White)
        btnClear.Location = New Point(788, 11)
        pnlToolbar.Controls.Add(btnClear)

        ' ── 3. Outer split (Fill) – occupies everything between toolbar and status bar
        splitOuter.Dock = DockStyle.Fill
        splitOuter.Orientation = Orientation.Vertical
        splitOuter.SplitterDistance = 215
        splitOuter.BackColor = Color.FromArgb(18, 18, 28)
        splitOuter.Panel1.BackColor = Color.FromArgb(22, 22, 36)
        splitOuter.Panel2.BackColor = Color.FromArgb(18, 18, 28)
        Me.Controls.Add(splitOuter)

        ' ── 4. Sidebar inside Panel1 ──────────────────────────────────────────
        BuildSidebar(splitOuter.Panel1)

        ' ── 5. Inner split inside Panel2: grid top | chart bottom ─────────────
        splitMain.Dock = DockStyle.Fill
        splitMain.Orientation = Orientation.Horizontal
        splitMain.SplitterDistance = 200
        splitMain.BackColor = Color.FromArgb(18, 18, 28)
        splitMain.Panel1.BackColor = Color.FromArgb(18, 18, 28)
        splitMain.Panel2.BackColor = Color.FromArgb(18, 18, 28)
        splitOuter.Panel2.Controls.Add(splitMain)

        ' ── 6. Grid ───────────────────────────────────────────────────────────
        BuildGrid()
        splitMain.Panel1.Controls.Add(dgvData)

        ' ── 7. Chart ──────────────────────────────────────────────────────────
        BuildChartControl()
        splitMain.Panel2.Controls.Add(chartMain)
    End Sub

    ' =========================================================================
    '  SIDEBAR
    ' =========================================================================
    Private Sub BuildSidebar(panel As Panel)
        panel.Padding = New Padding(8)

        Dim lblCF As New Label
        lblCF.Text = "COUNTRIES"
        lblCF.ForeColor = Color.FromArgb(220, 175, 120)
        lblCF.Font = New Font("Segoe UI Semibold", 8.5F)
        lblCF.AutoSize = True
        lblCF.Location = New Point(8, 8)
        panel.Controls.Add(lblCF)

        Dim btnAll As New Button
        StyleButton(btnAll, "All", Color.FromArgb(50, 80, 50), Color.White)
        btnAll.Width = 70 : btnAll.Height = 24
        btnAll.Location = New Point(8, 28)
        AddHandler btnAll.Click, Sub(s, e)
                                     suppressRedraw = True
                                     For i = 0 To clbCountries.Items.Count - 1
                                         clbCountries.SetItemChecked(i, True)
                                     Next
                                     suppressRedraw = False
                                     RefreshChart()
                                 End Sub
        panel.Controls.Add(btnAll)

        Dim btnNone As New Button
        StyleButton(btnNone, "None", Color.FromArgb(80, 50, 50), Color.White)
        btnNone.Width = 70 : btnNone.Height = 24
        btnNone.Location = New Point(84, 28)
        AddHandler btnNone.Click, Sub(s, e)
                                      suppressRedraw = True
                                      For i = 0 To clbCountries.Items.Count - 1
                                          clbCountries.SetItemChecked(i, False)
                                      Next
                                      suppressRedraw = False
                                      RefreshChart()
                                  End Sub
        panel.Controls.Add(btnNone)

        clbCountries.Location = New Point(8, 58)
        clbCountries.Size = New Size(195, 340)
        clbCountries.BackColor = Color.FromArgb(28, 28, 44)
        clbCountries.ForeColor = Color.FromArgb(210, 210, 230)
        clbCountries.Font = New Font("Segoe UI", 9.0F)
        clbCountries.BorderStyle = BorderStyle.None
        clbCountries.CheckOnClick = True
        panel.Controls.Add(clbCountries)

        Dim lblMH As New Label
        lblMH.Text = "MONTH RANGE"
        lblMH.ForeColor = Color.FromArgb(220, 175, 120)
        lblMH.Font = New Font("Segoe UI Semibold", 8.5F)
        lblMH.AutoSize = True
        lblMH.Location = New Point(8, 408)
        panel.Controls.Add(lblMH)

        lblMonthRange.Text = "From: -   To: -"
        lblMonthRange.ForeColor = Color.Silver
        lblMonthRange.Font = New Font("Segoe UI", 8.5F)
        lblMonthRange.AutoSize = True
        lblMonthRange.Location = New Point(8, 426)
        panel.Controls.Add(lblMonthRange)

        Dim lblFrom As New Label
        lblFrom.Text = "From"
        lblFrom.ForeColor = Color.FromArgb(150, 150, 180)
        lblFrom.Font = New Font("Segoe UI", 8.0F)
        lblFrom.AutoSize = True
        lblFrom.Location = New Point(8, 448)
        panel.Controls.Add(lblFrom)

        trkMonthFrom.Location = New Point(8, 464)
        trkMonthFrom.Width = 195
        trkMonthFrom.Minimum = 1
        trkMonthFrom.Maximum = 12
        trkMonthFrom.Value = 1
        trkMonthFrom.TickFrequency = 1
        trkMonthFrom.SmallChange = 1
        trkMonthFrom.LargeChange = 1
        trkMonthFrom.BackColor = Color.FromArgb(22, 22, 36)
        panel.Controls.Add(trkMonthFrom)

        Dim lblTo As New Label
        lblTo.Text = "To"
        lblTo.ForeColor = Color.FromArgb(150, 150, 180)
        lblTo.Font = New Font("Segoe UI", 8.0F)
        lblTo.AutoSize = True
        lblTo.Location = New Point(8, 510)
        panel.Controls.Add(lblTo)

        trkMonthTo.Location = New Point(8, 526)
        trkMonthTo.Width = 195
        trkMonthTo.Minimum = 1
        trkMonthTo.Maximum = 12
        trkMonthTo.Value = 12
        trkMonthTo.TickFrequency = 1
        trkMonthTo.SmallChange = 1
        trkMonthTo.LargeChange = 1
        trkMonthTo.BackColor = Color.FromArgb(22, 22, 36)
        panel.Controls.Add(trkMonthTo)
    End Sub

    ' =========================================================================
    '  GRID
    ' =========================================================================
    Private Sub BuildGrid()
        dgvData.Dock = DockStyle.Fill
        dgvData.BackgroundColor = Color.FromArgb(22, 22, 36)
        dgvData.GridColor = Color.FromArgb(48, 48, 68)
        dgvData.DefaultCellStyle.BackColor = Color.FromArgb(26, 26, 42)
        dgvData.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 225)
        dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 95, 175)
        dgvData.DefaultCellStyle.SelectionForeColor = Color.White
        dgvData.DefaultCellStyle.Font = New Font("Consolas", 9.0F)

        ' Column headers – gold text on dark bg, tall enough to be clearly visible
        dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 62)
        dgvData.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(240, 200, 100)
        dgvData.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.5F)
        dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvData.ColumnHeadersHeight = 36
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvData.ColumnHeadersVisible = True

        dgvData.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 48)
        dgvData.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(140, 140, 170)
        dgvData.RowHeadersWidth = 36
        dgvData.EnableHeadersVisualStyles = False
        ' AllCellsExceptHeader auto-sizes columns to data; we will also set MinimumWidth per column after load
        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvData.ReadOnly = True
        dgvData.AllowUserToAddRows = False
        dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvData.BorderStyle = BorderStyle.None
        dgvData.ScrollBars = ScrollBars.Both
    End Sub

    ' =========================================================================
    '  CHART CONTROL SETUP  – dark theme, ALL text white
    ' =========================================================================
    Private Sub BuildChartControl()
        chartMain.Dock = DockStyle.Fill
        chartMain.BackColor = Color.FromArgb(18, 18, 28)
        chartMain.BorderlineColor = Color.Transparent

        Dim ca As New ChartArea("main")
        ca.BackColor = Color.FromArgb(24, 24, 38)
        ca.BackSecondaryColor = Color.FromArgb(28, 28, 44)
        ca.BackGradientStyle = GradientStyle.TopBottom
        ca.BorderColor = Color.FromArgb(55, 55, 75)
        ca.BorderWidth = 1

        ' X axis – integer positions (1..12), month name labels set per point
        ca.AxisX.LabelStyle.ForeColor = Color.White
        ca.AxisX.LabelStyle.Font = New Font("Segoe UI Semibold", 9.0F)
        ca.AxisX.LabelStyle.Angle = -30
        ca.AxisX.LineColor = Color.FromArgb(100, 100, 140)
        ca.AxisX.MajorGrid.LineColor = Color.FromArgb(40, 40, 60)
        ca.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ca.AxisX.MajorTickMark.LineColor = Color.FromArgb(100, 100, 140)
        ca.AxisX.Interval = 1
        ca.AxisX.Title = "Month"
        ca.AxisX.TitleFont = New Font("Segoe UI Semibold", 9.5F)
        ca.AxisX.TitleForeColor = Color.White

        ' Y axis
        ca.AxisY.LabelStyle.ForeColor = Color.White
        ca.AxisY.LabelStyle.Font = New Font("Segoe UI", 9.0F)
        ca.AxisY.LineColor = Color.FromArgb(100, 100, 140)
        ca.AxisY.MajorGrid.LineColor = Color.FromArgb(40, 40, 60)
        ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ca.AxisY.LabelStyle.Format = "N0"
        ca.AxisY.Title = "Net Revenue"
        ca.AxisY.TitleFont = New Font("Segoe UI Semibold", 9.5F)
        ca.AxisY.TitleForeColor = Color.White
        ca.AxisY.Minimum = 0

        chartMain.ChartAreas.Add(ca)

        ' Title – white
        Dim t As New Title("Net Revenue by Country & Month (2018)")
        t.Font = New Font("Segoe UI Semibold", 11.0F)
        t.ForeColor = Color.White
        chartMain.Titles.Add(t)

        ' Legend – white text on dark bg
        Dim leg As New Legend
        leg.BackColor = Color.FromArgb(28, 28, 44)
        leg.ForeColor = Color.White
        leg.Font = New Font("Segoe UI", 9.0F)
        leg.BorderColor = Color.FromArgb(55, 55, 75)
        leg.Docking = Docking.Top
        leg.Alignment = StringAlignment.Center
        chartMain.Legends.Add(leg)
    End Sub

    Private Sub StyleButton(btn As Button, caption As String, bg As Color, fg As Color)
        btn.Text = caption
        btn.Width = 132
        btn.Height = 30
        btn.BackColor = bg
        btn.ForeColor = fg
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI Semibold", 9.0F)
        btn.Cursor = Cursors.Hand
    End Sub

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

End Class