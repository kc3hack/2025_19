using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController_Script : MonoBehaviour
{
    public TMP_InputField passField;            // パスワードのInputField
    public GameObject maskingOffButton;     // マスキングをオフにするButton
    public GameObject maskingOnButton;      // マスキングをオンにするButton

    public void OnClickMaskingOffButton()   // maskingOffButtonを押すと実行される関数
    {
        maskingOffButton.SetActive(false);
        maskingOnButton.SetActive(true);
        passField.contentType = TMP_InputField.ContentType.Standard;
        StartCoroutine(ReloadInputField());
    }

    public void OnClickMaskingOnButton()    // maskingOnButtonを押すと実行される関数
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
