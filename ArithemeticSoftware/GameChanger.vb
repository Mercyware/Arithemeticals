Public Class GameChanger
    Dim ALevel, SLevel, MLevel, DLevel, MxLevel, AScore, SScore, MScore, DScore, MxScore As Integer
    Dim AAchieve, SAcheive, MAchieve, DAchieve, MxAchieve As Integer
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GotFocus_Chng = False
        Me.Close()

    End Sub

    Private Sub GameChanger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaveLevel()


        Query = "SELECT * FROM Sanders WHERE Username='" & Username & "'"
        QueryData(Query)

        'Getting Levels
        ALevel = Dbdataset.Tables("Records").Rows(0).Item("Add_Level")

        SLevel = Dbdataset.Tables("Records").Rows(0).Item("Sub_Level")

        MLevel = Dbdataset.Tables("Records").Rows(0).Item("Mul_Level")

        DLevel = Dbdataset.Tables("Records").Rows(0).Item("Div_Level")

        MxLevel = Dbdataset.Tables("Records").Rows(0).Item("Mixed_Level")

        'Getting Scores
        AScore = Dbdataset.Tables("Records").Rows(0).Item("AScore")

        SScore = Dbdataset.Tables("Records").Rows(0).Item("SScore")

        MScore = Dbdataset.Tables("Records").Rows(0).Item("MScore")

        DScore = Dbdataset.Tables("Records").Rows(0).Item("DScore")

        MxScore = Dbdataset.Tables("Records").Rows(0).Item("MxScore")





        If Start_Add Then
            lblTittle.Text = "Addition"
            lbllevel.Text = "Level " & ALevel

        End If
        If Start_Sub Then

            lblTittle.Text = "Subtration"
            lbllevel.Text = "Level " & SLevel

        End If

        If Start_Mul Then
            lblTittle.Text = "Multiplication"
            lbllevel.Text = "Level " & MLevel
        End If

        If Start_Div Then

            lblTittle.Text = "Division"
            lbllevel.Text = "Level " & DLevel
        End If

        If Start_Mixed Then
            lblTittle.Text = "Mixed Arithmetic"
            lbllevel.Text = "Level " & MxLevel
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Start_Add Then
            Addition = True
            Subtration = False
            Multiply = False
            Division = False
            Mixed = False
            Level = ALevel
            Score = AScore

        End If
        If Start_Sub Then
            Subtration = True
            Addition = False
            Multiply = False
            Division = False
            Mixed = False
            Level = SLevel
            Score = SScore

        End If

        If Start_Mul Then
            Multiply = True
            Addition = False
            Subtration = False
            Division = False
            Mixed = False
            Level = MLevel
            Score = MScore
        End If

        If Start_Div Then

            Division = True
            Addition = False
            Subtration = False
            Multiply = False
            Mixed = False
            Level = DLevel
            Score = DScore
        End If

        If Start_Mixed Then
            Mixed = True
            Addition = False
            Subtration = False
            Multiply = False
            Division = False
            Level = MxLevel
            Score = MxScore


        End If

        WrongCounter = 0
        Lives = 4
        GotFocus_Chng = True
        Me.Close()
    End Sub
End Class