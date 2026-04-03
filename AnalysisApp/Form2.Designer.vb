<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As New DataGridViewCellStyle()
        Dim ChartArea1 As New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Title1 As New System.Windows.Forms.DataVisualization.Charting.Title()
        pnlBottom = New Panel()
        lblStatus = New Label()
        pnlToolbar = New Panel()
        btnClear = New Button()
        btnExport = New Button()
        btnLoad = New Button()
        cmbChartType = New ComboBox()
        lblChart = New Label()
        cmbMeasure = New ComboBox()
        lblMeasure = New Label()
        cmbYear = New ComboBox()
        lblYear = New Label()
        lblSub = New Label()
        pnlSeparator = New Panel()
        lblBrand = New Label()
        splitOuter = New SplitContainer()
        lblTotal = New Label()
        lblTotalTitle = New Label()
        lblTo = New Label()
        trkMonthTo = New TrackBar()
        lblFrom = New Label()
        trkMonthFrom = New TrackBar()
        lblMonthRange = New Label()
        lblMonthHeader = New Label()
        clbWines = New CheckedListBox()
        btnNoneWines = New Button()
        btnAllWines = New Button()
        lblWineHeader = New Label()
        splitMain = New SplitContainer()
        dgvData = New DataGridView()
        chartMain = New System.Windows.Forms.DataVisualization.Charting.Chart()
        pnlBottom.SuspendLayout()
        pnlToolbar.SuspendLayout()
        CType(splitOuter, ComponentModel.ISupportInitialize).BeginInit()
        splitOuter.Panel1.SuspendLayout()
        splitOuter.Panel2.SuspendLayout()
        splitOuter.SuspendLayout()
        CType(trkMonthTo, ComponentModel.ISupportInitialize).BeginInit()
        CType(trkMonthFrom, ComponentModel.ISupportInitialize).BeginInit()
        CType(splitMain, ComponentModel.ISupportInitialize).BeginInit()
        splitMain.Panel1.SuspendLayout()
        splitMain.Panel2.SuspendLayout()
        splitMain.SuspendLayout()
        CType(dgvData, ComponentModel.ISupportInitialize).BeginInit()
        CType(chartMain, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'pnlBottom
        '
        pnlBottom.BackColor = Color.FromArgb(CByte(12), CByte(12), CByte(20))
        pnlBottom.Controls.Add(lblStatus)
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.Location = New Point(0, 924)
        pnlBottom.Name = "pnlBottom"
        pnlBottom.Size = New Size(1384, 26)
        pnlBottom.TabIndex = 0
        '
        'lblStatus
        '
        lblStatus.Dock = DockStyle.Fill
        lblStatus.Font = New Font("Segoe UI", 8.5!)
        lblStatus.ForeColor = Color.FromArgb(CByte(130), CByte(195), CByte(130))
        lblStatus.Location = New Point(0, 0)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(1384, 26)
        lblStatus.TabIndex = 0
        lblStatus.Text = "  Ready - configure options and click Load Data."
        lblStatus.TextAlign = ContentAlignment.MiddleLeft
        '
        'pnlToolbar
        '
        pnlToolbar.BackColor = Color.FromArgb(CByte(26), CByte(26), CByte(40))
        pnlToolbar.Controls.Add(btnClear)
        pnlToolbar.Controls.Add(btnExport)
        pnlToolbar.Controls.Add(btnLoad)
        pnlToolbar.Controls.Add(cmbChartType)
        pnlToolbar.Controls.Add(lblChart)
        pnlToolbar.Controls.Add(cmbMeasure)
        pnlToolbar.Controls.Add(lblMeasure)
        pnlToolbar.Controls.Add(cmbYear)
        pnlToolbar.Controls.Add(lblYear)
        pnlToolbar.Controls.Add(lblSub)
        pnlToolbar.Controls.Add(pnlSeparator)
        pnlToolbar.Controls.Add(lblBrand)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 0)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(1384, 60)
        pnlToolbar.TabIndex = 1
        '
        'btnClear
        '
        btnClear.BackColor = Color.FromArgb(CByte(175), CByte(55), CByte(55))
        btnClear.Cursor = Cursors.Hand
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI Semibold", 9.0!)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(1160, 14)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(132, 30)
        btnClear.TabIndex = 11
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        btnExport.BackColor = Color.FromArgb(CByte(55), CByte(115), CByte(195))
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI Semibold", 9.0!)
        btnExport.ForeColor = Color.White
        btnExport.Location = New Point(1015, 14)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(132, 30)
        btnExport.TabIndex = 10
        btnExport.Text = "Export CSV"
        btnExport.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        btnLoad.BackColor = Color.FromArgb(CByte(70), CByte(155), CByte(95))
        btnLoad.Cursor = Cursors.Hand
        btnLoad.FlatAppearance.BorderSize = 0
        btnLoad.FlatStyle = FlatStyle.Flat
        btnLoad.Font = New Font("Segoe UI Semibold", 9.0!)
        btnLoad.ForeColor = Color.White
        btnLoad.Location = New Point(870, 14)
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(132, 30)
        btnLoad.TabIndex = 9
        btnLoad.Text = "Load Data"
        btnLoad.UseVisualStyleBackColor = False
        '
        'cmbChartType
        '
        cmbChartType.BackColor = Color.FromArgb(CByte(38), CByte(38), CByte(62))
        cmbChartType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbChartType.ForeColor = Color.White
        cmbChartType.FormattingEnabled = True
        cmbChartType.Location = New Point(745, 17)
        cmbChartType.Name = "cmbChartType"
        cmbChartType.Size = New Size(100, 25)
        cmbChartType.TabIndex = 8
        '
        'lblChart
        '
        lblChart.AutoSize = True
        lblChart.BackColor = Color.Transparent
        lblChart.ForeColor = Color.Silver
        lblChart.Location = New Point(695, 20)
        lblChart.Name = "lblChart"
        lblChart.Size = New Size(43, 17)
        lblChart.TabIndex = 7
        lblChart.Text = "Chart:"
        '
        'cmbMeasure
        '
        cmbMeasure.BackColor = Color.FromArgb(CByte(38), CByte(38), CByte(62))
        cmbMeasure.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMeasure.ForeColor = Color.White
        cmbMeasure.FormattingEnabled = True
        cmbMeasure.Location = New Point(535, 17)
        cmbMeasure.Name = "cmbMeasure"
        cmbMeasure.Size = New Size(140, 25)
        cmbMeasure.TabIndex = 6
        '
        'lblMeasure
        '
        lblMeasure.AutoSize = True
        lblMeasure.BackColor = Color.Transparent
        lblMeasure.ForeColor = Color.Silver
        lblMeasure.Location = New Point(465, 20)
        lblMeasure.Name = "lblMeasure"
        lblMeasure.Size = New Size(61, 17)
        lblMeasure.TabIndex = 5
        lblMeasure.Text = "Measure:"
        '
        'cmbYear
        '
        cmbYear.BackColor = Color.FromArgb(CByte(38), CByte(38), CByte(62))
        cmbYear.DropDownStyle = ComboBoxStyle.DropDownList
        cmbYear.ForeColor = Color.White
        cmbYear.FormattingEnabled = True
        cmbYear.Location = New Point(365, 17)
        cmbYear.Name = "cmbYear"
        cmbYear.Size = New Size(80, 25)
        cmbYear.TabIndex = 4
        '
        'lblYear
        '
        lblYear.AutoSize = True
        lblYear.BackColor = Color.Transparent
        lblYear.ForeColor = Color.Silver
        lblYear.Location = New Point(320, 20)
        lblYear.Name = "lblYear"
        lblYear.Size = New Size(34, 17)
        lblYear.TabIndex = 3
        lblYear.Text = "Year:"
        '
        'lblSub
        '
        lblSub.AutoSize = True
        lblSub.BackColor = Color.Transparent
        lblSub.Font = New Font("Segoe UI Semibold", 9.5!)
        lblSub.ForeColor = Color.FromArgb(CByte(220), CByte(175), CByte(120))
        lblSub.Location = New Point(155, 20)
        lblSub.Name = "lblSub"
        lblSub.Size = New Size(103, 17)
        lblSub.TabIndex = 2
        lblSub.Text = "WINE ANALYSIS"
        '
        'pnlSeparator
        '
        pnlSeparator.BackColor = Color.FromArgb(CByte(80), CByte(80), CByte(100))
        pnlSeparator.Location = New Point(140, 19)
        pnlSeparator.Name = "pnlSeparator"
        pnlSeparator.Size = New Size(1, 22)
        pnlSeparator.TabIndex = 1
        '
        'lblBrand
        '
        lblBrand.AutoSize = True
        lblBrand.BackColor = Color.Transparent
        lblBrand.Font = New Font("Segoe UI Black", 14.0!, FontStyle.Bold)
        lblBrand.ForeColor = Color.White
        lblBrand.Location = New Point(15, 15)
        lblBrand.Name = "lblBrand"
        lblBrand.Size = New Size(91, 25)
        lblBrand.TabIndex = 0
        lblBrand.Text = "WinesDW"
        '
        'splitOuter
        '
        splitOuter.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitOuter.Dock = DockStyle.Fill
        splitOuter.FixedPanel = FixedPanel.Panel1
        splitOuter.Location = New Point(0, 60)
        splitOuter.Name = "splitOuter"
        '
        'splitOuter.Panel1
        '
        splitOuter.Panel1.BackColor = Color.FromArgb(CByte(22), CByte(22), CByte(36))
        splitOuter.Panel1.Controls.Add(lblTotal)
        splitOuter.Panel1.Controls.Add(lblTotalTitle)
        splitOuter.Panel1.Controls.Add(lblTo)
        splitOuter.Panel1.Controls.Add(trkMonthTo)
        splitOuter.Panel1.Controls.Add(lblFrom)
        splitOuter.Panel1.Controls.Add(trkMonthFrom)
        splitOuter.Panel1.Controls.Add(lblMonthRange)
        splitOuter.Panel1.Controls.Add(lblMonthHeader)
        splitOuter.Panel1.Controls.Add(clbWines)
        splitOuter.Panel1.Controls.Add(btnNoneWines)
        splitOuter.Panel1.Controls.Add(btnAllWines)
        splitOuter.Panel1.Controls.Add(lblWineHeader)
        splitOuter.Panel1.Padding = New Padding(8)
        '
        'splitOuter.Panel2
        '
        splitOuter.Panel2.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitOuter.Panel2.Controls.Add(splitMain)
        splitOuter.Size = New Size(1384, 864)
        splitOuter.SplitterDistance = 220
        splitOuter.TabIndex = 2
        '
        'lblTotal
        '
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI Semibold", 11.0!)
        lblTotal.ForeColor = Color.FromArgb(CByte(130), CByte(195), CByte(130))
        lblTotal.Location = New Point(8, 640)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(14, 20)
        lblTotal.TabIndex = 11
        lblTotal.Text = "-"
        '
        'lblTotalTitle
        '
        lblTotalTitle.AutoSize = True
        lblTotalTitle.Font = New Font("Segoe UI Semibold", 8.5!)
        lblTotalTitle.ForeColor = Color.FromArgb(CByte(220), CByte(175), CByte(120))
        lblTotalTitle.Location = New Point(8, 620)
        lblTotalTitle.Name = "lblTotalTitle"
        lblTotalTitle.Size = New Size(92, 15)
        lblTotalTitle.TabIndex = 10
        lblTotalTitle.Text = "TOTAL SELECTED"
        '
        'lblTo
        '
        lblTo.AutoSize = True
        lblTo.Font = New Font("Segoe UI", 8.0!)
        lblTo.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(180))
        lblTo.Location = New Point(8, 550)
        lblTo.Name = "lblTo"
        lblTo.Size = New Size(18, 13)
        lblTo.TabIndex = 9
        lblTo.Text = "To"
        '
        'trkMonthTo
        '
        trkMonthTo.BackColor = Color.FromArgb(CByte(22), CByte(22), CByte(36))
        trkMonthTo.Location = New Point(8, 566)
        trkMonthTo.Maximum = 12
        trkMonthTo.Minimum = 1
        trkMonthTo.Name = "trkMonthTo"
        trkMonthTo.Size = New Size(200, 45)
        trkMonthTo.TabIndex = 8
        trkMonthTo.Value = 12
        '
        'lblFrom
        '
        lblFrom.AutoSize = True
        lblFrom.Font = New Font("Segoe UI", 8.0!)
        lblFrom.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(180))
        lblFrom.Location = New Point(8, 488)
        lblFrom.Name = "lblFrom"
        lblFrom.Size = New Size(32, 13)
        lblFrom.TabIndex = 7
        lblFrom.Text = "From"
        '
        'trkMonthFrom
        '
        trkMonthFrom.BackColor = Color.FromArgb(CByte(22), CByte(22), CByte(36))
        trkMonthFrom.Location = New Point(8, 504)
        trkMonthFrom.Maximum = 12
        trkMonthFrom.Minimum = 1
        trkMonthFrom.Name = "trkMonthFrom"
        trkMonthFrom.Size = New Size(200, 45)
        trkMonthFrom.TabIndex = 6
        trkMonthFrom.Value = 1
        '
        'lblMonthRange
        '
        lblMonthRange.AutoSize = True
        lblMonthRange.Font = New Font("Segoe UI", 8.5!)
        lblMonthRange.ForeColor = Color.Silver
        lblMonthRange.Location = New Point(8, 466)
        lblMonthRange.Name = "lblMonthRange"
        lblMonthRange.Size = New Size(84, 15)
        lblMonthRange.TabIndex = 5
        lblMonthRange.Text = "From: -   To: -"
        '
        'lblMonthHeader
        '
        lblMonthHeader.AutoSize = True
        lblMonthHeader.Font = New Font("Segoe UI Semibold", 8.5!)
        lblMonthHeader.ForeColor = Color.FromArgb(CByte(220), CByte(175), CByte(120))
        lblMonthHeader.Location = New Point(8, 448)
        lblMonthHeader.Name = "lblMonthHeader"
        lblMonthHeader.Size = New Size(83, 15)
        lblMonthHeader.TabIndex = 4
        lblMonthHeader.Text = "MONTH RANGE"
        '
        'clbWines
        '
        clbWines.BackColor = Color.FromArgb(CByte(28), CByte(28), CByte(44))
        clbWines.BorderStyle = BorderStyle.None
        clbWines.CheckOnClick = True
        clbWines.Font = New Font("Segoe UI", 9.0!)
        clbWines.ForeColor = Color.FromArgb(CByte(210), CByte(210), CByte(230))
        clbWines.FormattingEnabled = True
        clbWines.Location = New Point(8, 125)
        clbWines.Name = "clbWines"
        clbWines.Size = New Size(200, 315)
        clbWines.TabIndex = 3
        '
        'btnNoneWines
        '
        btnNoneWines.BackColor = Color.FromArgb(CByte(80), CByte(50), CByte(50))
        btnNoneWines.Cursor = Cursors.Hand
        btnNoneWines.FlatAppearance.BorderSize = 0
        btnNoneWines.FlatStyle = FlatStyle.Flat
        btnNoneWines.Font = New Font("Segoe UI Semibold", 9.0!)
        btnNoneWines.ForeColor = Color.White
        btnNoneWines.Location = New Point(84, 70)
        btnNoneWines.Name = "btnNoneWines"
        btnNoneWines.Size = New Size(70, 24)
        btnNoneWines.TabIndex = 2
        btnNoneWines.Text = "None"
        btnNoneWines.UseVisualStyleBackColor = False
        '
        'btnAllWines
        '
        btnAllWines.BackColor = Color.FromArgb(CByte(50), CByte(80), CByte(50))
        btnAllWines.Cursor = Cursors.Hand
        btnAllWines.FlatAppearance.BorderSize = 0
        btnAllWines.FlatStyle = FlatStyle.Flat
        btnAllWines.Font = New Font("Segoe UI Semibold", 9.0!)
        btnAllWines.ForeColor = Color.White
        btnAllWines.Location = New Point(8, 70)
        btnAllWines.Name = "btnAllWines"
        btnAllWines.Size = New Size(70, 24)
        btnAllWines.TabIndex = 1
        btnAllWines.Text = "All"
        btnAllWines.UseVisualStyleBackColor = False
        '
        'lblWineHeader
        '
        lblWineHeader.AutoSize = True
        lblWineHeader.Font = New Font("Segoe UI Semibold", 8.5!)
        lblWineHeader.ForeColor = Color.FromArgb(CByte(220), CByte(175), CByte(120))
        lblWineHeader.Location = New Point(8, 100)
        lblWineHeader.Name = "lblWineHeader"
        lblWineHeader.Size = New Size(75, 15)
        lblWineHeader.TabIndex = 0
        lblWineHeader.Text = "WINES FILTER"
        '
        'splitMain
        '
        splitMain.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitMain.Dock = DockStyle.Fill
        splitMain.Location = New Point(0, 0)
        splitMain.Name = "splitMain"
        splitMain.Orientation = Orientation.Horizontal
        '
        'splitMain.Panel1
        '
        splitMain.Panel1.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitMain.Panel1.Controls.Add(dgvData)
        '
        'splitMain.Panel2
        '
        splitMain.Panel2.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitMain.Panel2.Controls.Add(chartMain)
        splitMain.Size = New Size(1160, 864)
        splitMain.SplitterDistance = 250
        splitMain.TabIndex = 0
        '
        'dgvData
        '
        dgvData.AllowUserToAddRows = False
        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvData.BackgroundColor = Color.FromArgb(CByte(22), CByte(22), CByte(36))
        dgvData.BorderStyle = BorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(38), CByte(38), CByte(62))
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 9.5!)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(240), CByte(200), CByte(100))
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvData.ColumnHeadersHeight = 36
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(26), CByte(26), CByte(42))
        DataGridViewCellStyle2.Font = New Font("Consolas", 9.0!)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(205), CByte(205), CByte(225))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(75), CByte(95), CByte(175))
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        dgvData.DefaultCellStyle = DataGridViewCellStyle2
        dgvData.Dock = DockStyle.Fill
        dgvData.EnableHeadersVisualStyles = False
        dgvData.GridColor = Color.FromArgb(CByte(48), CByte(48), CByte(68))
        dgvData.Location = New Point(0, 0)
        dgvData.Name = "dgvData"
        dgvData.ReadOnly = True
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(48))
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(140), CByte(140), CByte(170))
        dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvData.RowHeadersWidth = 36
        dgvData.RowTemplate.Height = 25
        dgvData.ScrollBars = ScrollBars.Both
        dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvData.Size = New Size(1160, 250)
        dgvData.TabIndex = 0
        '
        'chartMain
        '
        ChartArea1.AxisX.Interval = 1R
        ChartArea1.AxisX.LabelStyle.Angle = -30
        ChartArea1.AxisX.LabelStyle.Font = New Font("Segoe UI Semibold", 9.0!)
        ChartArea1.AxisX.LabelStyle.ForeColor = Color.White
        ChartArea1.AxisX.LineColor = Color.FromArgb(CByte(100), CByte(100), CByte(140))
        ChartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb(CByte(40), CByte(40), CByte(60))
        ChartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea1.AxisX.MajorTickMark.LineColor = Color.FromArgb(CByte(100), CByte(100), CByte(140))
        ChartArea1.AxisX.Title = "Month"
        ChartArea1.AxisX.TitleFont = New Font("Segoe UI Semibold", 9.5!)
        ChartArea1.AxisX.TitleForeColor = Color.White
        ChartArea1.AxisY.LabelStyle.Font = New Font("Segoe UI", 9.0!)
        ChartArea1.AxisY.LabelStyle.ForeColor = Color.White
        ChartArea1.AxisY.LabelStyle.Format = "N0"
        ChartArea1.AxisY.LineColor = Color.FromArgb(CByte(100), CByte(100), CByte(140))
        ChartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(CByte(40), CByte(40), CByte(60))
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea1.AxisY.Minimum = 0R
        ChartArea1.AxisY.Title = "Value"
        ChartArea1.AxisY.TitleFont = New Font("Segoe UI Semibold", 9.5!)
        ChartArea1.AxisY.TitleForeColor = Color.White
        ChartArea1.BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(38))
        ChartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea1.BackSecondaryColor = Color.FromArgb(CByte(28), CByte(28), CByte(44))
        ChartArea1.BorderColor = Color.FromArgb(CByte(55), CByte(55), CByte(75))
        ChartArea1.BorderWidth = 1
        ChartArea1.Name = "main"
        chartMain.ChartAreas.Add(ChartArea1)
        chartMain.Dock = DockStyle.Fill
        Legend1.Alignment = StringAlignment.Center
        Legend1.BackColor = Color.FromArgb(CByte(28), CByte(28), CByte(44))
        Legend1.BorderColor = Color.FromArgb(CByte(55), CByte(55), CByte(75))
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.Font = New Font("Segoe UI", 9.0!)
        Legend1.ForeColor = Color.White
        Legend1.Name = "Legend1"
        chartMain.Legends.Add(Legend1)
        chartMain.Location = New Point(0, 0)
        chartMain.Name = "chartMain"
        Title1.Font = New Font("Segoe UI Semibold", 11.0!)
        Title1.ForeColor = Color.White
        Title1.Name = "Title1"
        Title1.Text = "Wine Analysis Chart"
        chartMain.Titles.Add(Title1)
        chartMain.Size = New Size(1160, 610)
        chartMain.TabIndex = 0
        chartMain.Text = "chartMain"
        '
        'Form2
        '
        AutoScaleDimensions = New SizeF(8.0!, 20.0!)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        ClientSize = New Size(1384, 950)
        Controls.Add(splitOuter)
        Controls.Add(pnlToolbar)
        Controls.Add(pnlBottom)
        Font = New Font("Segoe UI", 9.5!)
        MinimumSize = New Size(1100, 800)
        Name = "Form2"
        Text = "WinesDW - Wine Analysis"
        pnlBottom.ResumeLayout(False)
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        splitOuter.Panel1.ResumeLayout(False)
        splitOuter.Panel1.PerformLayout()
        splitOuter.Panel2.ResumeLayout(False)
        CType(splitOuter, ComponentModel.ISupportInitialize).EndInit()
        splitOuter.ResumeLayout(False)
        CType(trkMonthTo, ComponentModel.ISupportInitialize).EndInit()
        CType(trkMonthFrom, ComponentModel.ISupportInitialize).EndInit()
        splitMain.Panel1.ResumeLayout(False)
        splitMain.Panel2.ResumeLayout(False)
        CType(splitMain, ComponentModel.ISupportInitialize).EndInit()
        splitMain.ResumeLayout(False)
        CType(dgvData, ComponentModel.ISupportInitialize).EndInit()
        CType(chartMain, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents pnlToolbar As Panel
    Friend WithEvents btnClear As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents cmbChartType As ComboBox
    Friend WithEvents lblChart As Label
    Friend WithEvents cmbMeasure As ComboBox
    Friend WithEvents lblMeasure As Label
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents lblYear As Label
    Friend WithEvents lblSub As Label
    Friend WithEvents pnlSeparator As Panel
    Friend WithEvents lblBrand As Label
    Friend WithEvents splitOuter As SplitContainer
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotalTitle As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents trkMonthTo As TrackBar
    Friend WithEvents lblFrom As Label
    Friend WithEvents trkMonthFrom As TrackBar
    Friend WithEvents lblMonthRange As Label
    Friend WithEvents lblMonthHeader As Label
    Friend WithEvents clbWines As CheckedListBox
    Friend WithEvents btnNoneWines As Button
    Friend WithEvents btnAllWines As Button
    Friend WithEvents lblWineHeader As Label
    Friend WithEvents splitMain As SplitContainer
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents chartMain As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
