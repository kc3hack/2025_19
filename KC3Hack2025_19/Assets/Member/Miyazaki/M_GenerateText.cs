using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class M_GenerateText : MonoBehaviour
{
    private string url = ""; // JsonファイルのURL
    public GameObject Origin;
    public GameObject GeneratePivot;
    public GameObject ImageTarget;
    public GameObject creatTextObject;
    void Start()
    {
        StartCoroutine(GenerateText());
    }

    [System.Serializable]
    public class ObjectData
    {
        public float x;
        public float y;
        public float z;
        public string text;
    }

    [System.Serializable]
    public class ObjectDataList
    {
        public ObjectData[] objects;
    }


    IEnumerator GenerateText() //コルーチンに変更
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string jsonString = webRequest.downloadHandler.text;
                ObjectDataList dataList = JsonUtility.FromJson<ObjectDataList>(jsonString);

                // JSONデータ内の各オブジェクトに対してテキスト生成
                foreach (ObjectData objData in dataList.objects)
                {
                    CreateTextAtOffset(new Vector3(objData.x, objData.y, objData.z), objData.text);
                }
            }
        }
    }

    void CreateTextAtOffset(Vector3 positionOffset, string text)
    {
        // テキストオブジェクトを生成。位置はOriginの座標 + オフセット
        GameObject newText = Instantiate(creatTextObject, Origin.transform.position + positionOffset, Quaternion.identity);
        // 生成したテキストオブジェクトをImageTargetの子オブジェクトにする
        newText.transform.SetParent(ImageTarget.transform, true);
        // 生成したテキストオブジェクトの向きをGeneratePivotに向ける
        newText.transform.rotation = Quaternion.LookRotation(GeneratePivot.transform.position - newText.transform.position);
        // オイラー角を調整してテキストの向きを補正 (X軸反転、Y軸180度回転)
        Vector3 eulerAngles = newText.transform.eulerAngles;
        eulerAngles.x = eulerAngles.x * -1;
        eulerAngles.y += 180f;
        newText.transform.eulerAngles = eulerAngles;
        // テキストオブジェクトのTextMeshProコンポーネントにテキストを設定
        newText.GetComponent<TextMeshPro>().text = text;
    }
}
