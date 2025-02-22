using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using static DataBase_test;
using System.Text;
using UnityEngine.Networking;
using System.Collections;

public class Sato_SendText : MonoBehaviour
{
    private string postUrl = "https://khakimink3.sakura.ne.jp/kc3hack19.php"; // PHP�t�@�C����URL

    //�o�b�N�ɑ��M������i�摜�ԍ�,���W,������j
    public IMAGETARGET_NUMBER imagenum;
    public GameObject text;
    public TextMeshPro textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //�o�^���󂯎��
    public void ReceiveData(IMAGETARGET_NUMBER receivenum,GameObject receivetext,TextMeshPro receivetmp)
    {
        imagenum = receivenum;
        text = receivetext;
        textMeshPro = receivetmp;
    }
    class SendDataClass
    {
        public IMAGETARGET_NUMBER sendimagenumber;
        public string sendtext;
        public Vector3 sendposition;
        public float sendfontsize;
    }
    //�����A�ʒu�f�[�^���o�b�N�ɑ��M�i�o�^����{�^���j
    public void SendDecidedText()
    {
        var senddata=new SendDataClass();
        //Sato_ImageTargetNumber imagenumberscript;
        //imagenumberscript=text.GetComponent<Sato_ImageTargetNumber>();
        //senddata.sendimagenumber = imagenumberscript.imagetarget_number;
        senddata.sendtext=textMeshPro.text;
        senddata.sendposition=text.transform.localPosition;
        Debug.Log(text.transform.localPosition);
        senddata.sendfontsize = textMeshPro.fontSize;

        //�p�c���e�X�g�̂��ߔz�u�@�����ł͏����\��
        //static�Ȋ֐�database�Ƀf�[�^��ǉ�

        DataBase_test.instance.ar_data.Add(new AR_Data(DataBase_test.instance.Now_image, senddata.sendposition, senddata.sendtext));
        StartCoroutine(SendTextData(senddata.sendposition, senddata.sendtext, DataBase_test.instance.Now_image));
    }

    IEnumerator SendTextData(Vector3 pos, string text, int marker)
    {
        // ���M����f�[�^��JSON�`���ɐ��` (imagetargetNumber ���g�p)
        string jsonData = "{"
            + "\"x\":" + pos.x
            + ",\"y\":" + pos.y
            + ",\"z\":" +pos.z
            + ",\"text\":\"" + text
            + "\",\"markerNumber\":" + marker + "}";

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
            Debug.Log(www.SendWebRequest());
        }
        Debug.Log(jsonData);
    }
}
