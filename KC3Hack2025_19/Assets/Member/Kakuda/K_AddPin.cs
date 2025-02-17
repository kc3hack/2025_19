using UnityEngine;

public class K_AddPin : MonoBehaviour
{
    [SerializeField] private K_MapTexter maptexter;

    public void Onclick()
    {
        maptexter.pin_latitude.Add(Input.location.lastData.latitude);
        maptexter.pin_longitude.Add(Input.location.lastData.longitude);
    }
}
