Public Class frmSpelling

    Dim ocn As New System.Data.OleDb.OleDbConnection
    Dim ocm As New System.Data.OleDb.OleDbCommand
    Dim ocm2 As New System.Data.OleDb.OleDbCommand
    Dim odr As System.Data.OleDb.OleDbDataReader
    Dim ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Database12.mdb;Persist Security Info=True"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dist As Integer = 0
        Dim cFind As Boolean
        Dim t As String
        Dim ed As Integer

        ListBox1.Items.Clear()
        ocn.ConnectionString = ConnString
        ocn.Open()
        'ocm2.Connection = ocn
        'ocm2.CommandText = "SELECT * FROM tblTokens where token='" & TextBox1.Text & "'"
        'odr = ocm2.ExecuteReader()
        'If (odr.Read()) Then

        'ListBox1.Items.Add(" -- ")
        'Else
        cFind = False

        Dim tText As String = TextBox1.Text
        Dim MaxSearch = 0
        Select Case tText.Length()

            Case > 5
                MaxSearch = 3
            Case 5, 4, 3
                MaxSearch = 2
            Case 2
                MaxSearch = 1
            Case 1
                MaxSearch = 0
        End Select

        While Not (cFind)

            ocm.Connection = ocn
            ocm.CommandText = "SELECT * FROM tblTokens"
            odr = ocm.ExecuteReader()
            While odr.Read()

                t = odr(0).ToString
                    ed = CalcEditDistance(tText, t)
                    If ed <= dist Then

                    ListBox1.Items.Add(t)
                    cFind = True
                End If
                Application.DoEvents()
            End While
            If Not (cFind) Then

                If dist < MaxSearch Then

                    dist = dist + 1
                Else

                    cFind = True
                    ListBox1.Items.Add(" Nothing Found!!! ")
                End If
                odr.Close()
            End If
        End While
        'End If
        ocn.Close()
        odr.Close()
        ocm.Dispose()
        ocm2.Dispose()
        ocn.Dispose()
    End Sub

    Private Function CalcEditDistance(ByVal s As String, ByVal t As String)

        Dim sLen As Integer = s.Length
        Dim tLen As Integer = t.Length
        Dim i, j As Integer
        Dim Ins, Del, Upd As Integer
        Dim dMatrix(sLen, tLen) As Integer

        For i = 0 To sLen

            dMatrix(i, 0) = i
        Next
        For i = 0 To tLen

            dMatrix(0, i) = i
        Next
        For j = 1 To tLen
            For i = 1 To sLen

                Ins = dMatrix(i, j - 1) + 1
                Del = dMatrix(i - 1, j) + 1
                If (s.Substring(i - 1, 1) = t.Substring(j - 1, 1)) Then

                    Upd = dMatrix(i - 1, j - 1)
                Else

                    Upd = dMatrix(i - 1, j - 1) + 1
                End If
                dMatrix(i, j) = Min(Ins, Del, Upd)
            Next
        Next
        CalcEditDistance = dMatrix(sLen, tLen)
    End Function

    Private Function Min(ByVal i As Integer, ByVal j As Integer, ByVal k As Integer)

        Min = i
        If j < Min Then Min = j
        If k < Min Then Min = k
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        MessageBox.Show(CalcEditDistance(TextBox2.Text, TextBox3.Text))
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged


    End Sub
End Class
