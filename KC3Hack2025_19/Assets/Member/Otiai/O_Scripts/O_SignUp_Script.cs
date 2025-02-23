using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignUp_Script : MonoBehaviour
{
    private string postUrl = "https://khakimink3.sakura.ne.jp/kc3hack19_users.php"; // PHPファイルのURL

    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI passwordText;


    public void SignUp()
    {
        StartCoroutine(SendTextData());
    }
    IEnumerator SendTextData()
    {

        User usrData = new User
        {
            username = usernameText.text,
            password = passwordText.text
        };

        // 送信するデータをJSON形式に整形 (imagetargetNumber を使用)
        string jsonData = JsonUtility.ToJson(usrData);

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
            else
            {
                ChangeLoginScene();
            }
        }
    }

    void ChangeLoginScene()
    {
        //　本番ではここはシーン切り替えにする ログインシーンに切り替え
        SceneManager.LoadScene("LogInScene");
    }
}