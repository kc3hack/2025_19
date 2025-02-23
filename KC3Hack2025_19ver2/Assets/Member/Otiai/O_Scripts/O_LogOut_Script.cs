using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using UnityEngine.Networking;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class LogOut_Script : MonoBehaviour
{
    private string flaskUrl = "http://127.0.0.1:5000/logout";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Logout()
    {
        StartCoroutine(SendDataToFlask());
    }

    IEnumerator SendDataToFlask()
    {

        // HTTPリクエスト作成
        using (UnityWebRequest request = new UnityWebRequest(flaskUrl, "POST"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();

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
            }
            else
            {
                Debug.LogError("Request Failed: " + request.error);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
