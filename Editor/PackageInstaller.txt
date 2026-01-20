using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager;
using System.Collections.Generic;

public class PackageInstaller : MonoBehaviour
{
    [InitializeOnLoadMethod]
    static void OnProjectLoadedInEditor()
    {
        // 检查是否已经执行过，避免重复执行
        string markerPath = Path.Combine(Application.dataPath, "Temp", "PackageInstallerExecuted.marker");
        if (!File.Exists(markerPath))
        {
            // 确保 Temp 目录存在
            string tempDir = Path.Combine(Application.dataPath, "Temp");
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            
            File.WriteAllText(markerPath, "executed");
            EditorApplication.delayCall += ExecuteInstallation;
        }
    }

    static void ExecuteInstallation()
    {
        try
        {
            // 创建目录结构
            string projectPath = Path.GetDirectoryName(Application.dataPath);
            string novaFrameworkDataPath = Path.Combine(projectPath, "NovaFrameworkData");
            string frameworkRepoPath = Path.Combine(novaFrameworkDataPath, "framework_repo");

            if (!Directory.Exists(novaFrameworkDataPath))
            {
                Directory.CreateDirectory(novaFrameworkDataPath);
                Debug.Log($"Created directory: {novaFrameworkDataPath}");
            }

            if (!Directory.Exists(frameworkRepoPath))
            {
                Directory.CreateDirectory(frameworkRepoPath);
                Debug.Log($"Created directory: {frameworkRepoPath}");
            }

            // 使用硬编码的 Git URL
            string gitUrl = "https://github.com/yoseasoft/com.novaframework.unity.installer.git";
            Debug.Log($"Using Git URL: {gitUrl}");

            // 下载第二个包
            DownloadPackageFromGit(gitUrl, frameworkRepoPath);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error during installation: {e.Message}\n{e.StackTrace}");
        }
    }

    static void DownloadPackageFromGit(string gitUrl, string targetPath)
    {
        try
        {
            // 使用 Git 命令行下载包
            string command = $"git clone \"{gitUrl}\"";
            string workingDir = targetPath;

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                WorkingDirectory = workingDir,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(startInfo))
            {
                process.WaitForExit();
                int exitCode = process.ExitCode;

                if (exitCode == 0)
                {
                    Debug.Log($"Successfully downloaded package from {gitUrl}");
                    
                    // 修改 manifest.json
                    ModifyManifestJson();
                    
                    // 等待一会儿再移除自身，确保所有操作完成
                    EditorApplication.delayCall += RemoveSelf;
                }
                else
                {
                    string error = process.StandardError.ReadToEnd();
                    Debug.LogError($"Failed to download package: {error}");
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Exception during package download: {e.Message}");
        }
    }

    static void ModifyManifestJson()
    {
        try
        {
            string manifestPath = Path.Combine(Directory.GetParent(Application.dataPath).ToString(), "Packages", "manifest.json");
            
            if (!File.Exists(manifestPath))
            {
                Debug.LogError($"manifest.json not found at: {manifestPath}");
                return;
            }

            // 读取现有的 manifest.json
            string jsonContent = File.ReadAllText(manifestPath);
            
            // 简单的字符串操作来添加依赖项
            // 找到 "dependencies" 部分并添加新的条目
            int dependenciesStart = jsonContent.IndexOf("\"dependencies\"");
            if (dependenciesStart != -1)
            {
                int openingBrace = jsonContent.IndexOf('{', dependenciesStart);
                if (openingBrace != -1)
                {
                    // 检查是否已存在相同的依赖项，避免重复添加
                    if (jsonContent.Substring(dependenciesStart, openingBrace - dependenciesStart + 200).Contains("com.novaframework.unity.installer"))
                    {
                        Debug.Log("Package dependency already exists in manifest.json");
                        return;
                    }
                    
                    int insertPosition = jsonContent.IndexOf('\n', openingBrace + 1);
                    if (insertPosition == -1) insertPosition = openingBrace + 1;
                    
                    string newEntry = "    \"com.novaframework.unity.installer\": \"file:./../NovaFrameworkData/framework_repo/com.novaframework.unity.installer\",\n";
                    string updatedJson = jsonContent.Insert(insertPosition, newEntry);
                    
                    File.WriteAllText(manifestPath, updatedJson);
                    Debug.Log("Successfully updated manifest.json with new package dependency");
                    
                    // 刷新 Unity 包管理器
                    AssetDatabase.Refresh();
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to modify manifest.json: {e.Message}");
        }
    }
    
    static void RemoveSelf()
    {
        try
        {
            // 使用 PackageManager 移除自身
            Client.Remove("com.yoseasoft.nova.main.installer");
            Debug.Log("Successfully removed self: com.yoseasoft.nova.main.installer");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to remove self: {e.Message}");
        }
    }
}