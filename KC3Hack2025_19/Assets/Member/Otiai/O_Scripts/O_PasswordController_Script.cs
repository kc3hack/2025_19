using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController_Script : MonoBehaviour
{
    public TMP_InputField passField;            // �p�X���[�h��InputField
    public GameObject maskingOffButton;     // �}�X�L���O���I�t�ɂ���Button
    public GameObject maskingOnButton;      // �}�X�L���O���I���ɂ���Button

    public void OnClickMaskingOffButton()   // maskingOffButton�������Ǝ��s�����֐�
    {
        maskingOffButton.SetActive(false);
        maskingOnButton.SetActive(true);
        passField.contentType = TMP_InputField.ContentType.Standard;
        StartCoroutine(ReloadInputField());
    }

    public void OnClickMaskingOnButton()    // maskingOnButton�������Ǝ��s�����֐�
    {
        maskingOffButton.SetActive(true);
        maskingOnButton.SetActive(false);
        passField.contentType = TMP_InputField.ContentType.Password;
        StartCoroutine(ReloadInputField());
    }

    private IEnumerator ReloadInputField()
    {
        passField.ActivateInputField();
        yield return null;
        passField.MoveTextEnd(true);
    }    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maskingOffButton.SetActive(true);
        maskingOnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
