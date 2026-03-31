Imports System.Windows.Forms
Imports System.Drawing

Public Class MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setăm fereastra principală
        Me.Text = "WinesDW - Unified Dashboard"
        Me.Size = New Size(1450, 1000)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Creăm controlul cu Tab-uri
        Dim tabControl As New TabControl()
        tabControl.Dock = DockStyle.Fill
        tabControl.Font = New Font("Segoe UI Semibold", 10.0F)
        Me.Controls.Add(tabControl)

        ' --- TAB 1: Varianta Colegului (Form1) ---
        Dim tab1 As New TabPage("Form1")
        tabControl.TabPages.Add(tab1)

        Dim frmColeg As New Form1()
        frmColeg.TopLevel = False ' Esențial: îi spunem că nu mai e fereastră independentă
        frmColeg.FormBorderStyle = FormBorderStyle.None ' Îi tăiem marginile și X-ul
        frmColeg.Dock = DockStyle.Fill
        tab1.Controls.Add(frmColeg)
        frmColeg.Show()

        ' --- TAB 2: Dashboard-ul Nostru (Form2) ---
        Dim tab2 As New TabPage("📊 Dashboard Subcategorii")
        tabControl.TabPages.Add(tab2)

        Dim frmNoi As New Form2()
        frmNoi.TopLevel = False
        frmNoi.FormBorderStyle = FormBorderStyle.None
        frmNoi.Dock = DockStyle.Fill
        tab2.Controls.Add(frmNoi)
        frmNoi.Show()

    End Sub

End Class