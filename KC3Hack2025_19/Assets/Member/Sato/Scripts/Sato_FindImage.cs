using UnityEngine;
using TMPro;

public class Sato_FindImage : MonoBehaviour
{
    [SerializeField] GameObject[] texts;
    [SerializeField] GameObject[] basepoints;
    [SerializeField] TextMeshPro[] tmp;
    [SerializeField] IMAGETARGET_NUMBER[] imagetargetnumber;
    public Sato_InputText inputTextScript;
    public Sato_ButtonManager buttonManagerScript;
    public Sato_SendText sendTextScript;
    //targetnumberÇÕImageTargetÇÃî‘çÜ
    public void FindOn(int targetnumber)
    {
        texts[targetnumber].SetActive(true);
        inputTextScript.ReceiveTMP(tmp[targetnumber]);
        buttonManagerScript.ReceiveText(texts[targetnumber], basepoints[targetnumber], tmp[targetnumber]);
        sendTextScript.ReceiveData(imagetargetnumber[targetnumber], texts[targetnumber], tmp[targetnumber]);
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
