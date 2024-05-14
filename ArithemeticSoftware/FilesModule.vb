Imports System
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Environment
Module FilesModule
    Public dbase As String
    Public dbadapter As New OleDb.OleDbDataAdapter
    Public dbcommand As New OleDb.OleDbCommand
    Public appath = AppDomain.CurrentDomain.BaseDirectory.ToString
    Public DbConn As New OleDb.OleDbConnection
    Public Dbdataset As New DataSet
    Public Query As String
    Public msg As String
    Public max As Integer
    Public FileName, FileText, Username, Level, Achieve As String


    'Retriving server settings information form the server.hms file in the application directory.
    'The server information is being loaded while the application is coming up
    Public Sub FileFinder()
        FileName = appath & "Sanders.txt"
        If System.IO.File.Exists(FileName) Then

            Dim reader As New System.IO.StreamReader(FileName)
            Dim allLines As List(Of String) = New List(Of String)
            Do While Not reader.EndOfStream
                allLines.Add(reader.ReadLine())
            Loop
            reader.Close()

            Username = ReadLine(1, allLines)
            Level = ReadLine(2, allLines)
            Achieve = ReadLine(3, allLines)


        Else
            Using sw As StreamWriter = File.CreateText(FileName)
                sw.WriteLine("Hello")
                sw.WriteLine("And")
                sw.WriteLine("Welcome")
            End Using

        End If


    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function



    Public Sub databasecon()

        'Module To open database


        Dim NewPath As String
        NewPath = GetFolderPath(SpecialFolder.ApplicationData)
        dbase = "Provider = Microsoft.Jet.OLEDB.4.0; Jet OLEDB:Database password =" & "mercyware123" & "; Data source=" & NewPath & "\School 2\Arithmeticals.mdb"
        DbConn = New System.Data.OleDb.OleDbConnection(dbase)
        Try
            DbConn.Open()

        Catch ex As Exception
            MsgBox("An Error has Occured While Trying to open The Database" & vbNewLine & "Please Try again" & vbNewLine & Err.Description, MsgBoxStyle.Critical)
        End Try

        'Checking if The connection is opened 
        If DbConn.State <> ConnectionState.Open Then
            MsgBox("Unable to connect to database" & vbNewLine & "Please contact the system administrator" & vbNewLine & Err.Description, MsgBoxStyle.Critical)
            Exit Sub
        End If

        'Checking if The connection is opened 
        If DbConn.State <> ConnectionState.Open Then
            MsgBox("Unable to connect to database" & vbNewLine & "Please contact the system administrator" & vbNewLine & Err.Description, MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Public Sub QueryData(ByVal Query As String)
        Dbdataset = New DataSet
        'Querying Database
        Call databasecon()
        'checking if connection is successful
        If DbConn.State <> ConnectionState.Open Then
            Exit Sub
        Else
            Try
                dbadapter = New OleDb.OleDbDataAdapter(Query, DbConn)
                Dbdataset = New DataSet
                dbadapter.Fill(Dbdataset, "Records")
                max = Dbdataset.Tables("Records").Rows.Count
                DbConn.Close()
            Catch ex As Exception
                MsgBox("Unable To Access Database" & vbNewLine & Err.Description, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Public Sub save_Query(ByVal query As String)
        'Saving to database
        'calling database connection

        Call databasecon()

        'chcking if connection is successful
        If DbConn.State <> ConnectionState.Open Then
            Exit Sub
        Else
            Try
                dbcommand = DbConn.CreateCommand
                dbcommand.CommandType = CommandType.Text
                dbcommand.CommandText = query
                dbcommand.ExecuteNonQuery()
                DbConn.Close()
            Catch ex As Exception
                MsgBox("An Error Has Occured While Trying To Insert Your Record Into The database" & vbNewLine & Err.Description, MsgBoxStyle.Critical)
            End Try


        End If
    End Sub

    Public Sub Update_Query(ByVal query As String)
        'Saving to database
        'calling database connection

        Call databasecon()

        'chcking if connection is successful
        If DbConn.State <> ConnectionState.Open Then
            Exit Sub
        Else
            Try
                dbcommand = New OleDbCommand(query, DbConn)

                dbcommand.CommandType = CommandType.Text
                dbcommand.CommandText = query
                dbcommand.ExecuteNonQuery()
                DbConn.Close()
            Catch ex As Exception
                MsgBox("An Error Has Occured While Trying To Insert Your Record Into The database" & vbNewLine & Err.Description, MsgBoxStyle.Critical)
            End Try


        End If
    End Sub
    Public Function TittleCase(ByVal Value As String) As String
        Dim Capitalise As String
        If (Value = "") Then
            Capitalise = ""
        Else
            Capitalise = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Value)
        End If



        Return Capitalise
    End Function
End Module
