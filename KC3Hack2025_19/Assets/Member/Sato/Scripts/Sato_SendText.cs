using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using static DataBase_test;
using System.Text;
using UnityEngine.Networking;
using System.Collections;

public class Sato_SendText : MonoBehaviour
{
    private string postUrl = "https://khakimink3.sakura.ne.jp/kc3hack19.php"; // PHPファイルのURL

    //バックに送信する情報（画像番号,座標,文字列）
    public IMAGETARGET_NUMBER imagenum;
    public GameObject text;
    public TextMeshPro textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //登録情報受け取り
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
    //文字、位置データをバックに送信（登録決定ボタン）
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

        //角田がテストのため配置　完成では消す予定
        //staticな関数databaseにデータを追加

        DataBase_test.instance.ar_data.Add(new AR_Data(DataBase_test.instance.Now_image, senddata.sendposition, senddata.sendtext));
        StartCoroutine(SendTextData(senddata.sendposition, senddata.sendtext, DataBase_test.instance.Now_image));
    }

    IEnumerator SendTextData(Vector3 pos, string text, int marker)
    {
        // 送信するデータをJSON形式に整形 (imagetargetNumber を使用)
        string jsonData = "{"
            + "\"x\":" + pos.x
            + ",\"y\":" + pos.y
            + ",\"z\":" +pos.z
            + ",\"text\":\"" + text
            + "\",\"markerNumber\":" + marker + "}";

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
            Debug.Log(www.SendWebRequest());
        }
        Debug.Log(jsonData);
    }
}
