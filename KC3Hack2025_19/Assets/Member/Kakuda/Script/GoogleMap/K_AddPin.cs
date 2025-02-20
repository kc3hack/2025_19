using UnityEngine;

public class K_AddPin : MonoBehaviour
{
    [SerializeField] private K_MapTexter maptexter;

    public void Onclick()
    {
        //現在のGPSの座標をK_MapTexterのピンの座標代入用リストに代入する。
        maptexter.pin_latitude.Add(Input.location.lastData.latitude);
        maptexter.pin_longitude.Add(Input.location.lastData.longitude);
    }
}
