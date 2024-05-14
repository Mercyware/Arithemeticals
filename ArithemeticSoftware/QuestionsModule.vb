Module QuestionsModule
    Public Num1, Num2, Ans As Integer

    Public indexer As Integer

    'Declaration for Sound
    Public Sound As Boolean
    Public Timing As Boolean


    Public apppath = AppDomain.CurrentDomain.BaseDirectory.ToString

    Public Subtration, Addition, Multiply, Division, Mixed As Boolean
    Public Arith_Sign As String
    Public LastGame, Last_Level As Integer
    Public Score, TotalScore, Achievement, ACode, ScoreAdder As Integer
    Public Correct As Boolean
    Public WrongCounter As Integer
    Public LastCode, NewCode As Integer
    Public OldLevel, NewLevel As Integer
    Public IMax As Integer = 10
    Public IMin As Integer = 1
    Public LastUser As String
    Public NewUser As String
    Public Quit As Boolean
    Public Lives As Integer = 4

    Public Start_Add, Start_Sub, Start_Mul, Start_Div, Start_Mixed As Boolean
    Public Outer_Quiting As Boolean = False

    Public FirstNumber, SecondNumber As Integer

    Public Reminder As Integer

    Public GotFocus_Chng As Boolean
    Public FormCover As Boolean





    Public Sub Achieve_Code_Getter(UserScore As Integer)
        If (UserScore >= 50 And UserScore < 100) Then
            ACode = 1
        ElseIf (UserScore >= 100 And UserScore < 125) Then
            ACode = 2
        ElseIf (UserScore >= 125 And UserScore < 150) Then
            ACode = 3
        ElseIf (UserScore >= 150 And UserScore < 200) Then
            ACode = 4
        ElseIf (UserScore >= 200 And UserScore < 250) Then
            ACode = 5
        ElseIf (UserScore >= 250 And UserScore < 300) Then
            ACode = 6
        ElseIf (UserScore >= 300 And UserScore < 400) Then
            ACode = 7
        ElseIf (UserScore >= 400 And UserScore < 500) Then
            ACode = 8
        ElseIf (UserScore >= 500 And UserScore < 550) Then
            ACode = 9
        ElseIf (UserScore >= 550 And UserScore < 600) Then
            ACode = 10
        ElseIf (UserScore >= 600 And UserScore < 700) Then
            ACode = 11
        ElseIf (UserScore >= 700 And UserScore < 800) Then
            ACode = 12
        ElseIf (UserScore >= 800 And UserScore < 1000) Then
            ACode = 13
        ElseIf (UserScore >= 1000 And UserScore < 1500) Then
            ACode = 14
        ElseIf (UserScore >= 1500 And UserScore < 1800) Then
            ACode = 15
        ElseIf (UserScore >= 1800 And UserScore < 2500) Then
            ACode = 16
        ElseIf (UserScore >= 2500 And UserScore < 3000) Then
            ACode = 17
        ElseIf (UserScore >= 3000 And UserScore < 3250) Then
            ACode = 18
        ElseIf (UserScore >= 3250 And UserScore < 3500) Then
            ACode = 19
        ElseIf (UserScore >= 3500 And UserScore < 3800) Then
            ACode = 20
        ElseIf (UserScore >= 3800 And UserScore < 4000) Then
            ACode = 21
        ElseIf (UserScore >= 4000 And UserScore < 4500) Then
            ACode = 22
        ElseIf (UserScore >= 4500 And UserScore < 5000) Then
            ACode = 23
        ElseIf (UserScore >= 5000) Then
            ACode = 24
        Else
            ACode = 0
        End If
        NewCode = ACode

    End Sub

    Public Sub Level_Changer(UserScore As Integer)
        If (UserScore >= 150 And UserScore < 400) Then
            Level = 2
            IMin = 1
            IMax = 50
        ElseIf (UserScore >= 400 And UserScore < 900) Then
            Level = 3
            IMin = 1
            IMax = 90
        ElseIf (UserScore >= 900 And UserScore < 1500) Then
            Level = 4
            IMin = 1
            IMax = 100
        ElseIf (UserScore >= 1500 And UserScore < 2200) Then
            Level = 5
            IMin = 1
            IMax = 200
        ElseIf (UserScore >= 2200 And UserScore < 3000) Then
            Level = 6
            IMin = 1
            IMax = 500
        ElseIf (UserScore >= 4000 And UserScore < 5000) Then
            Level = 7
            IMin = 1
            IMax = 900
        ElseIf (UserScore >= 5000 And UserScore < 5500) Then
            Level = 8
            IMin = 1
            IMax = 1000
        ElseIf (UserScore >= 5500) Then
            Level = 9
            IMin = 1
            IMax = 20000
        End If
        NewLevel = Level
    End Sub

    Public Sub Score_Adder(UserLevel As Integer)
        Select Case UserLevel
          
            Case 1
                ScoreAdder = 5
            Case 2
                ScoreAdder = 10
            Case 3
                ScoreAdder = 10
            Case 4
                ScoreAdder = 15
            Case 5
                ScoreAdder = 15
            Case 6
                ScoreAdder = 20
            Case 7
                ScoreAdder = 20
            Case 8
                ScoreAdder = 25
        End Select
    End Sub

    Public Sub Score_AdderTimer(UserLevel As Integer)
        Select Case UserLevel
            Case 1
                ScoreAdder = 10
              


            Case 2
                ScoreAdder = 10
               
            Case 3
                ScoreAdder = 15
               
            Case 4
                ScoreAdder = 20
               
            Case 5
                ScoreAdder = 20
              
            Case 6
                ScoreAdder = 25
              
            Case 7
                ScoreAdder = 25
              
            Case 8
                ScoreAdder = 30
               
        End Select
    End Sub

    Public Sub GameType(ByVal LastPlayed As Integer)
        Select Case LastPlayed
            Case 0
                Addition = True
                Subtration = False
                Multiply = False
                Division = False
                Mixed = False
            Case 1 'Addition
                Addition = True
                Subtration = False
                Multiply = False
                Division = False
                Mixed = False

            Case 2 'Subtration
                Addition = False
                Subtration = True
                Multiply = False
                Division = False
                Mixed = False
            Case 3 'Multiplication
                Addition = False
                Subtration = False
                Multiply = True
                Division = False
                Mixed = False
            Case 4 'Division
                Addition = False
                Subtration = False
                Multiply = False
                Division = True
                Mixed = False
            Case 5 ' Mixed
                Addition = False
                Subtration = False
                Multiply = False
                Division = False
                Mixed = True

        End Select

    End Sub

    Public Sub Randomizer(IMin, Imax)

        'Subroutine That Randomise and Generate The Question

        Randomize()
        Num1 = Int((Imax - IMin + 1) * Rnd()) + IMin
        Num2 = Int((Imax - IMin + 1) * Rnd()) + IMin

        'Performing The Multiplication
        Ans = Num1 * Num2

        FirstNumber = Num1
        SecondNumber = Num2
    End Sub

    Public Sub AddRandomizer(IMin, Imax)

        'Subroutine That Randomise and Generate The Question

        Randomize()
        Num1 = Int((Imax - IMin + 1) * Rnd()) + IMin
        Num2 = Int((Imax - IMin + 1) * Rnd()) + IMin

        'Performing The Multiplication
        Ans = Num1 + Num2

        FirstNumber = Num1
        SecondNumber = Num2
    End Sub

    Public Sub SubRandomizer(IMin, Imax)

        'Subroutine That Randomise and Generate The Question

        Randomize()
        Num1 = Int((Imax - IMin + 1) * Rnd()) + IMin
        Num2 = Int((Imax - IMin + 1) * Rnd()) + IMin

        'Performing The Multiplication

        If (Num1 > Num2) Then
            Ans = Num1 - Num2
            FirstNumber = Num1
            SecondNumber = Num2
        Else
            Ans = Num2 - Num1
            FirstNumber = Num2
            SecondNumber = Num1
        End If
    End Sub
    'The Subrouti
    Public Sub DivRandomizer(IMin, Imax)
        'Subroutine That Randomise and Generate The Question
        Dim a As Boolean = False
        Do While a <> True
            Randomize()
            Num1 = Int((Imax - IMin + 1) * Rnd()) + IMin
            Num2 = Int((Imax - IMin + 1) * Rnd()) + IMin

            If Num1 > Num2 Then
                a = True
            Else
                a = False
            End If

            Reminder = Num1 Mod Num2
            If (Reminder <> 0) Then
                a = False
            Else
                a = True
            End If

        Loop

        'Performing The Dision
        Ans = Num1 / Num2



        FirstNumber = Num1
        SecondNumber = Num2
    End Sub

    Public Sub MxRandomiser()
        Dim Randomm As Integer = Int((4 - 1 + 1) * Rnd()) + 1



        Select Case Randomm
            Case 1
                AddRandomizer(IMin, IMax)
                Arith_Sign = "+"
            Case 2
                SubRandomizer(IMin, IMax)
                Arith_Sign = "-"
            Case 3
                Randomizer(IMin, IMax)
                Arith_Sign = "x"
            Case 4
                DivRandomizer(IMin, IMax)
                Arith_Sign = "/"
        End Select
    End Sub

    'Randomizing Values In An Array To Be Use To Randomize Labels
    Public Sub N_Integers(n As Integer, Narray() As Integer)
        'Randomly sorts N integers and puts results in Narray
        Dim i As Integer, j As Integer, T, k As Integer
        'Order all elements initially
        For i = 1 To n : Narray(i) = i : Next i
        'J is number of integers remaining
        k = 0
        For j = n To 0 Step -1


            'k = Int(Rnd() * j)
            'MsgBox(k)
            i = k
            T = Narray(j)
            Narray(j) = Narray(i)
            Narray(i) = T
        Next j

    End Sub

    Public Sub Shufle(Of T)(ByRef A() As T)
        Dim last As Integer = A.Length - 1


        Dim B(last) As T
        Dim done(last) As Byte
        Dim r As New Random(My.Computer.Clock.TickCount)
        Dim n As Integer
        For i As Integer = 0 To last
            Do
                n = r.Next(last - 1)
            Loop Until Not done(n)
            done(n) = 1

            B(i) = A(n)
        Next
        A = B
    End Sub


    Public Sub Shuffle2(ByRef sDeck() As Integer)
        Dim alRand As New ArrayList
        Dim iCount As Int32 = 0
        Dim iRand As Int32
        Dim n As Integer
        n = sDeck.GetUpperBound(0)
        Do While iCount <= n
            Dim rand As New Random
            iRand = rand.Next(0, n)
            If alRand.Contains(iRand) = False Then
                alRand.Add(iRand)
                iCount += 1
            End If
        Loop

        Array.Sort(alRand.ToArray, sDeck)

    End Sub
    Public Sub Main()
        Dim arrayShuffle() As Integer = {0, 1, 2, 3}

        For Each fruit As Integer In arrayShuffle
            Console.WriteLine(fruit)
        Next fruit

        Shuffle(arrayShuffle)

        For Each fruit As Integer In arrayShuffle
            MsgBox(fruit)
        Next fruit

    End Sub
    Public Sub Shuffle(ByRef shuffleArray() As Integer)
        Dim counter As Integer
        Dim newPosition As Integer
        Dim shuffleMethod As New Random
        Dim tempObject As Object

        For counter = 0 To shuffleArray.Length - 1
            newPosition = shuffleMethod.Next(0, shuffleArray.Length - 1)

            tempObject = shuffleArray(counter)
            shuffleArray(counter) = shuffleArray(newPosition)
            shuffleArray(newPosition) = tempObject
        Next counter
    End Sub

    Public Sub SaveLevel()
        'Saving the Last level and Initiating the New Game and New Level
        If (Addition) Then
            Query = "UPDATE Sanders SET  [Add_Level]=" & Level & ",[AScore]=" & Score & " WHERE Username ='" & Username & "'"
        ElseIf Subtration Then
            Query = "UPDATE Sanders SET  [Sub_Level]=" & Level & ",[SScore]=" & Score & " WHERE Username ='" & Username & "'"
        ElseIf Multiply Then
            Query = "UPDATE Sanders SET  [Mul_Level]=" & Level & ",[MScore]=" & Score & " WHERE Username ='" & Username & "'"
        ElseIf Division Then
            Query = "UPDATE Sanders SET  [Div_Level]=" & Level & ",[DScore]=" & Score & " WHERE Username ='" & Username & "'"
        ElseIf Mixed Then
            Query = "UPDATE Sanders SET  [Mixed_Level]=" & Level & ",[MxScore]=" & Score & " WHERE Username ='" & Username & "'"
        End If
        Update_Query(Query)

    End Sub
End Module
