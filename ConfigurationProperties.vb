Imports System.Windows.Forms

Public Class ConfigurationProperties

    Public Property SelectedObject As Object
        Get
            Return PropertyGrid1.SelectedObject
        End Get
        Set(value As Object)
            PropertyGrid1.SelectedObject = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
