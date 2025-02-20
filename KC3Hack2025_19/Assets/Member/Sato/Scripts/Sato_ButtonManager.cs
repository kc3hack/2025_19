using UnityEngine;
using TMPro;

public class Sato_ButtonManager : MonoBehaviour
{
    //ImageTargetのTMP
    public GameObject text;
    //ImageTargetの原点
    public GameObject basepoint;
    //ImageTargetのTMPのtext
    public TextMeshPro textMeshPro;
    //x,y,zの増加幅
    float addposition = 0.05f;
    //textのsize
    int addsize = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void ReceiveText(GameObject receivetext,GameObject receivebase,TextMeshPro receivetmp)
    {
        text = receivetext;
        basepoint = receivebase;
        textMeshPro = receivetmp;
    }
    //(xyz増ボタン)
    public void PlusPosition(int coordinate)
    {
        Vector3 textposition=text.transform.position;
        //coodinate：座標軸（0：x軸　1：y軸　2：z軸）
        switch (coordinate)
        {
            case 0:
                textposition.x += addposition;
                break;
            case 1:
                textposition.y += addposition; 
                break;
            case 2:
                textposition.z += addposition;
                break;
        }
        text.transform.position = textposition;
    }
    //(xyz減ボタン)
    public void MinusPosition(int coordinate)
    {
        Vector3 textposition = text.transform.position;
        //coodinate：座標軸（0：x軸　1：y軸　2：z軸）
        switch (coordinate)
        {
            case 0:
                textposition.x -= addposition;
                break;
            case 1:
                textposition.y -= addposition;
                break;
            case 2:
                textposition.z -= addposition;
                break;
        }
        text.transform.position = textposition;
    }
    //(位置リセットボタン)
    public void ResetButton()
    {
        Vector3 firstposition = basepoint.transform.position;
        firstposition.y += 0.1f;
        text.transform.position=firstposition;
        textMeshPro.fontSize = 36;
    }
    //(サイズ増ボタン)
    public void PlusTextSize()
    {
        textMeshPro.fontSize += addsize;
    }
    //(サイズ減ボタン)
    public void MinusTextSize()
    {
        textMeshPro.fontSize -= addsize;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
