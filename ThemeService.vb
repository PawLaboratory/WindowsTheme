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
Imports System.Runtime.InteropServices
Imports WindowsTheme.WinAPI
Imports WindowsTheme.Utilities

Public NotInheritable Class ThemeService

#Region "实用工具"

    ''' <summary>
    ''' 私有构造函数, 避免被实例化
    ''' </summary>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 判断当前设定应用主题是否为深色模式
    ''' </summary>
    ''' <returns>若是, 则返回 True, 否则返回 False</returns>
    Public Shared Function IsAppDarkMode() As Boolean
        Using regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", True)
            Return regKey.GetValue("AppsUseLightTheme", "1") = 0
        End Using
    End Function

    ''' <summary>
    ''' 判断当前设定系统主题是否为深色模式
    ''' </summary>
    ''' <returns>若是, 则返回 True, 否则返回 False</returns>
    Public Shared Function IsSystemDarkMode() As Boolean
        Using regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", True)
            Return regKey.GetValue("SystemUsesLightTheme", "1") = 0
        End Using
    End Function

    ''' <summary>
    ''' 设置标题栏颜色(仅 Windows 11 及以上生效)
    ''' </summary>
    ''' <param name="hwnd">窗口句柄</param>
    ''' <param name="r">红色值( 0 至 255 )</param>
    ''' <param name="g">绿色值( 0 至 255 )</param>
    ''' <param name="b">蓝色值( 0 至 255 )</param>
    Public Shared Sub SetTitleBarColor(ByVal hwnd As IntPtr, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        '设置标题栏与边框背景色
        Dim colorRef As Integer = RGBToCOLORREF(r, g, b)
        DwmSetWindowAttribute(hwnd, DwmWindowAttribute.CaptionColor, colorRef, Marshal.SizeOf(Of Integer)())
        DwmSetWindowAttribute(hwnd, DwmWindowAttribute.BorderColor, colorRef, Marshal.SizeOf(Of Integer)())
        '根据背景亮度决定文字颜色
        Dim textColor As Integer = If(GetForeColor(r, g, b), RGBToCOLORREF(0, 0, 0), RGBToCOLORREF(255, 255, 255))
        DwmSetWindowAttribute(hwnd, DwmWindowAttribute.TextColor, textColor, Marshal.SizeOf(Of Integer)())
    End Sub

#End Region

    ' 启动监听（注入到主窗体的 WndProc，或单独启动消息泵）
    Public Shared Sub StartListening()
    End Sub

    ' 主动刷新所有窗体
    Public Shared Sub UpdateAllForms()
    End Sub


End Class
