<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New DataVisualization.Charting.Title()
        pnlBottom = New Panel()
        lblStatus = New Label()
        pnlToolbar = New Panel()
        btnClear = New Button()
        btnExport = New Button()
        btnLoad = New Button()
        lblTitle = New Label()
        splitOuter = New SplitContainer()
        lblTo = New Label()
        trkMonthTo = New TrackBar()
        lblFrom = New Label()
        trkMonthFrom = New TrackBar()
        lblMonthRange = New Label()
        lblMonthHeader = New Label()
        clbCountries = New CheckedListBox()
        btnNoneCountries = New Button()
        btnAllCountries = New Button()
        lblCountriesHeader = New Label()
        splitMain = New SplitContainer()
        dgvData = New DataGridView()
        chartMain = New DataVisualization.Charting.Chart()
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
        ' pnlBottom
        ' 
        pnlBottom.BackColor = Color.FromArgb(CByte(12), CByte(12), CByte(20))
        pnlBottom.Controls.Add(lblStatus)
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.Location = New Point(0, 874)
        pnlBottom.Name = "pnlBottom"
        pnlBottom.Size = New Size(1284, 26)
        pnlBottom.TabIndex = 0
        ' 
        ' lblStatus
        ' 
        lblStatus.Dock = DockStyle.Fill
        lblStatus.Font = New Font("Segoe UI", 8.5F)
        lblStatus.ForeColor = Color.FromArgb(CByte(130), CByte(195), CByte(130))
        lblStatus.Location = New Point(0, 0)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(1284, 26)
        lblStatus.TabIndex = 0
        lblStatus.Text = "  Ready - click Load Data to connect."
        lblStatus.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(26), CByte(26), CByte(40))
        pnlToolbar.Controls.Add(btnClear)
        pnlToolbar.Controls.Add(btnExport)
        pnlToolbar.Controls.Add(btnLoad)
        pnlToolbar.Controls.Add(lblTitle)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 0)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(1284, 57)
        pnlToolbar.TabIndex = 1
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(175), CByte(55), CByte(55))
        btnClear.Cursor = Cursors.Hand
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI Semibold", 9F)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(846, 11)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(132, 30)
        btnClear.TabIndex = 3
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.FromArgb(CByte(55), CByte(115), CByte(195))
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI Semibold", 9F)
        btnExport.ForeColor = Color.White
        btnExport.Location = New Point(699, 11)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(132, 30)
        btnExport.TabIndex = 2
        btnExport.Text = "Export CSV"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' btnLoad
        ' 
        btnLoad.BackColor = Color.FromArgb(CByte(70), CByte(155), CByte(95))
        btnLoad.Cursor = Cursors.Hand
        btnLoad.FlatAppearance.BorderSize = 0
        btnLoad.FlatStyle = FlatStyle.Flat
        btnLoad.Font = New Font("Segoe UI Semibold", 9F)
        btnLoad.ForeColor = Color.White
        btnLoad.Location = New Point(549, 11)
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(132, 30)
        btnLoad.TabIndex = 1
        btnLoad.Text = "Load Data"
        btnLoad.UseVisualStyleBackColor = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI Semibold", 12F)
        lblTitle.ForeColor = Color.FromArgb(CByte(220), CByte(175), CByte(120))
        lblTitle.Location = New Point(12, 11)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(497, 28)
        lblTitle.TabIndex = 0
        lblTitle.Text = "WinesDW  -  Net Revenue by Country & Month  (2018)"
        ' 
        ' splitOuter
        ' 
        splitOuter.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitOuter.Dock = DockStyle.Fill
        splitOuter.FixedPanel = FixedPanel.Panel1
        splitOuter.Location = New Point(0, 57)
        splitOuter.Name = "splitOuter"
        ' 
        ' splitOuter.Panel1
        ' 
        splitOuter.Panel1.BackColor = Color.FromArgb(CByte(22), CByte(22), CByte(36))
        splitOuter.Panel1.Controls.Add(lblTo)
        splitOuter.Panel1.Controls.Add(trkMonthTo)
        splitOuter.Panel1.Controls.Add(lblFrom)
        splitOuter.Panel1.Controls.Add(trkMonthFrom)
        splitOuter.Panel1.Controls.Add(lblMonthRange)
        splitOuter.Panel1.Controls.Add(lblMonthHeader)
        splitOuter.Panel1.Controls.Add(clbCountries)
        splitOuter.Panel1.Controls.Add(btnNoneCountries)
        splitOuter.Panel1.Controls.Add(btnAllCountries)
        splitOuter.Panel1.Controls.Add(lblCountriesHeader)
        splitOuter.Panel1.Padding = New Padding(8)
        ' 
        ' splitOuter.Panel2
        ' 
        splitOuter.Panel2.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitOuter.Panel2.Controls.Add(splitMain)
        splitOuter.Size = New Size(1284, 817)
        splitOuter.SplitterDistance = 215
        splitOuter.TabIndex = 2
        ' 
        ' lblTo
        ' 
        lblTo.AutoSize = True
        lblTo.Font = New Font("Segoe UI", 8F)
        lblTo.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(180))
        lblTo.Location = New Point(8, 510)
        lblTo.Name = "lblTo"
        lblTo.Size = New Size(23, 19)
        lblTo.TabIndex = 9
        lblTo.Text = "To"
        ' 
        ' trkMonthTo
        ' 
        trkMonthTo.BackColor = Color.FromArgb(CByte(22), CByte(22), CByte(36))
        trkMonthTo.Location = New Point(8, 526)
        trkMonthTo.Maximum = 12
        trkMonthTo.Minimum = 1
        trkMonthTo.Name = "trkMonthTo"
        trkMonthTo.Size = New Size(195, 56)
        trkMonthTo.TabIndex = 8
        trkMonthTo.Value = 12
        ' 
        ' lblFrom
        ' 
        lblFrom.AutoSize = True
        lblFrom.Font = New Font("Segoe UI", 8F)
        lblFrom.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(180))
        lblFrom.Location = New Point(8, 448)
        lblFrom.Name = "lblFrom"
        lblFrom.Size = New Size(41, 19)
        lblFrom.TabIndex = 7
        lblFrom.Text = "From"
        ' 
        ' trkMonthFrom
        ' 
        trkMonthFrom.BackColor = Color.FromArgb(CByte(22), CByte(22), CByte(36))
        trkMonthFrom.Location = New Point(8, 464)
        trkMonthFrom.Maximum = 12
        trkMonthFrom.Minimum = 1
        trkMonthFrom.Name = "trkMonthFrom"
        trkMonthFrom.Size = New Size(195, 56)
        trkMonthFrom.TabIndex = 6
        trkMonthFrom.Value = 1
        ' 
        ' lblMonthRange
        ' 
        lblMonthRange.AutoSize = True
        lblMonthRange.Font = New Font("Segoe UI", 8.5F)
        lblMonthRange.ForeColor = Color.Silver
        lblMonthRange.Location = New Point(8, 426)
        lblMonthRange.Name = "lblMonthRange"
        lblMonthRange.Size = New Size(97, 20)
        lblMonthRange.TabIndex = 5
        lblMonthRange.Text = "From: -   To: -"
        ' 
        ' lblMonthHeader
        ' 
        lblMonthHeader.AutoSize = True
        lblMonthHeader.Font = New Font("Segoe UI Semibold", 8.5F)
        lblMonthHeader.ForeColor = Color.FromArgb(CByte(220), CByte(175), CByte(120))
        lblMonthHeader.Location = New Point(8, 408)
        lblMonthHeader.Name = "lblMonthHeader"
        lblMonthHeader.Size = New Size(118, 20)
        lblMonthHeader.TabIndex = 4
        lblMonthHeader.Text = "MONTH RANGE"
        ' 
        ' clbCountries
        ' 
        clbCountries.BackColor = Color.FromArgb(CByte(28), CByte(28), CByte(44))
        clbCountries.BorderStyle = BorderStyle.None
        clbCountries.CheckOnClick = True
        clbCountries.Font = New Font("Segoe UI", 9F)
        clbCountries.ForeColor = Color.FromArgb(CByte(210), CByte(210), CByte(230))
        clbCountries.FormattingEnabled = True
        clbCountries.Location = New Point(8, 58)
        clbCountries.Name = "clbCountries"
        clbCountries.Size = New Size(195, 330)
        clbCountries.TabIndex = 3
        ' 
        ' btnNoneCountries
        ' 
        btnNoneCountries.BackColor = Color.FromArgb(CByte(80), CByte(50), CByte(50))
        btnNoneCountries.Cursor = Cursors.Hand
        btnNoneCountries.FlatAppearance.BorderSize = 0
        btnNoneCountries.FlatStyle = FlatStyle.Flat
        btnNoneCountries.Font = New Font("Segoe UI Semibold", 9F)
        btnNoneCountries.ForeColor = Color.White
        btnNoneCountries.Location = New Point(84, 28)
        btnNoneCountries.Name = "btnNoneCountries"
        btnNoneCountries.Size = New Size(70, 24)
        btnNoneCountries.TabIndex = 2
        btnNoneCountries.Text = "None"
        btnNoneCountries.UseVisualStyleBackColor = False
        ' 
        ' btnAllCountries
        ' 
        btnAllCountries.BackColor = Color.FromArgb(CByte(50), CByte(80), CByte(50))
        btnAllCountries.Cursor = Cursors.Hand
        btnAllCountries.FlatAppearance.BorderSize = 0
        btnAllCountries.FlatStyle = FlatStyle.Flat
        btnAllCountries.Font = New Font("Segoe UI Semibold", 9F)
        btnAllCountries.ForeColor = Color.White
        btnAllCountries.Location = New Point(8, 28)
        btnAllCountries.Name = "btnAllCountries"
        btnAllCountries.Size = New Size(70, 24)
        btnAllCountries.TabIndex = 1
        btnAllCountries.Text = "All"
        btnAllCountries.UseVisualStyleBackColor = False
        ' 
        ' lblCountriesHeader
        ' 
        lblCountriesHeader.AutoSize = True
        lblCountriesHeader.Font = New Font("Segoe UI Semibold", 8.5F)
        lblCountriesHeader.ForeColor = Color.FromArgb(CByte(220), CByte(175), CByte(120))
        lblCountriesHeader.Location = New Point(8, 8)
        lblCountriesHeader.Name = "lblCountriesHeader"
        lblCountriesHeader.Size = New Size(89, 20)
        lblCountriesHeader.TabIndex = 0
        lblCountriesHeader.Text = "COUNTRIES"
        ' 
        ' splitMain
        ' 
        splitMain.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitMain.Dock = DockStyle.Fill
        splitMain.Location = New Point(0, 0)
        splitMain.Name = "splitMain"
        splitMain.Orientation = Orientation.Horizontal
        ' 
        ' splitMain.Panel1
        ' 
        splitMain.Panel1.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitMain.Panel1.Controls.Add(dgvData)
        ' 
        ' splitMain.Panel2
        ' 
        splitMain.Panel2.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        splitMain.Panel2.Controls.Add(chartMain)
        splitMain.Size = New Size(1065, 817)
        splitMain.SplitterDistance = 198
        splitMain.TabIndex = 0
        ' 
        ' dgvData
        ' 
        dgvData.AllowUserToAddRows = False
        dgvData.BackgroundColor = Color.FromArgb(CByte(22), CByte(22), CByte(36))
        dgvData.BorderStyle = BorderStyle.None
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(38), CByte(38), CByte(62))
        DataGridViewCellStyle4.Font = New Font("Segoe UI Semibold", 9.5F)
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(240), CByte(200), CByte(100))
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgvData.ColumnHeadersHeight = 36
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(26), CByte(26), CByte(42))
        DataGridViewCellStyle5.Font = New Font("Consolas", 9F)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(205), CByte(205), CByte(225))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(75), CByte(95), CByte(175))
        DataGridViewCellStyle5.SelectionForeColor = Color.White
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        dgvData.DefaultCellStyle = DataGridViewCellStyle5
        dgvData.Dock = DockStyle.Fill
        dgvData.EnableHeadersVisualStyles = False
        dgvData.GridColor = Color.FromArgb(CByte(48), CByte(48), CByte(68))
        dgvData.Location = New Point(0, 0)
        dgvData.Name = "dgvData"
        dgvData.ReadOnly = True
        DataGridViewCellStyle6.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(48))
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(140), CByte(140), CByte(170))
        dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        dgvData.RowHeadersWidth = 36
        dgvData.RowTemplate.Height = 25
        dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvData.Size = New Size(1065, 198)
        dgvData.TabIndex = 0
        ' 
        ' chartMain
        ' 
        ChartArea2.AxisX.Interval = 1R
        ChartArea2.AxisX.LabelStyle.Angle = -30
        ChartArea2.AxisX.LabelStyle.Font = New Font("Segoe UI Semibold", 9F)
        ChartArea2.AxisX.LabelStyle.ForeColor = Color.White
        ChartArea2.AxisX.LineColor = Color.FromArgb(CByte(100), CByte(100), CByte(140))
        ChartArea2.AxisX.MajorGrid.LineColor = Color.FromArgb(CByte(40), CByte(40), CByte(60))
        ChartArea2.AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea2.AxisX.MajorTickMark.LineColor = Color.FromArgb(CByte(100), CByte(100), CByte(140))
        ChartArea2.AxisX.Title = "Month"
        ChartArea2.AxisX.TitleFont = New Font("Segoe UI Semibold", 9.5F)
        ChartArea2.AxisX.TitleForeColor = Color.White
        ChartArea2.AxisY.LabelStyle.Font = New Font("Segoe UI", 9F)
        ChartArea2.AxisY.LabelStyle.ForeColor = Color.White
        ChartArea2.AxisY.LabelStyle.Format = "N0"
        ChartArea2.AxisY.LineColor = Color.FromArgb(CByte(100), CByte(100), CByte(140))
        ChartArea2.AxisY.MajorGrid.LineColor = Color.FromArgb(CByte(40), CByte(40), CByte(60))
        ChartArea2.AxisY.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea2.AxisY.Minimum = 0R
        ChartArea2.AxisY.Title = "Net Revenue"
        ChartArea2.AxisY.TitleFont = New Font("Segoe UI Semibold", 9.5F)
        ChartArea2.AxisY.TitleForeColor = Color.White
        ChartArea2.BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(38))
        ChartArea2.BackGradientStyle = DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea2.BackSecondaryColor = Color.FromArgb(CByte(28), CByte(28), CByte(44))
        ChartArea2.BorderColor = Color.FromArgb(CByte(55), CByte(55), CByte(75))
        ChartArea2.Name = "main"
        chartMain.ChartAreas.Add(ChartArea2)
        chartMain.Dock = DockStyle.Fill
        Legend2.Alignment = StringAlignment.Center
        Legend2.BackColor = Color.FromArgb(CByte(28), CByte(28), CByte(44))
        Legend2.BorderColor = Color.FromArgb(CByte(55), CByte(55), CByte(75))
        Legend2.Docking = DataVisualization.Charting.Docking.Top
        Legend2.Font = New Font("Segoe UI", 9F)
        Legend2.ForeColor = Color.White
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Legend1"
        chartMain.Legends.Add(Legend2)
        chartMain.Location = New Point(0, 0)
        chartMain.Name = "chartMain"
        chartMain.Size = New Size(1065, 615)
        chartMain.TabIndex = 0
        chartMain.Text = "chartMain"
        Title2.Font = New Font("Segoe UI Semibold", 11F)
        Title2.ForeColor = Color.White
        Title2.Name = "Title1"
        Title2.Text = "Net Revenue by Country & Month (2018)"
        chartMain.Titles.Add(Title2)
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(28))
        ClientSize = New Size(1284, 900)
        Controls.Add(splitOuter)
        Controls.Add(pnlToolbar)
        Controls.Add(pnlBottom)
        Font = New Font("Segoe UI", 9.5F)
        MinimumSize = New Size(1000, 750)
        Name = "Form1"
        Text = "WinesDW - Net Revenue Analysis 2018"
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
    Friend WithEvents lblTitle As Label
    Friend WithEvents splitOuter As SplitContainer
    Friend WithEvents lblTo As Label
    Friend WithEvents trkMonthTo As TrackBar
    Friend WithEvents lblFrom As Label
    Friend WithEvents trkMonthFrom As TrackBar
    Friend WithEvents lblMonthRange As Label
    Friend WithEvents lblMonthHeader As Label
    Friend WithEvents clbCountries As CheckedListBox
    Friend WithEvents btnNoneCountries As Button
    Friend WithEvents btnAllCountries As Button
    Friend WithEvents lblCountriesHeader As Label
    Friend WithEvents splitMain As SplitContainer
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents chartMain As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
