using UnityEngine;

public class K_Reload : MonoBehaviour
{

    [SerializeField] private K_MapTexter maptexter;

    public void Onclick()
    {
        maptexter.ReloadMap();
    }
}
