using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject basepoint;
    float addposition = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    public void ResetPosition()
    {
        Vector3 firstposition = basepoint.transform.position;
        firstposition.y += 0.1f;
        text.transform.position=firstposition;
    }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
