using UnityEngine;
using static DataBase_test;
using TMPro;

public class K_SendText : MonoBehaviour
{

    [SerializeField] GameObject Text;
    private TMPro.TextMeshPro text_comp;

    void Start()
    {
        text_comp = Text.GetComponent<TextMeshPro>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Onclick()
    {
        //DataBase_test.instance.ar_data.Add(new AR_Data(1, Text.transform.localPosition, text_comp.text, new Quaternion(0, 0, 0, 0)));
    }
}
