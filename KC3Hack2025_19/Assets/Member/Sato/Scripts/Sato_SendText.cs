using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Sato_SendText : MonoBehaviour
{
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
    SendDataClass SendDecidedText()
    {
        var senddata=new SendDataClass();
        Sato_ImageTargetNumber imagenumberscript;
        imagenumberscript=text.GetComponent<Sato_ImageTargetNumber>();
        senddata.sendimagenumber = imagenumberscript.imagetarget_number;
        senddata.sendtext=textMeshPro.text;
        senddata.sendposition=text.transform.localPosition;
        senddata.sendfontsize = textMeshPro.fontSize;
        return senddata;
    }

    //送信データをコンソールで確認用
    public void Testbutton()
    {
        var sendresult=SendDecidedText();
        Debug.Log($"IMAGETARGET_NUMBER:{sendresult.sendimagenumber},string:{sendresult.sendtext},Vector3:{sendresult.sendposition},float:{sendresult.sendfontsize}");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
