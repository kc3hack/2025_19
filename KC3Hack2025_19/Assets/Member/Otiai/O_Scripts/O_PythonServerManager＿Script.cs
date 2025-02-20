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
        // Python���z���̃p�X���擾
        string projectPath = Application.dataPath; // Unity�� `Assets` �t�H���_�̃p�X
        string venvPython;

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            venvPython = Path.Combine(projectPath, "StreamingAssets", "venv", "Scripts", "python.exe"); // Windows�̉��z��
        }
        else
        {
            venvPython = Path.Combine(projectPath, "StreamingAssets", "venv", "bin", "python"); // Mac/Linux�̉��z��
        }

        // ���s����Python�X�N���v�g�̃p�X
        string scriptPath = Path.Combine(projectPath, "Scripts", "Unity_flask.py");

        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = venvPython; // ���z������Python���w��
        psi.Arguments = $"\"{scriptPath}\""; // �X�N���v�g�̃p�X
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
            UnityEngine.Debug.Log("Python�T�[�o�[���~���܂����B");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
