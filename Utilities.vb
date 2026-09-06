' WindowsTheme - A library for Windows Theme Service
' Copyright 2026 xionglongztz/PawLaboratory
'
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
'
'     http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions and
' limitations under the License.

Friend Class Utilities
    Public Shared Function RGBToCOLORREF(ByVal r As Byte, ByVal g As Byte, ByVal b As Byte) As Integer
        '0x00BBGGRR
        Return CInt(b) << 16 Or CInt(g) << 8 Or CInt(r)
    End Function
    Public Shared Function GetForeColor(ByVal r As Byte, ByVal g As Byte, ByVal b As Byte) As Boolean
        Dim brightness As Double = (0.299 * r + 0.587 * g + 0.114 * b)
        Return brightness > 128 '当背景为浅色时返回 True
    End Function
End Class
