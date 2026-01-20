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
using System.Collections.Generic;
using UnityEngine;

namespace CoreEngine.Editor.Installer
{
    [Serializable]
    public class AssemblyDefinitionConfig
    {
        public string name = "Nova.Library";
        public int order = 1;
        public List<string> tagNames = new List<string>(); // 使用字符串列表代替枚举
        public int tagMask = 0; // 位标志掩码，用于存储标签的位标志值
    }
    
    // 用于JSON序列化/反序列化的简单类，避免跨目录引用问题
    [Serializable]
    public class SimpleAssemblyConfigData
    {
        public List<SimpleAssemblyDefinitionConfig> assemblyConfigs = new List<SimpleAssemblyDefinitionConfig>();
    }
    
    [Serializable]
    public class SimpleAssemblyDefinitionConfig
    {
        public string name;
        public int order;
        public List<string> tagNames = new List<string>();
        public int tagMask = 0;
    }
}