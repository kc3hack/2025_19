using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Sato_SendText : MonoBehaviour
{
    //バックに送信する情報（画像番号,座標,文字列）
    [SerializeField] GameObject text;
    [SerializeField] TextMeshPro textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    class SendDataClass
    {
        public IMAGETARGET_NUMBER imagenumber;
        public string sendtext;
        public Vector3 sendposition;
    }
    //文字、位置データをバックに送信（登録決定ボタン）
    SendDataClass SendDecidedText()
    {
        var senddata=new SendDataClass();
        Sato_ImageTargetNumber imagenumberscript;
        imagenumberscript=text.GetComponent<Sato_ImageTargetNumber>();
        senddata.imagenumber = imagenumberscript.imagetarget_number;
        senddata.sendtext=textMeshPro.text;
        senddata.sendposition=text.transform.localPosition;
        return senddata;
    }

    //送信データをコンソールで確認用
    public void Testbutton()
    {
        var sendresult=SendDecidedText();
        Debug.Log($"IMAGETARGET_NUMBER:{sendresult.imagenumber},string:{sendresult.sendtext},Vector3:{sendresult.sendposition}");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
