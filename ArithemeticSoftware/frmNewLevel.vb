Public Class frmNewLevel

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Stop()
        GotFocus_Chng = True
        Me.Close()
    End Sub

    Private Sub frmNewLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Sound) Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(apppath + "Samba.wav", AudioPlayMode.BackgroundLoop)
        End If
        Select Case NewLevel

            Case 1
                lbllevel.Text = ("Level 1")
                lblTittle.Text = "Well done !"
            Case 2
                lbllevel.Text = "Level 2"
                lblTittle.Text = "Very Good !"
            Case 3
                lbllevel.Text = "Level 3"
                lblTittle.Text = "Good Works !"
            Case 4
                lbllevel.Text = "Level 4"
                lblTittle.Text = "Great Job!"
            Case 5
                lbllevel.Text = "Level 5"
                lblTittle.Text = "Brilliant Work"
            Case 6
                lbllevel.Text = "Level 6"
                lblTittle.Text = "Super Cool!"
            Case 7
                lbllevel.Text = "Level 7"
                lblTittle.Text = "Problem Solver!"
            Case 8
                lbllevel.Text = "Level 8"
                lblTittle.Text = "You are Great!"
            Case 9
                lbllevel.Text = "The End !"
                lblTittle.Text = "Super Arithmetical!"
                Label1.Visible = True
        End Select
    End Sub
End Class