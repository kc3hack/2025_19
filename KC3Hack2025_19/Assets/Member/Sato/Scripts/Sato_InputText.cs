using UnityEngine;
using TMPro;

public class Sato_InputText : MonoBehaviour
{
    public TMP_InputField inputField; // ���͗p�� Input Field (TMP_InputField)
    public TextMeshPro textMeshPro;   // �o�͐�� TextMeshPro (3D�I�u�W�F�N�g)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Input Field �� OnValueChanged �C�x���g�Ƀ��X�i�[��ǉ�
        if (inputField != null && textMeshPro != null)
        {
            inputField.onValueChanged.AddListener(UpdateTextMeshPro);
        }
        else if (inputField == null)
        {
            Debug.LogError("InputField is not assigned!");
        }
        else
        {
            Debug.LogError("TextMeshPro object is not assigned!");
        }
    }

    public void ReceiveTMP(TextMeshPro receiveTMP)
    {
        textMeshPro = receiveTMP;
    }
    //�e�L�X�g���ύX���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    private void UpdateTextMeshPro(string newText)
    {
        textMeshPro.text = newText;
    }
}