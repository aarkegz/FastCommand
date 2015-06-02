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

''' <summary> This Module contains the help text. </summary>
Module MdlHelpText
    Public helpText As String = _
        "FastCommand, A small helpful program to call other programs" & vbCrLf & _
        "FastCommand is a free software under GNU LGPL v3.0" & vbCrLf & _
        "Copyright (C) 2015  BenjaminPMLee @ Gemini Laboratory" & vbCrLf & _
        "" & vbCrLf & _
        "Usage :" & vbCrLf & _
        "a. show this help text." & vbCrLf & _
        "    fastc [-h|-help|-?]" & vbCrLf & _
        "b. register a new command." & vbCrLf & _
        "    fastc -r|-reg name command [args...]" & vbCrLf & _
        "c. delete a registered command." & vbCrLf & _
        "    fastc -d|-del name" & vbCrLf & _
        "d. run a command." & vbCrLf & _
        "    fastc [-w|-wait] [-b] name [args...]" & vbCrLf & _
        "  1. if -w is set, FastCommand will wait your program to exit." & vbCrLf & _
        "  2. if -b is set, args defined when registering will be disabled." & vbCrLf & _
        "  3. if -b is not set and ""args..."" is provided, args defined here" & vbCrLf & _
        "     will be append to args defined when registering." & vbCrLf & _
        "" '& vbCrLf

    Public Sub PrintHelpInfo()
        Console.WriteLine(helpText)
    End Sub
End Module
