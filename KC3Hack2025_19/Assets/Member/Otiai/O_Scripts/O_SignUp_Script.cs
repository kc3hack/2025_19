using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using UnityEngine.Networking;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class SignUp_Script : MonoBehaviour
{
    private string flaskUrl = "http://127.0.0.1:5000/signup";

    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI passwordText;

    IEnumerator SendDataToFlask()
    {
        // 送信するJSONデータ
        User user = new User();
        user.username = usernameText.text;
        user.password = passwordText.text;
        string jsonData = JsonUtility.ToJson(user);
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);

        // HTTPリクエスト作成
        using (UnityWebRequest request = new UnityWebRequest(flaskUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            // レスポンスを取得 ここでログインの可否を判定し、シーンの遷移を行う
            if (request.result == UnityWebRequest.Result.Success)
            {
                Status loginStatus = JsonUtility.FromJson<Status>(request.downloadHandler.text);
                if (loginStatus.status == "success")
                {
                    Debug.Log("Response: " + request.downloadHandler.text);
                    SceneManager.LoadScene("LogInScene");
                }
                if (loginStatus.status == "failed")
                {
                    Debug.LogError("Request Failed: " + request.error);
                }
            }
            else
            {
                Debug.LogError("Request Failed: " + request.error);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Signup()
    {
        StartCoroutine(SendDataToFlask());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}