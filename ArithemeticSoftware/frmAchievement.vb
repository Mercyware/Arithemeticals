Public Class frmAchievement

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Stop()
        GotFocus_Chng = False
        Me.Close()
    End Sub

    Private Sub frmAchievement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Achive_Image(NewCode)
        If (Sound) Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(apppath + "Samba.wav", AudioPlayMode.BackgroundLoop)
        End If
    End Sub

    Private Sub Achive_Image(ACode As Integer)

        Select Case ACode
            Case 1
                PicAchieve.Image = My.Resources.Bronze
                lblMsg.Text = "1 New Bronze Coin"

            Case 2
                PicAchieve.Image = My.Resources.Bronze
                lblMsg.Text = "1 New Bronze Coin"
            Case 3
                PicAchieve.Image = My.Resources.Bronze
                lblMsg.Text = "1 New Bronze Coin"
            Case 4
                PicAchieve.Image = My.Resources.Bronze
                lblMsg.Text = "1 New Bronze Coin"
            Case 9
                PicAchieve.Image = My.Resources.Bronze
                lblMsg.Text = "1 New Bronze Coin"
            Case 5
                PicAchieve.Image = My.Resources.Silver
                lblMsg.Text = "1 New Silver Coin"
            Case 6
                PicAchieve.Image = My.Resources.Silver
                lblMsg.Text = "1 New Silver Coin"
            Case 7
                PicAchieve.Image = My.Resources.Silver
                lblMsg.Text = "1 New Silver Coin"
            Case 8
                PicAchieve.Image = My.Resources.Silver
                lblMsg.Text = "1 New Silver Coin"
            Case 12
                PicAchieve.Image = My.Resources.Silver
                lblMsg.Text = "1 New Silver Coin"


            Case 10
                PicAchieve.Image = My.Resources.Gold
                lblMsg.Text = "1 New Gold Coin"
            Case 11
                PicAchieve.Image = My.Resources.Gold
                lblMsg.Text = "1 New Gold Coin"
            Case 13
                PicAchieve.Image = My.Resources.Gold
                lblMsg.Text = "1 New Gold Coin"

            Case 14

                PicAchieve.Image = My.Resources.Ruby_Icon
                lblMsg.Text = "1 New Ruby"
            Case 15
                PicAchieve.Image = My.Resources.Ruby_Icon
                lblMsg.Text = "1 New Ruby"

            Case 16
                PicAchieve.Image = My.Resources.Pearl
                lblMsg.Text = "1 New Pearl"

            Case 17
                PicAchieve.Image = My.Resources.Ruby_Icon
                lblMsg.Text = "1 New Gold Coin & 1 Ruby"
            Case 18
                PicAchieve.Image = My.Resources.Gold
                lblMsg.Text = "1 New Gold Coin"
            Case 19
                PicAchieve.Image = My.Resources.Diamod
                lblMsg.Text = "1 New Diamond"
            Case 20
                PicAchieve.Image = My.Resources.Pearl

                lblMsg.Text = "1 New Ruby & 2 Pearls"
            Case 21
                PicAchieve.Image = My.Resources.Diamod
                lblMsg.Text = "1 New Ruby , 1 Pearl & 1 Diamond"
            Case 22
                PicAchieve.Image = My.Resources.Pearl
                lblMsg.Text = "1 New Pearl"
            Case 23
                PicAchieve.Image = My.Resources.GreenDiamond
                lblMsg.Text = "1 New Green Diamond"
            Case 24
                PicAchieve.Image = My.Resources.BlueDiamond
                lblMsg.Text = "1 New Green Diamond & 1 Blue Diamond "

        End Select
    End Sub

End Class