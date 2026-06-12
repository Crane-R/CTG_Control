[English](doc/readme.en.md) | [中文](readme.md)

# CTG_Control

CTG_Control（Compress-Transfer-General-Control，压缩备份中心）是一个 Windows 桌面备份控制程序。它用于把指定的文件或文件夹压缩到统一的备份库目录中，适合配合网盘、同步盘或其他文件同步工具对备份库目录进行二次同步。

当前版本：`v3.1.1`

## 主要功能

- 添加文件或文件夹作为备份项。
- 为每个备份项设置标识名、是否自动备份、自动备份间隔。
- 手动执行单个备份项压缩。
- 一键执行全部备份项压缩。
- 启动后按倒计时自动执行启用自动备份的项目。
- 压缩时在主界面显示进度条。
- 压缩执行过程中界面不阻塞，可以最小化窗口。
- 支持强制终止正在执行的同步/压缩任务。
- 支持从备份库中的 `.rar` 文件还原覆盖原路径。
- 支持按时间间隔判断是否需要再次备份。
- 支持创建 WinRAR 自解压包（SFX）。
- 支持开机自启动配置。
- 支持 Windows 通知开关。
- 自动同步后会按规则清理旧备份文件。

## 运行环境

- Windows 系统。
- .NET 8 Windows Desktop Runtime / SDK。
- WinRAR 已安装。

程序通过 Windows 注册表查找 WinRAR：

```text
SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe
```

如果没有安装 WinRAR，压缩和解压功能无法执行。

## 构建与运行

在仓库根目录执行：

```bash
# 还原依赖
dotnet restore CTG_Control.sln

# 构建 Debug 版本
dotnet build CTG_Control.sln

# 构建 Release 版本
dotnet build CTG_Control.sln -c Release

# 运行程序
dotnet run --project CTG_Control.csproj
```

项目当前没有测试工程，因此没有可执行的 `dotnet test` 单测命令。

## 使用说明

### 1. 设置备份库目录

主界面顶部可以选择备份库路径。备份库是所有压缩结果的保存位置。

备份库目录名可以包含 `.`，程序会按完整路径处理，不会因为目录名中的点号截断路径。

### 2. 添加备份项

通过菜单 `功能 -> 添加项` 添加备份项：

- 标识名：用于区分备份项，也会参与生成目标目录名。
- 源路径：可以是文件，也可以是文件夹。
- 是否自动备份：决定自动同步时是否执行该项。
- 备份间隔：用于时间判断。

### 3. 执行压缩

- 在主表格中选中备份项后，通过右键菜单执行单项压缩。
- 通过 `功能 -> 一键执行` 执行全部备份项。
- 程序启动后会按配置的倒计时自动执行启用自动备份的项目。

压缩结果保存到：

```text
备份库目录\备份项ID_备份项标识名\备份项ID_备份项标识名@时间戳.rar
```

例如：

```text
D:\Backup\3_工作文档\3_工作文档@20260613123045.rar
```

如果标识名包含 Windows 文件名非法字符，会自动替换为 `_`。

### 4. 压缩进度与终止

主界面底部显示压缩进度条，位于“终止自动同步”按钮左侧，并且始终显示。

- `终止自动同步`：停止自动同步倒计时，不强制杀死正在运行的压缩进程。
- `强制终止同步`：立即强制终止当前正在执行的 WinRAR 压缩进程，并停止后续同步任务。

### 5. 还原备份

在主表格中选中备份项后，通过右键菜单的还原功能，可以从该备份项对应目录中选择 `.rar` 文件并解压覆盖回源路径所在目录。

## 配置与数据文件

程序使用本地文件保存配置和备份项数据：

```text
Resources/Config/config.ini
Resources/Data/data.txt
```

`config.ini` 主要配置项包括：

- `DefaultTargetPath`：默认备份库目录。
- `CurrentDataCount`：当前备份项数量。
- `NextId`：下一个备份项 ID。
- `isNotify`：是否启用通知。
- `isTimeJudge`：是否按备份间隔判断执行。
- `isStartUp`：是否开机自启动。
- `sfx`：是否创建自解压包。
- `countDownTime`：启动后自动同步倒计时秒数。
- `shutDownTime`：自动同步完成后退出倒计时秒数。
- `fastInterval` / `middleInterval` / `slowInterval`：预设备份间隔小时数。

`data.txt` 使用 JSON 保存备份项列表。

## 备份项字段

每个备份项包含：

- `Id`：备份项 ID。
- `MarkName`：备份项标识名。
- `SourcePath`：源文件或源目录路径。
- `LatelyDate`：最近一次备份时间。
- `IsAutoBack`：是否参与自动备份。
- `BackInterval`：自动备份间隔，单位为小时。
- `LastBackPast`：上次备份耗时，单位为分钟。

## 注意事项

- 本项目是 Windows 专用程序，依赖 WinForms、Windows 注册表、`kernel32` INI API 和 WinRAR。
- 压缩进度来自 `rar.exe` 控制台输出中的百分比；如果 WinRAR 输出格式变化，进度显示可能受影响。
- 自动清理会读取备份文件名中的时间戳，无法识别时间戳的文件会跳过。
- 开发环境运行时，`PathService` 会把 `bin/...` 路径映射回项目根目录，以便读取 `Resources` 下的配置和数据。
