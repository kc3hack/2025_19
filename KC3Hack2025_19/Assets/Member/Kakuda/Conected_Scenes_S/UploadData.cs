using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class UploadData : MonoBehaviour
{
    private string postUrl = "https://khakimink3.sakura.ne.jp/kc3hack19.php"; // PHP�t�@�C����URL
    public GameObject InputField;
    public GameObject UpButton;
    public GameObject DownButton;
    public GameObject InputTextObj;
    public GameObject ImageTarget;
    public int markerNumber; //�����ɁAImageTarget�̔ԍ�������

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

        // ���΍��W�ɕϊ� (Origin ����̑��Έʒu)
        Vector3 relativePosition = position - GameObject.Find("Origin").transform.position; //"Origin"�͓K�X�ύX

        // ���M����f�[�^��JSON�`���ɐ��` (imagetargetNumber ���g�p)
        string jsonData = "{\"x\":" + relativePosition.x + ",\"y\":" + relativePosition.y + ",\"z\":" + relativePosition.z + ",\"text\":\"" + text + "\",\"markerNumber\":" + markerNumber + "}";

        // UnityWebRequest ���g���� POST ���N�G�X�g�𑗐M
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
        //�@�{�Ԃł͂����̓V�[���؂�ւ��ɂ���
        GameObject.Find("Generate Text Obj").GetComponent<M_GenerateText>().enabled = true;
        InputTextObj.SetActive(false);
    }
}
