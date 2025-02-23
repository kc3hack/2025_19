using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

public class Post_Script : MonoBehaviour
{
    private string flaskUrl = "https://khakimink3.sakura.ne.jp/objdata.json";

    private float rnd;

    [SerializeField] private TextMeshProUGUI sendtext;

    [System.Serializable]
    public class Post
    {
        public int number;
        public string text;
        public float location_x;
        public float location_y;
        public float location_z;
    }

    [System.Serializable]
    public class Posts
    {
        public Post[] posts;
    }

    [System.Serializable]
    private class ListWrapper
    {
        public List<Post> data;
    }


    public void Get_Post()
    {
        StartCoroutine(GetDataFromFlask());
    }

    public void Send_Post()
    {
        StartCoroutine(SendDataToFlask());
    }



    IEnumerator SendDataToFlask()
    {
        // 送信するJSONデータ
        Post post = new Post();
        post.number = 101;
        post.text = sendtext.text;
        post.location_x = rnd;
        post.location_y = rnd;
        post.location_z = rnd;


        string jsonData = JsonUtility.ToJson(post);
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);

        // HTTPリクエスト作成
        using (UnityWebRequest request = new UnityWebRequest(flaskUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            // レスポンスを取得
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Request Failed: " + request.error);
            }
        }
    }

    IEnumerator GetDataFromFlask()
    {

        using (UnityWebRequest request = UnityWebRequest.Get(flaskUrl))
        {
            yield return request.SendWebRequest();

            string json = request.downloadHandler.text;
            Debug.Log(json);

            //Posts posts = JsonUtility.FromJson<Posts>(json);
            //List<Post> postList = new List<Post>(posts.posts);

            //List<Post> dataList = JsonUtility.FromJson<ListWrapper>(json).data;

            //foreach (Post post in postList)
            //{
            //    Debug.Log(post.number + post.text + post.location_x + post.location_y +post.location_z);
            //}

            //if (request.result == UnityWebRequest.Result.Success)
            //{
            //    Debug.Log("Received: " + request.downloadHandler.text);
            //}
            //else
            //{
            //    Debug.LogError("Request Failed: " + request.error);
            //}
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rnd = Random.Range(1.0f, 5.0f);
        StartCoroutine(GetDataFromFlask());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}


