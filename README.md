# WindowsTheme

A lightweight .NET library for managing Windows theme settings, including dark/light mode detection, window title bar color customization, and per-window theme application. Designed for Windows 10 and Windows 11 (with full DWM API support).

## License

Copyright 2026 xionglongztz/PawLaboratory

Licensed under the Apache License, Version 2.0 (the "License");  
you may not use this file except in compliance with the License.  
You may obtain a copy of the License at

[http://www.apache.org/licenses/LICENSE-2.0](http://www.apache.org/licenses/LICENSE-2.0)

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.

## Features

- Detect whether the **system** or **application** is set to dark mode via registry queries.
- Set custom **title bar** and **border** colors on Windows 11 (and newer) using DWM attributes.
- Automatically choose title bar text color (black or white) based on background brightness.
- Apply dark or light theme to a specific window (including immersive dark mode and menu theme flushing).
- Simple, static API 每 no instantiation required.

## Installation

Add the source files to your project, or reference the compiled assembly. The library has no external dependencies beyond the .NET Framework / .NET Core / .NET 5+ runtime that supports `System.Runtime.InteropServices` and `Microsoft.Win32`.

## Usage Examples

### VB.NET

```vbnet
Imports PawLab.WindowsTheme

' Check current system dark mode
Dim isSystemDark As Boolean = ThemeService.IsSystemDarkMode()
Console.WriteLine($"System dark mode: {isSystemDark}")

' Check app (modern UI) dark mode
Dim isAppDark As Boolean = ThemeService.IsAppDarkMode()
Console.WriteLine($"App dark mode: {isAppDark}")

' Set title bar color for a window (e.g., main form handle)
Dim hwnd As IntPtr = Me.Handle   ' or any window handle
ThemeService.SetTitleBarColor(hwnd, 30, 144, 255)   ' Dodger blue

' Apply dark theme to the window
ThemeService.SetWindowTheme(hwnd, True)
```

### C#

```csharp
using PawLab.WindowsTheme;

// Check current system dark mode
bool isSystemDark = ThemeService.IsSystemDarkMode();
Console.WriteLine($"System dark mode: {isSystemDark}");

// Check app (modern UI) dark mode
bool isAppDark = ThemeService.IsAppDarkMode();
Console.WriteLine($"App dark mode: {isAppDark}");

// Set title bar color for a window (e.g., main form handle)
IntPtr hwnd = this.Handle;   // or any window handle
ThemeService.SetTitleBarColor(hwnd, 30, 144, 255);   // Dodger blue

// Apply dark theme to the window
ThemeService.SetWindowTheme(hwnd, true);
```

## API Reference

### `ThemeService` (Public Static Class)

#### `IsAppDarkMode() As Boolean`  
Returns `True` if the current user setting for application theme (AppsUseLightTheme) is dark (value = 0), otherwise `False`.

#### `IsSystemDarkMode() As Boolean`  
Returns `True` if the current user setting for system theme (SystemUsesLightTheme) is dark (value = 0), otherwise `False`.

#### `SetTitleBarColor(hwnd As IntPtr, r As Byte, g As Byte, b As Byte)`  
Sets the title bar and border background color for the given window handle. The text color is automatically chosen (black on light background, white on dark background) based on the perceived brightness.  
*Note:* This feature is fully effective only on Windows 11 and later.

#### `SetWindowTheme(hwnd As IntPtr, Optional isDarkMode As Boolean = False)`  
Applies immersive dark or light mode to the specified window. Also updates menu themes and flushes them to take effect immediately.  
- `isDarkMode = True` ↙ force dark mode  
- `isDarkMode = False` (default) ↙ force light mode

---

### Internal Helper Classes (not intended for direct use)

- **`WinAPI`** 每 P/Invoke declarations for `DwmSetWindowAttribute`, `SetPreferredAppMode`, `FlushMenuThemes`, and related enums.
- **`Utilities`** 每 Color conversion (`RGBToCOLORREF`) and brightness calculation (`GetForeColor`).

## Requirements

- Windows 10 or later (some features like title bar color are Windows 11 only).
- .NET Framework 4.5+ or .NET Core/5/6/7/8.

## Remarks

- Registry keys are read from `HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize`.  
- The library uses `DwmSetWindowAttribute` with attribute IDs (e.g., `UseImmersiveDarkMode = 20`, `CaptionColor`, `BorderColor`, `TextColor`).  
- Title bar color changes may not be visible if the window is using custom chrome or if the system theme overrides certain settings.

## Contributing

Contributions are welcome. Please open an issue or pull request on the official repository.

## License

Apache 2.0 每 see the LICENSE file for details.