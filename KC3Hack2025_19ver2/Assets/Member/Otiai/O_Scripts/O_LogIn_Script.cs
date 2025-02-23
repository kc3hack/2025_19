using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogIn_Script : MonoBehaviour
{
    private string url = "https://khakimink3.sakura.ne.jp/userdata.json"; // JsonファイルのURL

    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI passwordText;
    [SerializeField] private TextMeshProUGUI errorText;
    private bool None = true;

    void Start()
    {
        errorText.text = "";
    }

    public void LogIn()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData() //コルーチンに変更
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string jsonString = webRequest.downloadHandler.text;
                UserDataList dataList = JsonUtility.FromJson<UserDataList>(jsonString);

                // JSONデータ内のユーザー名とパスワードが入力したものと同じか調べる
                foreach (User userData in dataList.users)
                {
                    if (userData.username == usernameText.text && userData.password == passwordText.text)
                    {
                        //合っていたらシーンを切り替える
                        ChangeSelectScene();
                        None = false;
                    }
                }

                if (None == true)
                {
                    errorText.text = "ユーザー名かパスワード、または、その両方が間違っています";
                }

            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    //選択画面へ切り替え
    void ChangeSelectScene()
    {
        //本番では、選択画面へ切り替え
        SceneManager.LoadScene("MapScene");
    }

}




[System.Serializable]
public class User
{
    public string username;
    public string password;
}

[System.Serializable]
public class UserDataList
{
    public User[] users;
}

public class Status
{
    public string status;
}

