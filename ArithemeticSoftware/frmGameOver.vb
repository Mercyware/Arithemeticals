Public Class frmGameOver

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Stop()
        GotFocus_Chng = True
        WrongCounter = 0
        Lives = 4

        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Audio.Stop()
        WrongCounter = 0
        Lives = 4
        Outer_Quiting = True
        Me.Close()

    End Sub

    Private Sub frmGameOver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Sound) Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(apppath + "About.wav", AudioPlayMode.BackgroundLoop)
        End If
    End Sub
End Class