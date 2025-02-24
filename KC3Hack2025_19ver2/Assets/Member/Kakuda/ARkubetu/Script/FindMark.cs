using UnityEngine;

public class FindMark : MonoBehaviour
{
    [SerializeField] GameObject[] markcanvas;
    public void OtherFalse(int marknumber)
    {
        Debug.Log(marknumber);
        for (int i=0;i<13 ;i++)
        {
            if (i==marknumber)
            {
                markcanvas[i].SetActive(true);
            }
            else
            {
                markcanvas[i].SetActive(false);
            }
        }
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
