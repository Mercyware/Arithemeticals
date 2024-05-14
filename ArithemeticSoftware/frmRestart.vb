Public Class frmRestart

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GotFocus_Chng = True
        Level = 1
        Score = 0
        SaveLevel()
        Me.Close()
    End Sub

    Private Sub frmRestart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaveLevel()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GotFocus_Chng = True
        WrongCounter = 0
        Lives = 4
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GotFocus_Chng = False
        Me.Close()
    End Sub
End Class