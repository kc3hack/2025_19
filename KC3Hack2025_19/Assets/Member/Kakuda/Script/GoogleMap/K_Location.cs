using System;
using UnityEngine;
using TMPro;

public class K_Location : MonoBehaviour
{
    // 2�̌��݂̍��W�\���p�e�L�X�g���擾
    [SerializeField] private TextMeshProUGUI LatitudeText;
    [SerializeField] private TextMeshProUGUI LongitudeText;

    // Start is called before the first frame update
    void Start()
    {
        // GPS�@�\�̗��p�J�n
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Text�I�u�W�F�N�g��text�������擾����GPS���̈ܓx�E�o�x�ŏ㏑��
        LatitudeText.text = Convert.ToString(Input.location.lastData.latitude);
        LongitudeText.text = Convert.ToString(Input.location.lastData.longitude);
    }
}
