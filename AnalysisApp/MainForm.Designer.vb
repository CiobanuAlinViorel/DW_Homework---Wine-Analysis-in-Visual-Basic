<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        tabMain = New TabControl()
        tabForm1 = New TabPage()
        tabForm2 = New TabPage()
        tabMain.SuspendLayout()
        SuspendLayout()
        '
        'tabMain
        '
        tabMain.Controls.Add(tabForm1)
        tabMain.Controls.Add(tabForm2)
        tabMain.Dock = DockStyle.Fill
        tabMain.Font = New Font("Segoe UI Semibold", 10.0!)
        tabMain.Location = New Point(0, 0)
        tabMain.Name = "tabMain"
        tabMain.SelectedIndex = 0
        tabMain.Size = New Size(1450, 1000)
        tabMain.TabIndex = 0
        '
        'tabForm1
        '
        tabForm1.Location = New Point(4, 26)
        tabForm1.Name = "tabForm1"
        tabForm1.Padding = New Padding(3)
        tabForm1.Size = New Size(1442, 970)
        tabForm1.TabIndex = 0
        tabForm1.Text = "Form1"
        tabForm1.UseVisualStyleBackColor = True
        '
        'tabForm2
        '
        tabForm2.Location = New Point(4, 26)
        tabForm2.Name = "tabForm2"
        tabForm2.Padding = New Padding(3)
        tabForm2.Size = New Size(1442, 970)
        tabForm2.TabIndex = 1
        tabForm2.Text = "Dashboard Subcategorii"
        tabForm2.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        AutoScaleDimensions = New SizeF(8.0!, 20.0!)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1450, 1000)
        Controls.Add(tabMain)
        Name = "MainForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "WinesDW - Unified Dashboard"
        tabMain.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabForm1 As TabPage
    Friend WithEvents tabForm2 As TabPage
End Class
