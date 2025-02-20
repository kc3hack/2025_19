using UnityEngine;
using TMPro;

public class Sato_FindImage : MonoBehaviour
{
    [SerializeField] GameObject[] texts;
    [SerializeField] TextMeshPro[] tmp;
    public Sato_InputText inputTextScript;
    public Sato_ButtonManager buttonManagerScript;
    //targetnumberÇÕImageTargetÇÃî‘çÜ
    public void FindOn(int targetnumber)
    {
        texts[targetnumber].SetActive(true);
        inputTextScript.ServeTMP(tmp[targetnumber]);
    }
    public void FindOut(int targetnumber)
    {
        texts[targetnumber].SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
