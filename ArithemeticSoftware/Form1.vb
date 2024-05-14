Public Class Form1
    Dim Answered, QLeft, Question, counter, k, j As Integer
    Dim LabelsAns(4) As Label
    Dim LastUser As String
    Dim LastPlayed As Integer
    Dim Arr() As Integer
    Dim Time_Counter As Integer = 30

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        FormCover = False
        If Outer_Quiting = True Then
            Outer_Quiting = False
            Me.Close()

        End If



        Label1.Text = ""
        Label1.Text = "Welcome, " & TittleCase(Username)
        lblLevel.Text = Last_Level & " of " & 8
        lblScore.Text = Score
        Achieve_Code_Getter(Score)


        Reward_NoShow(NewCode)


        'Lives = 4
        If (GotFocus_Chng) Then
            If (Addition = True) Then
                Call AddRandomizer(IMin, IMax)
                Arith_Sign = "+"
            End If

            If (Subtration = True) Then
                Call SubRandomizer(IMin, IMax)
                Arith_Sign = "-"
            End If


            If (Multiply = True) Then
                Call Randomizer(IMin, IMax)
                Arith_Sign = "x"
            End If


            If (Division = True) Then
                Call DivRandomizer(IMin, IMax)
                Arith_Sign = "/"
            End If

            If Mixed = True Then
                Call MxRandomiser()

            End If

            Call Options(IMin, IMax)
            GotFocus_Chng = False
        End If


        If (WrongCounter = 3) Then

            WrongCounter = 0
            Lives = Lives - 1
        End If

        If (Timing = False) Then
            Timer1.Enabled = False
            lblTimer.Visible = False
        Else
            'MsgBox("TImer")
            lblTimer.Visible = True
            Timer1.Enabled = True
            ' Timer_Scheduler()
        End If

        ChooseLive(Lives)


        If (Sound = False) Then
            My.Computer.Audio.Stop()
        End If
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If Timing = True Then
            Timer1.Enabled = False
        End If
    End Sub


    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        SplashScreen1.Close()
    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        frmQuit.ShowDialog()

        If (Quit = True) Then


        Else
            e.Cancel = True
            Exit Sub
        End If



    End Sub

    Private Sub Form1_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus


    End Sub
    Private Sub Timer_Scheduler()
      
        Time_Counter = 30
        Timer1.Enabled = True

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormCover = False
        databasecon()
        Username = ""
        Dim SoundValue, TimeValue As Integer

        'Checking to See the Last User
        Query = "SELECT * FROM LastGamer"
        QueryData(Query)
        If (max > 0) Then
            LastUser = (Dbdataset.Tables("Records").Rows(0).Item("LastUser"))
            LastPlayed = (Dbdataset.Tables("Records").Rows(0).Item("LastPlayed"))
        Else
            LastUser = ""
        End If


        If (LastUser = "") Then ' No User, Ask For Name
            frmName.ShowDialog(Me)
        Else
            'There is a User
            Username = LastUser
            NewUser = LastUser
            Query = "SELECT * FROM Sanders WHERE Username='" & Username & "'"
            QueryData(Query)
            Dim LastPlayed As Integer = Dbdataset.Tables("Records").Rows(0).Item("LastPlayed")
            Score = Dbdataset.Tables("Records").Rows(0).Item("Score")
            LastCode = Dbdataset.Tables("Records").Rows(0).Item("Achieve")
            SoundValue = Dbdataset.Tables("Records").Rows(0).Item("SoundSetting")
            TimeValue = Dbdataset.Tables("Records").Rows(0).Item("TimeSetting")

            If SoundValue = 1 Then
                Sound = True
            Else
                Sound = False

            End If

            If (TimeValue = 1) Then
                Timing = True

            Else
                Timing = False
            End If

            If (Timing = False) Then
                lblTimer.Visible = False

            Else
                lblTimer.Visible = True
                ' Timer_Scheduler()

            End If
            Dim lastlevel As Integer


            Select Case LastPlayed

                Case 1
                    lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Add_Level")
                    Score = Dbdataset.Tables("Records").Rows(0).Item("AScore")
                Case 2
                    lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Sub_Level")
                    Score = Dbdataset.Tables("Records").Rows(0).Item("SScore")
                Case 3
                    lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Mul_Level")
                    Score = Dbdataset.Tables("Records").Rows(0).Item("MScore")
                Case 4
                    lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Div_Level")
                    Score = Dbdataset.Tables("Records").Rows(0).Item("DScore")
                Case 5
                    lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Mixed_Level")
                    Score = Dbdataset.Tables("Records").Rows(0).Item("MxScore")
                Case Else
                    lastlevel = Dbdataset.Tables("Records").Rows(0).Item("Add_Level")
                    Score = Dbdataset.Tables("Records").Rows(0).Item("AScore")

            End Select

            LastGame = LastPlayed
            Last_Level = lastlevel
            Level = lastlevel
            OldLevel = lastlevel

            lblLevel.Text = Last_Level & " of " & 8
            lblScore.Text = Score
            Label1.Text = "Welcome , " & TittleCase(Username)

            'Setting Up Game Type
            GameType(LastPlayed)


        End If





        counter = 1


        If (Addition = True) Then
            Call AddRandomizer(IMin, IMax)
            Arith_Sign = "+"
        End If

        If (Subtration = True) Then
            Call SubRandomizer(IMin, IMax)
            Arith_Sign = "-"
        End If


        If (Multiply = True) Then
            Call Randomizer(IMin, IMax)
            Arith_Sign = "x"
        End If


        If (Division = True) Then
            Call DivRandomizer(IMin, IMax)
            Arith_Sign = "/"
        End If

        If Mixed = True Then
            Call MxRandomiser()

        End If

        Call Options(IMin, IMax)


        Lives = 4

        Achieve_Code_Getter(Score)


        Reward_NoShow(NewCode)
    End Sub

    Private Sub Options(IMin, Imax)

        If (Timing = True) Then
            Timer_Scheduler()
        End If

        LabelsAns(0) = lblA
        LabelsAns(1) = lblB
        LabelsAns(2) = lblC
        LabelsAns(3) = lblD
        Dim i As Integer

        Dim A As String = LabelsAns(1).Text


        'Enabling The Disabled Options
        For i = 0 To 3
            LabelsAns(i).Enabled = True
        Next


        For i = 0 To 3
            LabelsAns(i).BackColor = Color.AliceBlue
        Next

        For i = 0 To 3
            LabelsAns(i).Text = ""
        Next

        LabelsAns(0).Text = "A :"
        LabelsAns(1).Text = "B :"
        LabelsAns(2).Text = "C :"
        LabelsAns(3).Text = "D :"

        'Displaying the Question On the Labelbox

        lblQuestion.Text = FirstNumber & " " & Arith_Sign & " " & SecondNumber & " = "

        'Randomly Placing The Options On the Labels

        ' Declaring the Array that holds the ooptions
        Arr = {0, 1, 2, 3}

        Shuffle(Arr) 'Shuffle the Array

        ' If We are Doing multiplication
        If (Multiply = True) Then


            'Displaying the alternative Options 
            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            i = Num1 * Num2
            If i = Ans Then
                i = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin)
            End If


            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            j = Num1 * Num2
            If j = Ans Or j = i Then
                j = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin)
            End If


            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            k = Num1 * Num2

            If k = Ans Or k = i Or k = j Then
                k = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin)
            End If


        End If



        ' If We are Doing Addtion
        If (Addition = True) Then

            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            i = Num1 + Num2
            If i = Ans Then
                i = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If



            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            j = Num1 + Num2

            If j = Ans Or j = i Then
                j = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If



            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            k = Num1 + Num2

            If k = Ans Or k = i Or k = j Then
                k = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If


        End If


        ' If We are Doing Subtration
        If (Subtration = True) Then

            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            If Num1 > Num2 Then
                i = Num1 - Num2
            Else
                i = Num2 - Num1
            End If

            If i = Ans Then
                i = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If


            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)

            If Num1 > Num2 Then
                j = Num1 - Num2
            Else
                j = Num2 - Num1
            End If
            If j = Ans Or j = i Then
                j = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If


            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)

            If Num1 > Num2 Then
                k = Num1 - Num2
            Else
                k = Num2 - Num1
            End If
            If k = Ans Or k = i Or k = j Then
                k = (Int((Imax - IMin + 1) * Rnd()) + IMin) + (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If


        End If


        If (Division = True) Then
            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            i = Num1 Mod Num2
            If i = Ans Then
                i = (Int((Imax - IMin + 1) * Rnd()) + IMin) Mod (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If


            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            j = Num1 Mod Num2

            If j = Ans Or j = i Then
                j = (Int((Imax - IMin + 1) * Rnd()) + IMin) Mod (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If


            Num1 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            Num2 = (Int((Imax - IMin + 1) * Rnd()) + IMin)
            k = Num1 Mod Num2

            If k = Ans Or k = i Or k = j Then
                k = (Int((Imax - IMin + 1) * Rnd()) + IMin) Mod (Int((Imax - IMin + 1) * Rnd()) + IMin) + 1
            End If
        End If

        'Displaying Options

        DisplayOptions(Ans, i, j, k)




        'Playing the Sound Again
        'My.Computer.Audio.Stop()
        'My.Computer.Audio.Play(apppath + "Drum.wav", AudioPlayMode.Background)


    End Sub

    Private Sub DisplayOptions(A As Integer, B As Integer, C As Integer, D As Integer)
        LabelsAns(Arr(0)).Text = LabelsAns(Arr(0)).Text & " " & A
        LabelsAns(Arr(1)).Text = LabelsAns(Arr(1)).Text & " " & B
        LabelsAns(Arr(2)).Text = LabelsAns(Arr(2)).Text & " " & C
        LabelsAns(Arr(3)).Text = LabelsAns(Arr(3)).Text & " " & D
    End Sub
    Private Sub ClickedAns(Index As Integer)
        'Disable All Labels Fro Being Clicked
        For i = 0 To 3
            LabelsAns(i).Enabled = False
        Next

        'Checking for the Selected Answer
        Dim Lab() As String
        'Spliting The option
        Lab = Split(LabelsAns(Index).Text, ":")
        If (Val(Trim(Lab(1)))) = Ans Then
            indexer = Index
            'Playing Sound
            ' First Checking If The Sound Is Still Playin And If So
            'Restart The Sound
            My.Computer.Audio.Stop()
            If (Sound = True) Then
                My.Computer.Audio.Play(apppath + "Clapp.wav", AudioPlayMode.Background)
            End If
           
            Correct = True
           
        'Initializing Counter That Does The Counting Of The Blinking Value.
        'Timer3 Does The Blinking
        Timer3.Enabled = True

            'Counting Number Of Question Answered
            counter = 1
        Answered = Answered + 1
        Else


        'If User Is Wrong
        'Play Sound Checking Whether the Sound Is Still playing
            'If playing the Sound Restarts For OLODO

            My.Computer.Audio.Stop()
            If (Sound = True) Then
                My.Computer.Audio.Play(apppath + "Wrong.wav", AudioPlayMode.Background)
            End If

            Correct = False
        'Since Player Has Chosen The Wrong Answer, Get The Label With The Correct Answer And Make It Blink
        For i = 0 To 3
            Lab = Split(LabelsAns(i).Text, ":")
            If Val(Trim(Lab(1))) = Ans Then
                indexer = i
                Exit For
            End If
        Next
        counter = 1
        Timer3.Enabled = True
        End If

        'Updating Score,Levels and Achievements
        If (Correct = True) Then
            'User Got the answer Correctly
            '
            ''Checking the Scoring System
            If (Timing = True) Then
                Score_AdderTimer(Level)
            Else
                Score_Adder(Level)
            End If


            Score = Score + ScoreAdder 'Updating th Score

            'Updating the Level

            Level_Changer(Score)
            Achieve_Code_Getter(Score)
            If (NewCode > LastCode) Then
                Achive_Image(NewCode)
                LastCode = NewCode

            End If

            If (NewLevel > OldLevel) Then
                OldLevel = NewLevel
                Timer1.Enabled = False
                FormCover = True
                frmNewLevel.ShowDialog()
            End If

            'Displaying the Result
            lblScore.Text = Score
            lblLevel.Text = Level & " of " & 8
        Else
            WrongCounter = WrongCounter + 1
        End If

        If (WrongCounter = 3) Then
            WrongCounter = 0
            Lives = Lives - 1
            ' String file_name =appath & 

            ' Load the picture into a Bitmap.

            ChooseLive(Lives)


        End If


    End Sub
    Private Sub ChooseLive(Lives As Integer)
        Select Case Lives
            Case 0
                'No More Lives Game Over
                Timer1.Enabled = False
                FormCover = True
                frmGameOver.ShowDialog()
            Case 1
                PicLives.Image = My.Resources._1lives
            Case 2
                PicLives.Image = My.Resources._2lives
            Case 3
                PicLives.Image = My.Resources._3lives
            Case 4
                PicLives.Image = My.Resources._4lives
        End Select
    End Sub

    Private Sub Achive_Image(ACode As Integer)
        Select Case ACode
            Case 1
                PicAchieve.Image = My.Resources.A1

            Case 2
                PicAchieve.Image = My.Resources.A2
            Case 3
                PicAchieve.Image = My.Resources.A3
            Case 4
                PicAchieve.Image = My.Resources.A4
            Case 5
                PicAchieve.Image = My.Resources.A5
            Case 6
                PicAchieve.Image = My.Resources.A6
            Case 7
                PicAchieve.Image = My.Resources.A7
            Case 8
                PicAchieve.Image = My.Resources.A8
            Case 9
                PicAchieve.Image = My.Resources.A9
            Case 10
                PicAchieve.Image = My.Resources.A10
            Case 11
                PicAchieve.Image = My.Resources.A11
            Case 12
                PicAchieve.Image = My.Resources.A12
            Case 13
                PicAchieve.Image = My.Resources.A13
            Case 14
                PicAchieve.Image = My.Resources.A14
            Case 15
                PicAchieve.Image = My.Resources.A15
            Case 16
                PicAchieve.Image = My.Resources.A16
            Case 17
                PicAchieve.Image = My.Resources.A17
            Case 18
                PicAchieve.Image = My.Resources.A18
            Case 19
                PicAchieve.Image = My.Resources.A19
            Case 20
                PicAchieve.Image = My.Resources.A20
            Case 21
                PicAchieve.Image = My.Resources.A21
            Case 22
                PicAchieve.Image = My.Resources.A22
            Case 23
                PicAchieve.Image = My.Resources.A23
            Case 24
                PicAchieve.Image = My.Resources.A24

        End Select
        FormCover = True
        Timer1.Enabled = False
        frmAchievement.ShowDialog()

    End Sub

    Private Sub Reward_NoShow(ACode As Integer)
        Select Case ACode
            Case 0
                PicAchieve.Image = My.Resources.A0
            Case 1
                PicAchieve.Image = My.Resources.A1

            Case 2
                PicAchieve.Image = My.Resources.A2
            Case 3
                PicAchieve.Image = My.Resources.A3
            Case 4
                PicAchieve.Image = My.Resources.A4
            Case 5
                PicAchieve.Image = My.Resources.A5
            Case 6
                PicAchieve.Image = My.Resources.A6
            Case 7
                PicAchieve.Image = My.Resources.A7
            Case 8
                PicAchieve.Image = My.Resources.A8
            Case 9
                PicAchieve.Image = My.Resources.A9
            Case 10
                PicAchieve.Image = My.Resources.A10
            Case 11
                PicAchieve.Image = My.Resources.A11
            Case 12
                PicAchieve.Image = My.Resources.A12
            Case 13
                PicAchieve.Image = My.Resources.A13
            Case 14
                PicAchieve.Image = My.Resources.A14
            Case 15
                PicAchieve.Image = My.Resources.A15
            Case 16
                PicAchieve.Image = My.Resources.A16
            Case 17
                PicAchieve.Image = My.Resources.A17
            Case 18
                PicAchieve.Image = My.Resources.A18
            Case 19
                PicAchieve.Image = My.Resources.A19
            Case 20
                PicAchieve.Image = My.Resources.A20
            Case 21
                PicAchieve.Image = My.Resources.A21
            Case 22
                PicAchieve.Image = My.Resources.A22
            Case 23
                PicAchieve.Image = My.Resources.A23
            Case 24
                PicAchieve.Image = My.Resources.A24
           
        End Select


    End Sub
    Private Sub lblA_Click(sender As Object, e As EventArgs) Handles lblA.Click
        ClickedAns(0)

    End Sub

    Private Sub lblB_Click(sender As Object, e As EventArgs) Handles lblB.Click
        ClickedAns(1)
    End Sub

    Private Sub lblC_Click(sender As Object, e As EventArgs) Handles lblC.Click
        ClickedAns(2)
    End Sub

    Private Sub lblD_Click(sender As Object, e As EventArgs) Handles lblD.Click
        ClickedAns(3)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        lblTimer.ForeColor = Color.White
        Time_Counter = Time_Counter - 1
        If (Time_Counter < 10) Then
            lblTimer.Text = "00:0" & Time_Counter
            lblTimer.ForeColor = Color.Red
        Else
            lblTimer.Text = "00:" & Time_Counter
        End If

        If Time_Counter = 0 Then
            Timer1.Enabled = False
            frmTimeUp.ShowDialog()
        End If

        If FormCover = True Then
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        '************* Blinks The Option When A User Clicks On The Right Answer
        'Blinks The Right One If The User Clicks The Wrong One
        If LabelsAns(indexer).BackColor = Color.Red Then
            LabelsAns(indexer).BackColor = Color.Lime

        Else
            LabelsAns(indexer).BackColor = Color.Red
        End If

      

        counter = counter + 1

        If counter = 10 Then
            If (Addition = True) Then
                Call AddRandomizer(IMin, IMax)
                Arith_Sign = "+"
            End If

            If (Subtration = True) Then
                Call SubRandomizer(IMin, IMax)
                Arith_Sign = "-"
            End If


            If (Multiply = True) Then
                Call Randomizer(IMin, IMax)
                Arith_Sign = "x"
            End If


            If (Division = True) Then
                Call DivRandomizer(IMin, IMax)
                Arith_Sign = "/"
            End If

            If Mixed Then
                Call MxRandomiser()

            End If
            Call Options(IMin, IMax)

            Timer3.Enabled = False
        End If

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.Close()

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        frmRestart.ShowDialog()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        frmSettings.ShowDialog()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Start_Add = True
        Start_Sub = False
        Start_Mul = False
        Start_Div = False
        Start_Mixed = False
        FormCover = True
        GameChanger.ShowDialog()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Start_Add = False
        Start_Sub = True
        Start_Mul = False
        Start_Div = False
        Start_Mixed = False

        GameChanger.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Start_Add = False
        Start_Sub = False
        Start_Mul = True
        Start_Div = False
        Start_Mixed = False

        GameChanger.ShowDialog()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Start_Add = False
        Start_Sub = False
        Start_Mul = False
        Start_Div = True
        Start_Mixed = False

        GameChanger.ShowDialog()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Start_Add = False
        Start_Sub = False
        Start_Mul = False
        Start_Div = False
        Start_Mixed = True

        GameChanger.ShowDialog()
    End Sub

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs)
        frmAbout.ShowDialog()
    End Sub

    Private Sub Form1_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmWho.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmAbout.ShowDialog()
    End Sub
End Class
