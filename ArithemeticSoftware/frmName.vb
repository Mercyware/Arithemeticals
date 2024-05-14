Public Class frmName
    Dim LastUser As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Audio.Stop()
        Me.Close()

    End Sub

    Private Sub frmName_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmName_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Sound) Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(apppath + "Game.wav", AudioPlayMode.BackgroundLoop)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Stop()
        Username = LCase(txtName.Text)
        'Checking the Databasse for a similar name
        'Checking to See the Last User
        Query = "SELECT * FROM Sanders WHERE Username='" & Username & "'"
        QueryData(Query)
        If (max > 0) Then ' You cannot Use the Name Already Existing

            ' Display the warning messaage
            frmErrorMsg.ShowDialog()


        Else ' Save the Informatio to thr Database
            Query = "INSERT INTO Sanders  ([Username],[Level],[Achieve],[Score],[Add_Level],[Sub_Level],[Mul_Level],[Div_Level],[Mixed_Level]) VALUES ('" & Username & "'," & 1 & "," & 1 & "," & 1 & "," & 1 & "," & 1 & "," & 1 & "," & 1 & "," & 1 & ")"

            save_Query(Query)
            LastUser = Username

            ''Updating the Last Player
            Query = "SELECT * FROM LastGamer"
            QueryData(Query)
            If (max > 0) Then
                Query = "UPDATE LastGamer SET [LastUser]='" & Username & "'"
                Update_Query(Query)


            Else
                Query = "INSERT INTO LastGamer ([LastUser]) VALUES ('" & Username & "')"
                save_Query(Query)
            End If


            'Setting Up the Game to Play
            GameType(0)
            GotFocus_Chng = True
            Me.Close()



        End If

    End Sub

   
End Class