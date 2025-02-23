using System.Collections.Generic;
using UnityEngine;
using TMPro;

//�\������AR�̏����\���̂ɂ܂Ƃ߂��B
[System.Serializable]   //�C���X�y�N�^�[�ɒl��\���ł���悤�ɂ���
public struct AR_Data
{
    public int marker;//AR�}�[�J�[�̔ԍ�
    public Vector3 pos;//AR��\��������W
    public string text;//AR�ŕ\���������e
    public Quaternion rot; 

    //�R���X�g���N�^
    public AR_Data(int marker, Vector3 pos, string text,Quaternion rot)
    {
        this.marker = marker;//AR�}�[�J�[�̔ԍ�
        this.pos = pos;//AR��\��������W
        this.text = text;//AR�ŕ\���������e
        this.rot = rot;
    }
}

public class K_SaveData : MonoBehaviour
{
    //��������TMP������B
    [SerializeField] private GameObject TMP;
    [SerializeField] private GameObject Marker;
    //ar�̃f�[�^�����郊�X�g
    public List<AR_Data> ar_data = new List<AR_Data>();

    private TextMeshPro ar_TMP;

    private void Start()
    {
        ar_data.Add(new AR_Data(1,transform.localPosition,"instantiate", new Quaternion(0,0,0,0)));
        for (int i=0;i < ar_data.Count; i++)
        {
            GameObject newObject = Instantiate(TMP,ar_data[i].pos, ar_data[i].rot,Marker.transform);
            ar_TMP = newObject.GetComponent<TextMeshPro>();
            ar_TMP.text=ar_data[i].text;
        }
    }
}
