using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class UploadData : MonoBehaviour
{
    private string postUrl = "https://khakimink3.sakura.ne.jp/kc3hack19.php"; // PHPファイルのURL
    public GameObject InputField;
    public GameObject UpButton;
    public GameObject DownButton;
    public GameObject InputTextObj;
    public GameObject ImageTarget;
    public int markerNumber; //ここに、ImageTargetの番号を入れる

    public void PutTextObject()
    {
        InputField.SetActive(false);
        UpButton.SetActive(false);
        DownButton.SetActive(false);
        InputTextObj.transform.SetParent(ImageTarget.transform, true);
        StartCoroutine(SendTextData());
    }
    IEnumerator SendTextData()
    {
        Vector3 position = InputTextObj.transform.position;
        string text = InputTextObj.GetComponent<TextMeshPro>().text;

        // 相対座標に変換 (Origin からの相対位置)
        Vector3 relativePosition = position - GameObject.Find("Origin").transform.position; //"Origin"は適宜変更

        // 送信するデータをJSON形式に整形 (imagetargetNumber を使用)
        string jsonData = "{\"x\":" + relativePosition.x + ",\"y\":" + relativePosition.y + ",\"z\":" + relativePosition.z + ",\"text\":\"" + text + "\",\"markerNumber\":" + markerNumber + "}";

        // UnityWebRequest を使って POST リクエストを送信
        using (UnityWebRequest www = new UnityWebRequest(postUrl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
        }

        GenerateText();
    }

    void GenerateText()
    {
        //　本番ではここはシーン切り替えにする
        GameObject.Find("Generate Text Obj").GetComponent<M_GenerateText>().enabled = true;
        InputTextObj.SetActive(false);
    }
}
