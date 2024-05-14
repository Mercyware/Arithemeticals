Public NotInheritable Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Sound) Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(apppath + "Game.wav", AudioPlayMode.BackgroundLoop)
        End If
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Stop()
        GotFocus_Chng = False
        Me.Close()
    End Sub
End Class
