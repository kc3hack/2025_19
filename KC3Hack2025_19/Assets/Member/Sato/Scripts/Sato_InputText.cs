using UnityEngine;
using TMPro;

public class Sato_InputText : MonoBehaviour
{
    public TMP_InputField inputField; // 入力用の Input Field (TMP_InputField)
    public TextMeshPro textMeshPro;   // 出力先の TextMeshPro (3Dオブジェクト)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Input Field の OnValueChanged イベントにリスナーを追加
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
    //テキストが変更されたときに呼び出されるメソッド
    private void UpdateTextMeshPro(string newText)
    {
        textMeshPro.text = newText;
    }
}