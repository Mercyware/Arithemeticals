Public Class frmSettings
    Dim T, S As Integer
    Dim SoundValue, TimeValue As Integer
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Updating the Values
        If RdSound_No.Checked = True Then
            S = 0
            Sound = False

        End If
        If RdSound_Yes.Checked = True Then
            S = 1
            Sound = True
        End If

        If RdTime_No.Checked = True Then
            T = 0
            Timing = False
        End If
        If RdTime_Yes.Checked = True Then
            T = 1
            Timing = True
        End If



        Query = "UPDATE Sanders SET [TimeSetting] =" & T & ", [SoundSetting]=" & S & " WHERE Username = '" & Username & "'"

        Update_Query(Query)
        GotFocus_Chng = False
        Me.Close()
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Query = "SELECT * FROM Sanders WHERE Username='" & Username & "'"
        QueryData(Query)
        SoundValue = Dbdataset.Tables("Records").Rows(0).Item("SoundSetting")
        TimeValue = Dbdataset.Tables("Records").Rows(0).Item("TimeSetting")

        If SoundValue = 1 Then
            Sound = True
        Else
            Sound = False

        End If

        If TimeValue = 1 Then
            Timing = True
        Else
            Timing = False
        End If



        If Sound = True Then
            RdSound_Yes.Checked = True
            RdSound_No.Checked = False
        Else
            RdSound_Yes.Checked = False
            RdSound_No.Checked = True
        End If

        If Timing = True Then
            RdTime_Yes.Checked = True
            RdTime_No.Checked = False
        Else
            RdTime_Yes.Checked = False
            RdTime_No.Checked = True
        End If

    End Sub
End Class