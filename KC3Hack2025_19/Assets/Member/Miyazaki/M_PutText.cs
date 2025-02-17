using TMPro;
using UnityEngine;

public class M_PutText : MonoBehaviour
{
    public GameObject targetObject; // 非アクティブにするオブジェクト
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject childObject; // 親オブジェクト
    public GameObject parentObject;
    public TextMeshProUGUI textMeshProUGUI;

    public void PutTextObject() // 非アクティブにするオブジェクトを有効化するメソッド
    {
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        targetObject3.SetActive(false);
        childObject.transform.SetParent(parentObject.transform, true);
        textMeshProUGUI.text = "(" + childObject.transform.position.x + "," + childObject.transform.position.y + "," + childObject.transform.position.z + ")";
    }

    void SendTextData()
    {
        string text = childObject.GetComponent<TextMeshPro>().text;
        Vector3 position = childObject.transform.position;
        Vector3 rotation = childObject.transform.rotation.eulerAngles;
    }
}
