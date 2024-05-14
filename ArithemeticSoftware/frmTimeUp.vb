Public Class frmTimeUp

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Stop()
        GotFocus_Chng = True
        Me.Close()
    End Sub

    Private Sub frmTimeUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Sound) Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(apppath + "Buzzer.wav", AudioPlayMode.Background)
        End If

        Label3.Text = "Answer : " & Ans

        WrongCounter = WrongCounter + 1
    End Sub
End Class