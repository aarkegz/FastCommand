Imports System
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices


Public Class Cmd
    Public Property Name As String
    Public Property Command As String
    Public Property Args As String

    Sub New()
    End Sub

    Sub New(ByVal name As String, ByVal command As String, ByVal args As String)
        Me.Name = name
        Me.Command = command
        Me.Args = args
    End Sub

    Shared Function FromText(ByVal reader As IO.BinaryReader) As Cmd()
        Try
            Dim rv As New List(Of Cmd)()
            Dim count = reader.ReadInt32()
            Dim tempsa As String, tempsb As String, tempsc As String

            For i As Integer = 1 To count
                Try
                    tempsa = reader.ReadString
                    tempsb = reader.ReadString
                    tempsc = reader.ReadString

                    rv.Add(New Cmd(tempsa, tempsb, tempsc))
                Catch ex As Exception
                End Try
            Next i

            Return rv.ToArray()
        Catch ex As Exception
            Return {}
        End Try
    End Function
End Class

Module Cmd_Extension
    <Extension()> Sub ToText(ByRef arr As Cmd(), ByRef writer As System.IO.BinaryWriter)
        Dim count = arr.Length

        writer.Write(count)
        For Each i In arr
            writer.Write(i.Name)
            writer.Write(i.Command)
            writer.Write(i.Args)
        Next i
    End Sub

End Module