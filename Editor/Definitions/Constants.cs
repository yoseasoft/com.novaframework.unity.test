/// -------------------------------------------------------------------------------
/// CoreEngine Editor Framework
///
/// Copyright (C) 2025 - 2026, Hainan Yuanyou Information Technology Co., Ltd. Guangzhou Branch
///
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// -------------------------------------------------------------------------------

using System;
using UnityEngine;

namespace CoreEngine.Editor.Installer
{
    /// <summary>
    /// 框架安装器的常量定义
    /// </summary>
    public static class Constants
    {
        // 公共路径常量
        public const string GAME_CONFIGS_ROOT = "Assets/GameConfigs/";
        
        // 配置文件路径常量
        public const string FRAMEWORK_SETTING_PATH = "Assets/Editor/FrameworkInstaller/Editor Default Resources/Config/FrameworkSetting.asset";
        public const string ASSEMBLY_CONFIG_PATH = "Assets/Resources/AssemblyConfig.json"; // 修改为JSON路径
        public const string PROJECT_CONFIG_PATH = GAME_CONFIGS_ROOT + "ProjectConfig.asset";
        public const string REPO_MANIFEST_PATH = "Assets/Editor/FrameworkInstaller/Editor Default Resources/Config/repo_manifest.xml";
        public const string SAVE_PACKAGE_RELATIVE_PATH = "NovaFrameworkData/framework_repo";
        public static readonly string FRAMEWORK_REPO_PATH = Application.dataPath + "/../" + SAVE_PACKAGE_RELATIVE_PATH;
        
        // 系统变量配置路径
        public const string SYSTEM_VARIABLES_PATH = "Assets/Resources/SystemVariables.json";
        
        // 默认系统变量路径常量
        public const string ORIGINAL_RESOURCE_PATH = "Assets/_Resources";
        public const string SOURCE_CODE_PATH = "Assets/Sources";
        public const string AOT_LIBRARY_PATH = "Assets/_Resources/Aot";
        public const string LINK_LIBRARY_PATH = "Assets/_Resources/Code";
    }
}