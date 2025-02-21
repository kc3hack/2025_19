using UnityEngine;
using System.Collections.Generic;
using TMPro.Examples;

public class DataBase_test : MonoBehaviour
{
    //���̃X�N���v�g�����݂��邩�����B�ڍׂ͂�����https://dkrevel.com/makegame-beginner/make-2d-action-game-manager/
    public static DataBase_test instance = null;
    public int Now_image;
    public List<AR_Data> ar_data = new List<AR_Data>();

    //�V���O���g���@�������݂��Ă�����destroy
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    public struct AR_Data
    {
        public int marker;//AR�}�[�J�[�̔ԍ�
        public Vector3 pos;//AR��\��������W
        public string text;//AR�ŕ\���������e
        public Quaternion rot;

        //�R���X�g���N�^
        public AR_Data(int marker, Vector3 pos, string text, Quaternion rot)
        {
            this.marker = marker;//AR�}�[�J�[�̔ԍ�
            this.pos = pos;//AR��\��������W
            this.text = text;//AR�ŕ\���������e
            this.rot = rot;//��]�����
        }
    }
}
