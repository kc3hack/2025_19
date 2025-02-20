using UnityEngine;

public class K_Zoom : MonoBehaviour
{
    [SerializeField] private K_MapTexter maptexter;
    [SerializeField] private bool up;

    public void Onclick()
    {
        if (up)
        {
            maptexter.zoom += 1;
        }
        else
        {
            maptexter.zoom -= 1;
        }
    }
}
