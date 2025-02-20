using System.Diagnostics;
using System.IO;
using UnityEngine;

public class PythonServerManager_script : MonoBehaviour
{
    private Process serverProcess;

    void Start()
    {
        RunPython();
    }

    void RunPython()
    {
        // Python仮想環境のパスを取得
        string projectPath = Application.dataPath; // Unityの `Assets` フォルダのパス
        string venvPython;

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            venvPython = Path.Combine(projectPath, "StreamingAssets", "venv", "Scripts", "python.exe"); // Windowsの仮想環境
        }
        else
        {
            venvPython = Path.Combine(projectPath, "StreamingAssets", "venv", "bin", "python"); // Mac/Linuxの仮想環境
        }

        // 実行するPythonスクリプトのパス
        string scriptPath = Path.Combine(projectPath, "Scripts", "Unity_flask.py");

        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = venvPython; // 仮想環境内のPythonを指定
        psi.Arguments = $"\"{scriptPath}\""; // スクリプトのパス
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;

        Process process = new Process();
        process.StartInfo = psi;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();
        process.Close();

        UnityEngine.Debug.Log("Python Output: " + output);
        if (!string.IsNullOrEmpty(error))
        {
            UnityEngine.Debug.LogError("Python Error: " + error);
        }
    }
    void OnApplicationQuit()
    {
        StopServer();
    }

    void StopServer()
    {
        if (serverProcess != null && !serverProcess.HasExited)
        {
            serverProcess.Kill();
            serverProcess.WaitForExit();
            serverProcess.Dispose();
            UnityEngine.Debug.Log("Pythonサーバーを停止しました。");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
