using System;
using UnityEngine;
using TMPro;

public class K_Location : MonoBehaviour
{
    // 2つの現在の座標表示用テキストを取得
    [SerializeField] private TextMeshProUGUI LatitudeText;
    [SerializeField] private TextMeshProUGUI LongitudeText;

    // Start is called before the first frame update
    void Start()
    {
        // GPS機能の利用開始
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Textオブジェクトのtext部分を取得したGPS情報の緯度・経度で上書き
        LatitudeText.text = Convert.ToString(Input.location.lastData.latitude);
        LongitudeText.text = Convert.ToString(Input.location.lastData.longitude);
    }
}
