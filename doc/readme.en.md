[English](doc/readme.en.md) | [中文](../readme.md)

# CTG_Control

CTG_Control (Compress-Transfer-General-Control) is a Windows desktop backup controller. It compresses specified files or folders into a unified backup directory, which can then be synced by cloud storage, network drives, or other file-sync tools.

Current version: `v3.1.1`

## Core Features

- Add files or folders as backup items.
- Set a label, auto-backup flag, and backup interval for each item.
- Manually compress a single backup item.
- One-click compress all backup items.
- Automatic backup on a countdown timer after launch.
- Progress bar during compression.
- Non-blocking UI during compression — the window can be minimized.
- Force-stop an in-progress sync/compression task.
- Restore from `.rar` files in the backup directory back to the original path.
- Time-interval check to avoid redundant backups (Compression Time Detection).
- Create WinRAR self-extracting archives (SFX).
- Auto-start with Windows.
- Windows notification toggle.
- Automatic cleanup of old backup files after syncing.

## 4 Key Features in Detail

### 1. Compression Time Detection

Compression Time Detection prevents redundant backups of the same item within a short time window. Each backup item has a configurable "Backup Interval" (in hours). When enabled, the program checks whether the elapsed time since the last successful backup exceeds the configured interval. If not, the item is skipped.

**When is time detection applied?**

| Trigger | Time Check | Notes |
|---------|-----------|-------|
| Right-click → Execute single item | **No** | Manual single execution always runs |
| Menu → One-key execute all | **Yes** | Checks time for each auto-backup-enabled item |
| Auto-sync on countdown | **Yes** | Same time-check logic applies |

The time detection toggle can be found in `Settings → Judge by backup interval`.

### 2. Self-Extracting Archives (SFX)

When enabled in Settings, the generated `.rar` files become self-extracting archives. SFX files can be extracted on computers without WinRAR installed, making it easier to migrate backups.

Toggle: `Menu → Settings → Create SFX archive`.

### 3. Auto-Start with Windows

When enabled, the program registers itself in the current user's Windows startup registry (`HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run`). It will launch automatically when the user logs in. Disabling the option removes the registry entry.

Toggle: `Menu → Settings → Start with Windows`.

### 4. Auto-Sync Notifications

When enabled, a Windows notification is sent when the automatic sync countdown expires and compression is about to begin, giving the user a chance to cancel.

Toggle: `Menu → Settings → Enable notifications`.

## Environment

- Windows OS
- .NET 8 Windows Desktop Runtime / SDK
- WinRAR installed

The program locates WinRAR via the Windows registry key:

```text
SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe
```

Compression and extraction will not work without WinRAR.

## Build & Run

```bash
dotnet restore CTG_Control.sln
dotnet build CTG_Control.sln
dotnet build CTG_Control.sln -c Release
dotnet run --project CTG_Control.csproj
```

No test project exists in this repository.

## Usage

### 1. Set Backup Directory

Select a backup target directory from the top of the main window. This is where all compressed results are saved.

### 2. Add Backup Items

Use `Menu → Add Item`:

- **Label**: identifies the item, also used in the target directory name.
- **Source Path**: a file or folder.
- **Auto Backup**: whether this item participates in automatic sync.
- **Backup Interval**: used for time detection.

### 3. Execute Compression

- Select an item and use the right-click menu to compress a single item.
- Use `Menu → One-key Execute` to compress all items (with time detection).
- After launch, a countdown timer triggers automatic compression.

Compressed output path:

```text
<backup_dir>\<id>_<label>\<id>_<label>@<timestamp>.rar
```

Illegal filename characters in the label are replaced with `_`.

### 4. Progress & Force Stop

- The progress bar at the bottom shows real-time compression progress.
- `Stop Auto Sync`: cancels the countdown timer without killing running processes.
- `Force Stop`: immediately terminates the running WinRAR compression process and halts subsequent tasks.

### 5. Restore

Right-click a backup item and select Restore to pick a `.rar` file from its backup directory and extract it back to the original source path.

## Config & Data Files

```text
Resources/Config/config.ini
Resources/Data/data.txt
```

Key `config.ini` settings:

- `DefaultTargetPath` — default backup directory
- `isNotify` — enable Windows notifications
- `isTimeJudge` — enable compression time detection
- `isStartUp` — enable auto-start with Windows
- `sfx` — create self-extracting archives
- `countDownTime` — auto-sync countdown in seconds
- `shutDownTime` — auto-exit countdown in seconds
- `fastInterval` / `middleInterval` / `slowInterval` — preset backup intervals in hours

`data.txt` stores backup items in JSON format.

## Backup Item Fields

- `Id` — item ID
- `MarkName` — item label
- `SourcePath` — source file or directory
- `LatelyDate` — last backup time
- `IsAutoBack` — participates in auto-backup
- `BackInterval` — backup interval in hours
- `LastBackPast` — last backup duration in minutes

## Notes

- Windows-only: depends on WinForms, Windows registry, `kernel32` INI APIs, and WinRAR.
- Compression progress depends on parsing percentage output from `rar.exe`. Changes to WinRAR's output format may affect progress display.
- Auto-cleanup reads timestamps from backup filenames; files without recognizable timestamps are skipped.
- In dev builds, `PathService` remaps `bin/...` paths back to the project root for config/data access.
