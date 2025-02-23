using UnityEngine;
using TMPro;

public class TextColer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshPro>().color = Random.ColorHSV();
    }
}
