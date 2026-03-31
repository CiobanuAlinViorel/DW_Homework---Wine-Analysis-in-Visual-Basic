Imports Microsoft.AnalysisServices.AdomdClient
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing

Public Class Form2

    Dim matrix(0, 0) As String
    Dim noLines, noCols As Integer

    Dim WithEvents btnLoad As New Button
    Dim WithEvents btnExport As New Button
    Dim WithEvents btnClear As New Button
    Dim WithEvents clbWines As New CheckedListBox
    Dim WithEvents trkMonthFrom As New TrackBar
    Dim WithEvents trkMonthTo As New TrackBar
    Dim cmbYear As New ComboBox
    Dim cmbMeasure As New ComboBox
    Dim WithEvents cmbChartType As New ComboBox
    Dim lblMonthRange As New Label
    Dim lblTotal As New Label
    Dim dgvData As New DataGridView
    Dim chartMain As New Chart
    Dim lblStatus As New Label
    Dim pnlToolbar As New Panel
    Dim pnlBottom As New Panel
    Dim splitOuter As New SplitContainer
    Dim splitMain As New SplitContainer
    Dim suppressRedraw As Boolean = False

    Private ReadOnly MeasureMap As New Dictionary(Of String, String) From {
        {"Net Revenue", "[Measures].[Net Revenue]"},
        {"Total Amount", "[Measures].[Total Amount]"},
        {"Quantity", "[Measures].[Quantity]"},
        {"Gross Margin", "[Measures].[Gross Margin]"}
    }

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "WinesDW - Wine Analysis"
        Me.Size = New Size(1400, 950)
        Me.MinimumSize = New Size(1100, 800)
        Me.BackColor = Color.FromArgb(18, 18, 28)
        Me.Font = New Font("Segoe UI", 9.5F)

        ' Status bar
        pnlBottom.Height = 26
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.BackColor = Color.FromArgb(12, 12, 20)
        Me.Controls.Add(pnlBottom)

        lblStatus.Text = "  Ready - configure options and click Load Data."
        lblStatus.ForeColor = Color.FromArgb(130, 195, 130)
        lblStatus.Font = New Font("Segoe UI", 8.5F)
        lblStatus.Dock = DockStyle.Fill
        lblStatus.TextAlign = ContentAlignment.MiddleLeft
        pnlBottom.Controls.Add(lblStatus)

        ' Toolbar
        pnlToolbar.Height = 60
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.BackColor = Color.FromArgb(26, 26, 40)
        Me.Controls.Add(pnlToolbar)

        ' --- STILIZARE TITLU ---
        Dim lblBrand As New Label
        lblBrand.Text = "WinesDW"
        lblBrand.ForeColor = Color.White
        lblBrand.Font = New Font("Segoe UI Black", 14.0F, FontStyle.Bold)
        lblBrand.AutoSize = True
        lblBrand.Location = New Point(15, 15)
        lblBrand.BackColor = Color.Transparent
        pnlToolbar.Controls.Add(lblBrand)

        Dim pnlSeparator As New Panel
        pnlSeparator.BackColor = Color.FromArgb(80, 80, 100)
        pnlSeparator.Size = New Size(1, 22)
        pnlSeparator.Location = New Point(140, 19) ' Mutat la dreapta pt a nu tăia textul
        pnlToolbar.Controls.Add(pnlSeparator)

        Dim lblSub As New Label
        lblSub.Text = "WINE ANALYSIS"
        lblSub.ForeColor = Color.FromArgb(220, 175, 120)
        lblSub.Font = New Font("Segoe UI Semibold", 9.5F)
        lblSub.AutoSize = True
        lblSub.Location = New Point(155, 20) ' Mutat la dreapta
        lblSub.BackColor = Color.Transparent
        pnlToolbar.Controls.Add(lblSub)

        ' --- FILTRE ȘI BUTOANE ---
        ' Year dropdown
        Dim lblYear As New Label
        lblYear.Text = "Year:"
        lblYear.ForeColor = Color.Silver
        lblYear.AutoSize = True
        lblYear.Location = New Point(320, 20)
        lblYear.BackColor = Color.Transparent
        pnlToolbar.Controls.Add(lblYear)

        cmbYear.Location = New Point(365, 17) ' Lăsat 45px distanță
        cmbYear.Width = 80
        cmbYear.DropDownStyle = ComboBoxStyle.DropDownList
        cmbYear.BackColor = Color.FromArgb(38, 38, 62)
        cmbYear.ForeColor = Color.White
        For y = 2015 To 2024
            cmbYear.Items.Add(y.ToString())
        Next
        cmbYear.SelectedItem = "2018"
        pnlToolbar.Controls.Add(cmbYear)

        ' Measure dropdown
        Dim lblMeasure As New Label
        lblMeasure.Text = "Measure:"
        lblMeasure.ForeColor = Color.Silver
        lblMeasure.AutoSize = True
        lblMeasure.Location = New Point(465, 20)
        lblMeasure.BackColor = Color.Transparent
        pnlToolbar.Controls.Add(lblMeasure)

        cmbMeasure.Location = New Point(535, 17) ' Lăsat 70px distanță
        cmbMeasure.Width = 140
        cmbMeasure.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMeasure.BackColor = Color.FromArgb(38, 38, 62)
        cmbMeasure.ForeColor = Color.White
        For Each k In MeasureMap.Keys
            cmbMeasure.Items.Add(k)
        Next
        cmbMeasure.SelectedIndex = 0
        pnlToolbar.Controls.Add(cmbMeasure)

        ' Chart type dropdown
        Dim lblChart As New Label
        lblChart.Text = "Chart:"
        lblChart.ForeColor = Color.Silver
        lblChart.AutoSize = True
        lblChart.Location = New Point(695, 20)
        lblChart.BackColor = Color.Transparent
        pnlToolbar.Controls.Add(lblChart)

        cmbChartType.Location = New Point(745, 17) ' Lăsat 50px distanță
        cmbChartType.Width = 100
        cmbChartType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbChartType.BackColor = Color.FromArgb(38, 38, 62)
        cmbChartType.ForeColor = Color.White
        cmbChartType.Items.AddRange({"Line", "Bar", "Column"})
        cmbChartType.SelectedIndex = 0
        pnlToolbar.Controls.Add(cmbChartType)

        ' Buttons - Repozitionate pt a se potrivi cu noile coordonate
        StyleButton(btnLoad, "Load Data", Color.FromArgb(70, 155, 95), Color.White)
        btnLoad.Location = New Point(870, 14)
        pnlToolbar.Controls.Add(btnLoad)

        StyleButton(btnExport, "Export CSV", Color.FromArgb(55, 115, 195), Color.White)
        btnExport.Location = New Point(1015, 14)
        pnlToolbar.Controls.Add(btnExport)

        StyleButton(btnClear, "Clear", Color.FromArgb(175, 55, 55), Color.White)
        btnClear.Location = New Point(1160, 14)
        pnlToolbar.Controls.Add(btnClear)

        ' Outer split
        splitOuter.Dock = DockStyle.Fill
        splitOuter.Orientation = Orientation.Vertical
        splitOuter.SplitterDistance = 220
        splitOuter.BackColor = Color.FromArgb(18, 18, 28)
        splitOuter.Panel1.BackColor = Color.FromArgb(22, 22, 36)
        splitOuter.Panel2.BackColor = Color.FromArgb(18, 18, 28)
        Me.Controls.Add(splitOuter)

        BuildSidebar(splitOuter.Panel1)

        splitMain.Dock = DockStyle.Fill
        splitMain.Orientation = Orientation.Horizontal
        splitMain.SplitterDistance = 250
        splitMain.BackColor = Color.FromArgb(18, 18, 28)
        splitMain.Panel1.BackColor = Color.FromArgb(18, 18, 28)
        splitMain.Panel2.BackColor = Color.FromArgb(18, 18, 28)
        splitOuter.Panel2.Controls.Add(splitMain)

        BuildGrid()
        splitMain.Panel1.Controls.Add(dgvData)

        BuildChartControl()
        splitMain.Panel2.Controls.Add(chartMain)
    End Sub

    Private Sub BuildSidebar(panel As Panel)
        panel.Padding = New Padding(8)

        Dim lblCF As New Label
        lblCF.Text = "WINES FILTER"
        lblCF.ForeColor = Color.FromArgb(220, 175, 120)
        lblCF.Font = New Font("Segoe UI Semibold", 8.5F)
        lblCF.AutoSize = True
        lblCF.Location = New Point(8, 100)
        panel.Controls.Add(lblCF)

        Dim btnAll As New Button
        StyleButton(btnAll, "All", Color.FromArgb(50, 80, 50), Color.White)
        btnAll.Width = 70 : btnAll.Height = 24
        btnAll.Location = New Point(8, 70)
        AddHandler btnAll.Click, Sub(s, e)
                                     suppressRedraw = True
                                     For i = 0 To clbWines.Items.Count - 1
                                         clbWines.SetItemChecked(i, True)
                                     Next
                                     suppressRedraw = False
                                     RefreshChart()
                                 End Sub
        panel.Controls.Add(btnAll)

        Dim btnNone As New Button
        StyleButton(btnNone, "None", Color.FromArgb(80, 50, 50), Color.White)
        btnNone.Width = 70 : btnNone.Height = 24
        btnNone.Location = New Point(84, 70)
        AddHandler btnNone.Click, Sub(s, e)
                                      suppressRedraw = True
                                      For i = 0 To clbWines.Items.Count - 1
                                          clbWines.SetItemChecked(i, False)
                                      Next
                                      suppressRedraw = False
                                      RefreshChart()
                                  End Sub
        panel.Controls.Add(btnNone)

        ' COBORTĂ MAI JOS PENTRU A NU SE SUPRAPUNE
        clbWines.Location = New Point(8, 125)
        clbWines.Size = New Size(200, 315) ' Ajustat un pic height-ul pentru ca am coborat lista
        clbWines.BackColor = Color.FromArgb(28, 28, 44)
        clbWines.ForeColor = Color.FromArgb(210, 210, 230)
        clbWines.Font = New Font("Segoe UI", 9.0F)
        clbWines.BorderStyle = BorderStyle.None
        clbWines.CheckOnClick = True
        panel.Controls.Add(clbWines)

        Dim lblMH As New Label
        lblMH.Text = "MONTH RANGE"
        lblMH.ForeColor = Color.FromArgb(220, 175, 120)
        lblMH.Font = New Font("Segoe UI Semibold", 8.5F)
        lblMH.AutoSize = True
        lblMH.Location = New Point(8, 448) ' Ajustate în jos ca să facă loc listei
        panel.Controls.Add(lblMH)

        lblMonthRange.Text = "From: -   To: -"
        lblMonthRange.ForeColor = Color.Silver
        lblMonthRange.Font = New Font("Segoe UI", 8.5F)
        lblMonthRange.AutoSize = True
        lblMonthRange.Location = New Point(8, 466)
        panel.Controls.Add(lblMonthRange)

        Dim lblFrom As New Label
        lblFrom.Text = "From"
        lblFrom.ForeColor = Color.FromArgb(150, 150, 180)
        lblFrom.Font = New Font("Segoe UI", 8.0F)
        lblFrom.AutoSize = True
        lblFrom.Location = New Point(8, 488)
        panel.Controls.Add(lblFrom)

        trkMonthFrom.Location = New Point(8, 504)
        trkMonthFrom.Width = 200
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
        lblTo.Location = New Point(8, 550)
        panel.Controls.Add(lblTo)

        trkMonthTo.Location = New Point(8, 566)
        trkMonthTo.Width = 200
        trkMonthTo.Minimum = 1
        trkMonthTo.Maximum = 12
        trkMonthTo.Value = 12
        trkMonthTo.TickFrequency = 1
        trkMonthTo.SmallChange = 1
        trkMonthTo.LargeChange = 1
        trkMonthTo.BackColor = Color.FromArgb(22, 22, 36)
        panel.Controls.Add(trkMonthTo)

        ' Total label
        Dim lblTotalTitle As New Label
        lblTotalTitle.Text = "TOTAL SELECTED"
        lblTotalTitle.ForeColor = Color.FromArgb(220, 175, 120)
        lblTotalTitle.Font = New Font("Segoe UI Semibold", 8.5F)
        lblTotalTitle.AutoSize = True
        lblTotalTitle.Location = New Point(8, 620)
        panel.Controls.Add(lblTotalTitle)

        lblTotal.Text = "-"
        lblTotal.ForeColor = Color.FromArgb(130, 195, 130)
        lblTotal.Font = New Font("Segoe UI Semibold", 11.0F)
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(8, 640)
        panel.Controls.Add(lblTotal)
    End Sub

    Private Sub BuildGrid()
        dgvData.Dock = DockStyle.Fill
        dgvData.BackgroundColor = Color.FromArgb(22, 22, 36)
        dgvData.GridColor = Color.FromArgb(48, 48, 68)
        dgvData.DefaultCellStyle.BackColor = Color.FromArgb(26, 26, 42)
        dgvData.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 225)
        dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 95, 175)
        dgvData.DefaultCellStyle.SelectionForeColor = Color.White
        dgvData.DefaultCellStyle.Font = New Font("Consolas", 9.0F)
        dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 62)
        dgvData.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(240, 200, 100)
        dgvData.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.5F)
        dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvData.ColumnHeadersHeight = 36
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvData.ColumnHeadersVisible = True
        dgvData.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 48)
        dgvData.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(140, 140, 170)
        dgvData.RowHeadersWidth = 36
        dgvData.EnableHeadersVisualStyles = False

        ' REPARAT: Modificat să umple tot spațiul vizual
        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvData.ReadOnly = True
        dgvData.AllowUserToAddRows = False
        dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvData.BorderStyle = BorderStyle.None
        dgvData.ScrollBars = ScrollBars.Both
    End Sub

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
        ca.AxisY.LabelStyle.ForeColor = Color.White
        ca.AxisY.LabelStyle.Font = New Font("Segoe UI", 9.0F)
        ca.AxisY.LineColor = Color.FromArgb(100, 100, 140)
        ca.AxisY.MajorGrid.LineColor = Color.FromArgb(40, 40, 60)
        ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot
        ca.AxisY.LabelStyle.Format = "N0"
        ca.AxisY.Title = "Value"
        ca.AxisY.TitleFont = New Font("Segoe UI Semibold", 9.5F)
        ca.AxisY.TitleForeColor = Color.White
        ca.AxisY.Minimum = 0
        chartMain.ChartAreas.Add(ca)

        Dim t As New Title("Wine Analysis Chart")
        t.Font = New Font("Segoe UI Semibold", 11.0F)
        t.ForeColor = Color.White
        chartMain.Titles.Add(t)

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

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        lblStatus.Text = "  Connecting..."
        lblStatus.ForeColor = Color.Gold
        Application.DoEvents()
        Try
            Dim selectedYear As String = If(cmbYear.SelectedItem IsNot Nothing, cmbYear.SelectedItem.ToString(), "2018")
            Dim selectedMeasureKey As String = If(cmbMeasure.SelectedItem IsNot Nothing, cmbMeasure.SelectedItem.ToString(), "Net Revenue")
            Dim selectedMeasure As String = MeasureMap(selectedMeasureKey)

            Dim conn As New AdomdConnection(
                "Provider=MSOLAP;Data Source=localhost\MSSQLSERVER01;Catalog=ProiectDWh1;Integrated Security=SSPI;")
            conn.Open()

            ' MDX REPARAT: Folosim .Children în loc de Descendants pentru a aduce nivelul imediat următor (luni)
            Dim mdx As String = $"
            SELECT 
                Descendants([Dim Date].[Hierarchy].[Year].&[{selectedYear}], 2, SELF) ON COLUMNS,
                NON EMPTY [Dim Wine].[Subcategory Name].[Subcategory Name].Members ON ROWS 
            FROM [Wines 2]
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