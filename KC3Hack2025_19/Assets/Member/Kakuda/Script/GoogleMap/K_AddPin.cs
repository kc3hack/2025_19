using UnityEngine;

public class K_AddPin : MonoBehaviour
{
    [SerializeField] private K_MapTexter maptexter;

    public void Onclick()
    {
        //���݂�GPS�̍��W��K_MapTexter�̃s���̍��W����p���X�g�ɑ������B
        maptexter.pin_latitude.Add(Input.location.lastData.latitude);
        maptexter.pin_longitude.Add(Input.location.lastData.longitude);
    }
}
