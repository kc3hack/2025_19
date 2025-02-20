using System.Collections.Generic;
using UnityEngine;
using TMPro;

//表示するARの情報を構造体にまとめた。
[System.Serializable]   //インスペクターに値を表示できるようにする
public struct AR_Data
{
    public int marker;//ARマーカーの番号
    public Vector3 pos;//ARを表示する座標
    public string text;//ARで表示される内容
    public Quaternion rot; 

    //コンストラクタ
    public AR_Data(int marker, Vector3 pos, string text,Quaternion rot)
    {
        this.marker = marker;//ARマーカーの番号
        this.pos = pos;//ARを表示する座標
        this.text = text;//ARで表示される内容
        this.rot = rot;
    }
}

public class K_SaveData : MonoBehaviour
{
    //複製するTMPを入れる。
    [SerializeField] private GameObject TMP;
    [SerializeField] private GameObject Marker;
    //arのデータを入れるリスト
    public List<AR_Data> ar_data = new List<AR_Data>();

    private TextMeshPro ar_TMP;

    private void Start()
    {
        ar_data.Add(new AR_Data(1,transform.localPosition,"instantiate", new Quaternion(0,0,0,0)));
        for (int i=0;i < ar_data.Count; i++)
        {
            GameObject newObject = Instantiate(TMP,ar_data[i].pos, ar_data[i].rot,Marker.transform);
            ar_TMP = newObject.GetComponent<TextMeshPro>();
            ar_TMP.text=ar_data[i].text;
        }
    }
}
