using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class K_MapTexter : MonoBehaviour
{
    //URLがマップを表示する。
//    center マップの中心の位置。文字,座標が可能
//markers マーカーの位置。「|」により複数個マーカーを設置することが可能 文字, 座標が可能
//key APIのキーをいれる。
//zoom 1～21で変更可能 大きくするほど倍率増加
//maptype 表示形式を変える。以下の通り
//roadmap: 通常の道路地図を表示
//satellite: 衛星写真を表示
//hybrid: ハイブリッド地図を表示
//terrain: 地形図を表示

    private const string STATIC_MAP_URL = "https://maps.googleapis.com/maps/api/staticmap?key=AIzaSyAYgTXuEofJwvKwEwX1RqYwlUS4CJzcxK8&zoom=15&size=640x640&scale=2&maptype=roadmap";

    //ピンを保存するためのdouble型のList 経度と緯度で2つ
    public List<double> pin_latitude = new List<double>();
    public List<double> pin_longitude = new List<double>();

    // Start is called before the first frame update
    void Start()
    {
        // 非同期処理？初めに一回呼ぶ。
        StartCoroutine(getStaticMap());
    }

    //外部から呼ぶために分けた。
    public void ReloadMap()
    {
        StartCoroutine(getStaticMap());
    }

    //マップの内容を更新する関数　Reloadで呼ばれる関数
    IEnumerator getStaticMap()
    {
        //変更するための文字列を保存する空のstring
        var query = "";

        // centerで取得するミニマップの中央座標を設定　Input.location.lastDataでGPSによる現在の座標を取得
        query += "&center=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));

        //保存されているマーカーの回数繰り返す。
        for (int i = 0; i < pin_longitude.Count; i++)
        {
            // markersで渡した座標(=現在位置)にマーカーを立てる
            query += "&markers=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", pin_latitude[i], pin_longitude[i]));
        }
        // リクエストの定義
        var req = UnityWebRequestTexture.GetTexture(STATIC_MAP_URL + query);
        // リクエスト実行
        yield return req.SendWebRequest();

        if (req.error == null)
        {
            // すでに表示しているマップを更新
            Destroy(GetComponent<Renderer>().material.mainTexture);
            GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)req.downloadHandler).texture;
        }
    }
}
