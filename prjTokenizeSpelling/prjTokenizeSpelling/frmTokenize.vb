Public Class frmTokenize

    Dim ocn As New System.Data.OleDb.OleDbConnection
    Dim ocm As New System.Data.OleDb.OleDbCommand
    Dim ocm2 As New System.Data.OleDb.OleDbCommand
    Dim odr As System.Data.OleDb.OleDbDataReader
    Dim ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Database12.mdb;Persist Security Info=True"

    Dim alphaF As String = "ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیًٌٍَُِآـيئءأإؤةۀّْكکىيھہےّ"
    Dim alphaE As String = "abcdefghijklmnopqrstuvwxyz"
    Dim digit As String = "0123456789۰۱۲۳۴۵۶۷۸۹"
    Dim dot As String = "."

    Private Sub Tokenizer(ByVal s As String)

        Dim i As Integer
        Dim Xx As String
        Dim state As Integer = 0
        Dim token As String = ""

        s &= " "
        For i = 0 To s.Length - 1

            Xx = s.Substring(i, 1).ToLower()
            Select Case state
                Case 0
                    If (InStr(digit, Xx) > 0) Then

                        token &= Xx
                        state = 1
                    ElseIf (InStr(alphaE, Xx) > 0) Then

                        token &= Xx
                        state = 4
                    ElseIf (InStr(alphaF, Xx) > 0) Then

                        token &= Xx
                        state = 5
                    Else

                        token = ""
                        state = 0
                    End If
                Case 1
                    If (InStr(digit, Xx) > 0) Then

                        token &= Xx
                        state = 1
                    ElseIf (InStr(dot, Xx) > 0) Then

                        token &= Xx
                        state = 2
                    Else

                        saveToken(token)
                        token = ""
                        state = 0
                        i = i - 1

                    End If
                Case 2
                    If (InStr(digit, Xx) > 0) Then

                        token &= Xx
                        state = 3
                    Else

                        saveToken(token.Substring(0, token.Length - 1))
                        token = ""
                        state = 0
                        i = i - 1
                    End If
                Case 3
                    If (InStr(digit, Xx) > 0) Then

                        token &= Xx
                        state = 3
                    Else

                        saveToken(token)
                        token = ""
                        state = 0
                        i = i - 1
                    End If
                Case 4
                    If (InStr(alphaE, Xx) > 0) Then

                        token &= Xx
                        state = 4
                    Else

                        saveToken(token)
                        token = ""
                        state = 0
                        i = i - 1
                    End If
                Case 5
                    If (InStr(alphaF, Xx) > 0) Then

                        token &= Xx
                        state = 5
                    Else

                        saveToken(token)
                        token = ""
                        state = 0
                        i = i - 1
                    End If
            End Select
        Next
    End Sub
    Private Sub saveToken(ByVal s As String)

        If Not (ListBox1.Items.Contains(s)) Then
            Try

                ocm2.Connection = ocn
                ocm2.CommandText = "INSERT INTO tblTokens ([token]) Values ('" & s & "')"
                ocm2.ExecuteNonQuery()
                Application.DoEvents()
            Catch ex As Exception

            End Try
            ListBox1.Items.Add(s)
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ListBox1.Items.Clear()
        Tokenizer(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim s As String

        ListBox1.Items.Clear()
        ocn.ConnectionString = ConnString
        ocn.Open()
        ocm.Connection = ocn
        ocm.CommandText = "SELECT * FROM query2"
        odr = ocm.ExecuteReader()
        While odr.Read()

            s = odr(0).ToString
            Tokenizer(s)
            Application.DoEvents()
        End While

        ocn.Close()
        odr.Close()
        ocm.Dispose()
        ocn.Dispose()
    End Sub

    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Application.Exit()
        End
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        Try

            Label1.Text = ListBox1.SelectedIndex() + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        ListBox1.Items.Clear()
        ocn.ConnectionString = ConnString
        ocn.Open()
        Tokenizer(TextBox1.Text)
        ocn.Close()
        ocm.Dispose()
        ocn.Dispose()
    End Sub
End Class
