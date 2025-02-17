using System;
using UnityEngine;
using TMPro;

public class K_Location : MonoBehaviour
{
    // GameObject�����\�b�h�O�Œ�`���邱�ƂŁAInspector�ɂ�Object��R�Â��ł���B
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
