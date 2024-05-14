Public Class frmWho

    Private Sub frmWho_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        lstUser.Items.Clear()
        Query = "SELECT * FROM Sanders"
        QueryData(Query)
        For i = 0 To max - 1
            TittleCase(lstUser.Items.Add(Dbdataset.Tables("Records").Rows(i).Item("Username")))
        Next
    End Sub

    Private Sub frmWho_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        lstUser.Items.Clear()
        Query = "SELECT * FROM Sanders"
        QueryData(Query)
        For i = 0 To max - 1
            TittleCase(lstUser.Items.Add(Dbdataset.Tables("Records").Rows(i).Item("Username")))
        Next
    End Sub

    Private Sub frmWho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstUser.Items.Clear()
        Query = "SELECT * FROM Sanders"
        QueryData(Query)
        For i = 0 To max - 1
            TittleCase(lstUser.Items.Add(Dbdataset.Tables("Records").Rows(i).Item("Username")))
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GotFocus_Chng = False
        Me.Close()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Username = LCase(lstUser.SelectedItem)
        'getting the LastPlayed Game
        Query = "SELECT * FROM Sanders WHERE Username='" & Username & "'"
        QueryData(Query)
        Dim LastPlayed As Integer= Dbdataset.Tables("Records").Rows(0).Item("LastPlayed")
        Dim lastlevel As Integer


        Select Case LastPlayed

            Case 1
                lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Add_Level")
            Case 2
                lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Sub_Level")
            Case 3
                lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Mul_Level")
            Case 4
                lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Div_Level")
            Case 5
                lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Mixed_Level")
            Case Else
                lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Add_Level")

        End Select

        LastGame = LastPlayed
        Last_Level = lastlevel
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

        NewUser = LastPlayed

        GotFocus_Chng = True
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmName.Show()
    End Sub
End Class