Imports System.Windows.Forms

Public Class MainForm
    Private form1Host As Form1
    Private form2Host As Form2

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmbeddedForm(tabForm1, form1Host)
        LoadEmbeddedForm(tabForm2, form2Host)
    End Sub

    Private Sub LoadEmbeddedForm(Of TForm As {Form, New})(hostPage As TabPage, ByRef hostedForm As TForm)
        If hostedForm IsNot Nothing AndAlso Not hostedForm.IsDisposed Then
            Return
        End If

        hostPage.Controls.Clear()

        hostedForm = New TForm() With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None,
            .Dock = DockStyle.Fill
        }

        hostPage.Controls.Add(hostedForm)
        hostedForm.Show()
    End Sub
End Class
