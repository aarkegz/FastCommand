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

''' <summary> Main Module. </summary>
Module Mdl_Main
    ''' <summary>  </summary>
    Private Sub Run()

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
        Dim cmdStart As Integer
        Dim argCount = args.Length
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

        If swtRegister Then 'register
        ElseIf swtDelete Then 'delete
        ElseIf swtHelp Then 'Print help infomation
        Else 'Run

        End If

    End Sub
End Module
