using UnityEngine;
using TMPro;
using TMPro.Examples;

public class K_CopyText : MonoBehaviour
{
    [SerializeField] private GameObject TMP;
    [SerializeField] private GameObject[] basepoint;
    private TMPro.TextMeshPro ar_TMP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i=0;i < DataBase_test.instance.ar_data.Count; i++)
        {
            Debug.Log(basepoint[DataBase_test.instance.ar_data[i].marker]);

            Debug.Log(DataBase_test.instance.ar_data.Count);
            Debug.Log(DataBase_test.instance.ar_data[0]);
                Debug.Log(DataBase_test.instance.ar_data[i].pos);
                GameObject newObject = Instantiate(TMP,basepoint[DataBase_test.instance.ar_data[i].marker].transform);

            newObject.transform.localPosition = DataBase_test.instance.ar_data[i].pos;
                ar_TMP = newObject.GetComponent<TextMeshPro>();
                ar_TMP.text = DataBase_test.instance.ar_data[i].text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
