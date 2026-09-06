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

Friend Class WinAPI

    'SetPreferredAppMode函数 - 设置应用程序首选主题模式
    <DllImport("uxtheme.dll", EntryPoint:="#135", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Public Shared Function SetPreferredAppMode(ByVal PreferredAppMode As PreferredAppMode) As Long
        '修改菜单颜色
    End Function
    'FlushMenuThemes函数 - 刷新菜单主题
    <DllImport("uxtheme.dll", EntryPoint:="#136", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Public Shared Function FlushMenuThemes() As Long
        '修改菜单颜色
    End Function
    Public Enum PreferredAppMode
        _default
        AllowDark
        ForceDark
        ForceLight
        Max
    End Enum
    'DwmSetWindowAttribute函数 - 设置桌面窗口管理器(DWM)属性
    <DllImport("DwmApi.dll", EntryPoint:="DwmSetWindowAttribute", SetLastError:=True)>
    Public Shared Function DwmSetWindowAttribute(
        ByVal hwnd As IntPtr,
        ByVal attr As DwmWindowAttribute,
        ByRef attrValue As Integer,
        ByVal attrSize As Integer
    ) As Integer
    End Function
    Public Enum DwmWindowAttribute
        NCRenderingEnabled = 1
        NCRenderingPolicy
        TransitionsForceDisabled
        AllowNCPaint
        CaptionButtonBounds
        NonClientRtlLayout
        ForceIconicRepresentation
        Flip3DPolicy
        ExtendedFrameBounds
        HasIconicBitmap
        DisallowPeek
        ExcludedFromPeek
        Cloak
        Cloaked
        FreezeRepresentation
        PassiveUpdateMode
        UseHostBackdropBrush
        UseImmersiveDarkMode = 20
        WindowCornerPreference = 33
        BorderColor
        CaptionColor
        TextColor
        VisibleFrameBorderThickness
        SystemBackdropType
        Last
    End Enum

End Class
