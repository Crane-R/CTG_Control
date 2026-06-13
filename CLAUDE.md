# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

CTG_Control (Compress-Transfer-General-Control) is a Windows Forms backup controller. It lets users configure source files or directories, compress them to a target backup directory, optionally create WinRAR self-extracting archives, run automatic backups on an interval, show Windows notifications, and register the app for Windows startup.

The application targets `net8.0-windows`, uses Windows Forms, and depends on `Newtonsoft.Json`. WinRAR is an external runtime dependency: compression/decompression code locates `rar.exe` through the Windows registry key for `WinRAR.exe`.

## Common commands

Run commands from the repository root.

```bash
# Restore NuGet packages
dotnet restore CTG_Control.sln

# Build debug configuration
dotnet build CTG_Control.sln

# Build release configuration
dotnet build CTG_Control.sln -c Release

# Run the Windows Forms application
dotnet run --project CTG_Control.csproj

# Format C# code if dotnet-format is available
dotnet format CTG_Control.sln
```

There is currently no test project in this repository, so `dotnet test` has nothing to run and there is no single-test command yet.

## Architecture

- `Program.cs` is the WinForms entry point and opens `MainForm`.
- `Crane/view/` contains the UI forms. Designer files define controls; code-behind files contain event handlers and UI orchestration.
  - `MainForm` is the main control panel. It loads configured backup items into the table, starts the countdown thread, executes one-item or all-item compression, handles restore/delete actions, and writes target-path changes back to config.
  - `AddForm` creates `CompressItem` records for source files/directories and persists them through `DataDao`.
  - `SettingForm` toggles config-driven behavior such as notifications, time-interval checks, startup registration, and SFX archives.
  - `DetailMore` edits per-item details such as automatic backup settings.
- `Crane/Model/Bean/CompressItem.cs` is the persisted backup-item model. It is serialized with Newtonsoft.Json.
- `Crane/Model/Dao/DataDao.cs` is the persistence layer for backup items. It reads and writes JSON in `Resources/Data/data.json` and also updates ID counters in config.
- `Crane/Service/` contains application services:
  - `CompressService` wraps WinRAR command-line compression/decompression and updates backup timestamps.
  - `ConfigService` reads/writes `Resources/Config/config.ini` using Windows INI APIs from `kernel32`.
  - `PathService` resolves the application root differently for development builds under `bin` versus deployed runs.
  - `StartUpService` writes/removes the current user's `Run` registry entry for startup launch.
  - `DeleteService`, `FileCountService`, `IdService`, and `BackIntervalTool` support retention cleanup, size formatting/counting, ID generation, and interval presets.
- `Resources/Config/config.ini` stores application settings such as target path, ID counters, notification/time-judge/startup/SFX flags, countdown/shutdown timers, and interval defaults.
- `Resources/Data/data.json` stores the list of configured backup items as JSON.

## Important implementation notes

- This is a Windows-only application because it uses WinForms, Windows registry APIs, `kernel32` INI functions, and WinRAR registry lookup.
- The source contains Chinese UI text. Some existing files show mojibake in comments/strings; avoid broad encoding rewrites unless the task is specifically about text encoding.
- `PathService.GetApplicationPath()` intentionally maps development runs from `bin/...` back to the repository/application root so config and data files are read from `Resources/...`.
- The WinForms designer owns `*.Designer.cs` and `*.resx` files. Prefer changing form behavior in the code-behind unless the task requires UI layout/control changes.
