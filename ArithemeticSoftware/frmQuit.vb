Public Class frmQuit

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Quit = True
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GotFocus_Chng = False
        Quit = False
        Me.Close()

    End Sub

    Private Sub frmQuit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaveLevel()
        'Saving the Last Player
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

    End Sub
End Class