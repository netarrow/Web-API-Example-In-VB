﻿Imports BO
Imports System.Configuration
Imports Oracle.ManagedDataAccess.Client
Imports Dapper

Public Class DivisiDAL
    Implements IDisposable

    Private Function GetConnStr() As String
        Return ConfigurationManager.ConnectionStrings("OraConnectionString").ConnectionString
    End Function

    Public Function GetAllDivisi() As IEnumerable(Of Divisi)
        Using conn As New OracleConnection(GetConnStr())
            Dim strSql = "select * from Erick.Divisi order by NamaDivisi"
            Return conn.Query(Of Divisi)(strSql)
        End Using

        'Dim lstDivisi As New List(Of Divisi)
        'Using conn As New OracleConnection(GetConnStr())
        '    Dim strSql = "select * from Erick.Divisi order by NamaDivisi"
        '    Dim cmd As New OracleCommand(strSql, conn)
        '    conn.Open()

        '    Dim dr As OracleDataReader = cmd.ExecuteReader()
        '    If dr.HasRows Then
        '        While dr.Read
        '            lstDivisi.Add(New Divisi With {
        '                          .DivisiID = CInt(dr("DivisiID")),
        '                          .NamaDivisi = dr("NamaDivisi")
        '                          })
        '        End While
        '    End If
        '    dr.Close()
        '    cmd.Dispose()
        '    conn.Close()
        'End Using

        'Return lstDivisi
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub
End Class
