using UnityEngine;
using TMPro;

public class Sato_ButtonManager : MonoBehaviour
{
    //ImageTarget��TMP
    [SerializeField] GameObject text;
    //ImageTarget�̌��_
    [SerializeField] GameObject basepoint;
    //ImageTarget��TMP��text
    [SerializeField] TextMeshPro textMeshPro;
    //x,y,z�̑�����
    float addposition = 0.05f;
    //text��size
    int addsize = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void ServeText()
    {

    }
    //(xyz���{�^��)
    public void PlusPosition(int coordinate)
    {
        Vector3 textposition=text.transform.position;
        //coodinate�F���W���i0�Fx���@1�Fy���@2�Fz���j
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
    //(xyz���{�^��)
    public void MinusPosition(int coordinate)
    {
        Vector3 textposition = text.transform.position;
        //coodinate�F���W���i0�Fx���@1�Fy���@2�Fz���j
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
    //(�ʒu���Z�b�g�{�^��)
    public void ResetPosition()
    {
        Vector3 firstposition = basepoint.transform.position;
        firstposition.y += 0.1f;
        text.transform.position=firstposition;
    }
    //(�T�C�Y���{�^��)
    public void PlusTextSize()
    {
        textMeshPro.fontSize += addsize;
    }
    //(�T�C�Y���{�^��)
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
