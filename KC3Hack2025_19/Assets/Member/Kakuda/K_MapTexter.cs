using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class K_MapTexter : MonoBehaviour
{
    private const string STATIC_MAP_URL = "https://maps.googleapis.com/maps/api/staticmap?key=AIzaSyAYgTXuEofJwvKwEwX1RqYwlUS4CJzcxK8&zoom=15&size=640x640&scale=2&maptype=roadmap";

    public List<double> pin_latitude = new List<double>();
    public List<double> pin_longitude = new List<double>();

    // Start is called before the first frame update
    void Start()
    {
        // 非同期処理
        StartCoroutine(getStaticMap());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReloadMap()
    {
        StartCoroutine(getStaticMap());
    }

    IEnumerator getStaticMap()
    {
        Debug.Log("GetMap");
        var query = "";

        // centerで取得するミニマップの中央座標を設定
        query += "&center=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));

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
