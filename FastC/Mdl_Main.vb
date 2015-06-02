'FastCommand
'Copyright (C) 2015  BenjaminPMLee @ Gemini Laboratory

'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU Lesser General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.

'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.

'You should have received a copy of the GNU Lesser General Public License
'along with this program.  If not, see <http://www.gnu.org/licenses/>.

'For the copy of the GNU General Public License, visit <http://www.gnu.org/licenses/>.

Imports System.IO
''' <summary> Main Module. </summary>
Module Mdl_Main
    Private Const PATH = "./cmd.bin"

    Private cmds As Cmd() = {}
    Private Sub ReadCmds()
        Dim bnr As BinaryReader = Nothing
        Dim fst As FileStream = Nothing
        Try
            fst = New FileStream(PATH, FileMode.Open, FileAccess.Read)
            bnr = New BinaryReader(fst)
            cmds = Cmd.FromText(bnr)
            fst.Close()
        Catch ex As Exception
            cmds = {}
            If fst IsNot Nothing Then
                fst.Close()
            End If
        End Try
    End Sub

    Private Sub SaveCmds()
        Dim bnw As BinaryWriter = Nothing
        Dim fst As FileStream = Nothing
        Try
            fst = New FileStream(PATH, FileMode.Open, FileAccess.Read)
            bnw = New BinaryWriter(fst)
            cmds.ToText(bnw)
            fst.Flush()
            fst.Close()
        Catch ex As Exception
            If fst IsNot Nothing Then
                fst.Close()
            End If
        End Try
    End Sub

    Private Sub Register(ByVal param() As String)

    End Sub

    Private Sub Delete(ByVal param() As String)

    End Sub

    Private Sub Run(ByVal param() As String)

    End Sub

    '' Switches
    Dim swtHelp As Boolean = False, swtRegister As Boolean = False, swtDelete As Boolean = False
    Dim swtWait As Boolean = False, swtBan As Boolean = False

    '' Process args
    Public Function isArg(ByVal str As String) As Boolean
        Return str(0) = "-"
    End Function

    Public Function processArg(ByVal str As String) As Boolean
        str = str.ToLower()
        Select Case str
            Case "-h", "-help", "-?"
                swtHelp = True
            Case "-r", "-reg"
                swtRegister = True
            Case "-d", "-del"
                swtDelete = True
            Case "-w", "-wait"
                swtWait = True
            Case "-b"
                swtBan = True
            Case Else
                Return False
        End Select
        Return True
    End Function

    Public Function checkArgs() As Boolean
        Dim temp = 0
        If swtHelp Then temp += 1
        If swtDelete Then temp += 1
        If swtRegister Then temp += 1

        If temp >= 2 Then Return False
        If temp = 1 And (swtWait Or swtBan) Then Return False

        Return True
    End Function

    '''<summary> Main function </summary>
    Public Sub Main(ByVal args() As String)
        If args.Length = 0 Then
            MdlHelpText.PrintHelpInfo() : Return
        End If

        'Enumerate switches
        Dim cmdStart As Integer = -1
        Dim argCount As Integer = args.Length
        For i As Integer = 0 To argCount - 1
            If Not isArg(args(i)) Then
                cmdStart = i
                Exit For
            Else
                If Not processArg(args(i)) Then 'Error
                    Console.WriteLine("Fatal error : invalid arg {0}", args(i))
                    Return
                End If
            End If
        Next i

        If Not checkArgs() Then
            Console.WriteLine("Fatal error : invalid args")
            Return
        End If

        If swtHelp Then
            MdlHelpText.PrintHelpInfo() : Return
        End If

        If cmdStart = -1 Then
            Console.WriteLine("Fatal error : no command name")
        End If

        Dim temp As String() = Array.CreateInstance("".GetType, argCount - cmdStart)
        Array.Copy(args, cmdStart, temp, 0, argCount - cmdStart)

        ReadCmds()

        If swtRegister Then 'register

        ElseIf swtDelete Then 'delete

        Else 'Run

        End If

        SaveCmds()
    End Sub
End Module
