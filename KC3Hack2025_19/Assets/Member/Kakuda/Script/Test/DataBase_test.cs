using UnityEngine;
using System.Collections.Generic;
using TMPro.Examples;

public class DataBase_test : MonoBehaviour
{
    //このスクリプトが存在するかを代入。詳細はこちらhttps://dkrevel.com/makegame-beginner/make-2d-action-game-manager/
    public static DataBase_test instance = null;
    public int Now_image;
    public List<AR_Data> ar_data = new List<AR_Data>();

    //シングルトン　もう存在していたらdestroy
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    public struct AR_Data
    {
        public int marker;//ARマーカーの番号
        public Vector3 pos;//ARを表示する座標
        public string text;//ARで表示される内容
        public Quaternion rot;

        //コンストラクタ
        public AR_Data(int marker, Vector3 pos, string text, Quaternion rot)
        {
            this.marker = marker;//ARマーカーの番号
            this.pos = pos;//ARを表示する座標
            this.text = text;//ARで表示される内容
            this.rot = rot;//回転を入力
        }
    }
}
