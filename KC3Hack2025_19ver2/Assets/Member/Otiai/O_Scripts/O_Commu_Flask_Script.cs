using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;
using TMPro;

public class Commu_Flask_Script : MonoBehaviour
{
    private string flaskUrl = "http://127.0.0.1:5000/data";  // Flask�̃G���h�|�C���g

    void Start()
    {
        StartCoroutine(SendDataToFlask());
        StartCoroutine(GetDataFromFlask());
    }

    IEnumerator SendDataToFlask()
    {
        // ���M����JSON�f�[�^
        string jsonData = "{\"name\": \"Unity\", \"score\": 100}";
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);

        // HTTP���N�G�X�g�쐬
        using (UnityWebRequest request = new UnityWebRequest(flaskUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            // ���X�|���X���擾
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Request Failed: " + request.error);
            }
        }
    }

    IEnumerator GetDataFromFlask()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://127.0.0.1:5000/get_score"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Received: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Request Failed: " + request.error);
            }
        }
    }

    private void Update()
    {
        
    }
}