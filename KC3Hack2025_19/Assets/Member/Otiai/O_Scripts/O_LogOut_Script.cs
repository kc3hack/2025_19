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

        // HTTP���N�G�X�g�쐬
        using (UnityWebRequest request = new UnityWebRequest(flaskUrl, "POST"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            // ���X�|���X���擾 �����Ń��O�C���̉ۂ𔻒肵�A�V�[���̑J�ڂ��s��
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
