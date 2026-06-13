# CTG_Control 打包指南 / Packaging Guide

## 概述 / Overview

本指南说明如何将 CTG_Control 打包为单个 `.exe` 安装文件。
输出是一个 WinRAR 自解压（SFX）档案，包含完整的自包含应用程序和资源文件。
用户运行安装程序后，选择解压目录即可获得可运行的应用程序。

## 前置条件 / Prerequisites

| 工具 | 用途 | 验证命令 |
|------|------|----------|
| .NET 8 SDK | 编译发布 | `dotnet --version` (需 ≥ 8.0) |
| WinRAR | 创建 SFX | 检查 `D:\Software\WinRAR\WinRAR.exe` 或注册表 `HKLM\SOFTWARE\WinRAR` |

## 打包步骤 / Packaging Steps

### 步骤 1：重置数据文件至初始状态

打包前必须将 `Resources/` 目录下的配置和数据文件还原为默认值，确保用户拿到的是干净的初始程序。

**`Resources/Config/config.ini`** — 初始内容：
```ini
[system]
CloudTargetPath=
LocalTargetPath=
CurrentDataCount=0
NextId=0
isNotify=0
isTimeJudge=1
isStartUp=0
sfx=0
countDownTime=30
shutDownTime=20
notificationText=备份执行同步
fastInterval=24
middleInterval=48
slowInterval=72
totalLastPast=0
```

**`Resources/Data/data.json`** — 初始内容：
```json
[]
```

### 步骤 2：发布应用程序

```bash
dotnet publish CTG_Control.csproj \
  -c Release \
  -r win-x64 \
  --self-contained \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true \
  -o output/publish
```

参数说明：
- `-c Release`：发布模式
- `-r win-x64`：目标平台 Windows x64
- `--self-contained`：包含 .NET 运行时，目标机器无需安装 .NET
- `-p:PublishSingleFile=true`：将托管程序集打包为单个 exe
- `-o output/publish`：发布输出目录

### 步骤 3：复制资源文件到发布目录

```bash
mkdir -p output/publish/Resources/Config
mkdir -p output/publish/Resources/Data  
mkdir -p output/publish/Resources/img

cp Resources/Config/config.ini output/publish/Resources/Config/
cp Resources/Data/data.json output/publish/Resources/Data/
cp -r Resources/img/* output/publish/Resources/img/
```

### 步骤 4：删除调试符号文件（可选）

```bash
rm -f output/publish/*.pdb
```

### 步骤 5：创建 SFX 自解压安装程序

首先创建 SFX 配置文件 `sfx_config.txt`：

```
;The comment below contains SFX script commands

Setup=CTG_Control.exe
Overwrite=1
Title=CTG Control 安装向导
```

然后执行 WinRAR 命令：

```bash
WINRAR_PATH="D:/Software/WinRAR/WinRAR.exe"
cd output
"$WINRAR_PATH" a -sfx -z"sfx_config.txt" -ep1 -r "CTG_Control_Setup ${VERSION}.exe" "publish/*"
```

参数说明：
- `-sfx`：创建自解压档案
- `-z"sfx_config.txt"`：附加 SFX 脚本命令
- `-ep1`：去除基础路径前缀
- `-r`：递归包含子目录

### 步骤 6：清理临时文件

```bash
rm -rf output/publish output/sfx_config.txt
```

## 一键打包脚本（完整版）

将以上步骤整合为以下脚本，放在仓库根目录执行：

```bash
#!/bin/bash
set -e

# ==================== CTG_Control 打包脚本 ====================

WINRAR="D:/Software/WinRAR/WinRAR.exe"
OUTPUT_DIR="output"
PUBLISH_DIR="$OUTPUT_DIR/publish"
VERSION=$(grep -oP 'VERSION\s*=\s*"\K[^"]+' Crane/Constant/Constants.cs)  # 从 Constants.cs 取版本号
SETUP_NAME="CTG_Control_Setup ${VERSION}.exe"

echo "[1/5] 重置数据文件至初始状态..."
cat > Resources/Config/config.ini << 'INIEOF'
[system]
CloudTargetPath=
LocalTargetPath=
CurrentDataCount=0
NextId=0
isNotify=0
isTimeJudge=1
isStartUp=0
sfx=0
countDownTime=30
shutDownTime=20
notificationText=备份执行同步
fastInterval=24
middleInterval=48
slowInterval=72
totalLastPast=0
INIEOF

echo "[]" > Resources/Data/data.json

echo "[2/5] 发布应用程序..."
dotnet publish CTG_Control.csproj \
  -c Release \
  -r win-x64 \
  --self-contained \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true \
  -o "$PUBLISH_DIR"

echo "[3/5] 复制资源文件..."
mkdir -p "$PUBLISH_DIR/Resources/Config"
mkdir -p "$PUBLISH_DIR/Resources/Data"
mkdir -p "$PUBLISH_DIR/Resources/img"
cp Resources/Config/config.ini "$PUBLISH_DIR/Resources/Config/"
cp Resources/Data/data.json "$PUBLISH_DIR/Resources/Data/"
cp -r Resources/img/* "$PUBLISH_DIR/Resources/img/"
rm -f "$PUBLISH_DIR"/*.pdb

echo "[4/5] 创建 SFX 安装程序..."
cat > "$OUTPUT_DIR/sfx_config.txt" << 'SFXEOF'
;The comment below contains SFX script commands

Setup=CTG_Control.exe
Overwrite=1
Title=CTG Control 安装向导
SFXEOF

cd "$OUTPUT_DIR"
"$WINRAR" a -sfx -z"sfx_config.txt" -ep1 -r "$SETUP_NAME" "publish/*"
cd ..

echo "[5/5] 清理临时文件..."
rm -rf "$PUBLISH_DIR" "$OUTPUT_DIR/sfx_config.txt"

echo ""
echo "============================================"
echo "  打包完成！"
echo "  输出文件: $OUTPUT_DIR/$SETUP_NAME"
echo "============================================"
```

## 安装程序行为 / Installer Behavior

运行 `CTG_Control_Setup.exe` 后：

1. 显示解压对话框，用户选择目标目录（默认当前目录）
2. 解压所有文件到目标目录：
   - `CTG_Control.exe` — 主程序
   - `Resources/Config/config.ini` — 配置文件
   - `Resources/Data/data.json` — 数据文件
   - `Resources/img/` — 图标和图片资源
3. 解压完成后自动启动 `CTG_Control.exe`

## 目录结构（安装后）/ Installed Directory Structure

```
安装目录/
├── CTG_Control.exe          # 主程序（自包含，含 .NET 运行时）
└── Resources/
    ├── Config/
    │   └── config.ini       # 应用配置
    ├── Data/
    │   └── data.json        # 备份项数据
    └── img/
        ├── aq1zt-7d7nq-001256.ico
        ├── acn9u-0l1s8-001.ico
        ├── azhb3-bem61-001.ico
        ├── PNG 02 (22).png
        └── 微信图片_20240908210853.png
```

## 注意事项 / Notes

1. **WinRAR 是运行时依赖**：程序运行需要 WinRAR 安装在目标机器上（用于压缩/解压功能），但打包过程本身不需要 WinRAR 在目标机器上。
2. **目标平台**：当前打包仅针对 `win-x64`。如需支持其他架构，修改 `-r` 参数。
3. **文件路径**：程序通过 `Application.StartupPath` 定位 Resources 目录，因此 Resources 文件夹必须与 exe 位于同一目录。
4. **配置文件编码**：config.ini 使用系统默认编码（Windows INI API 要求），data.json 使用 UTF-8。
5. **不要包含 .pdb 文件**：调试符号文件会增加体积且无实际用途。
