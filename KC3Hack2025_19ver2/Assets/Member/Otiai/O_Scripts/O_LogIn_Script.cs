using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogIn_Script : MonoBehaviour
{
    private string url = "https://khakimink3.sakura.ne.jp/userdata.json"; // Json�t�@�C����URL

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

    IEnumerator GetData() //�R���[�`���ɕύX
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

                // JSON�f�[�^���̃��[�U�[���ƃp�X���[�h�����͂������̂Ɠ��������ׂ�
                foreach (User userData in dataList.users)
                {
                    if (userData.username == usernameText.text && userData.password == passwordText.text)
                    {
                        //�����Ă�����V�[����؂�ւ���
                        ChangeSelectScene();
                        None = false;
                    }
                }

                if (None == true)
                {
                    errorText.text = "���[�U�[�����p�X���[�h�A�܂��́A���̗������Ԉ���Ă��܂�";
                }

            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    //�I����ʂ֐؂�ւ�
    void ChangeSelectScene()
    {
        //�{�Ԃł́A�I����ʂ֐؂�ւ�
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

