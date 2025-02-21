using UnityEngine;
using TMPro;

public class SEdit_M_MoveText : MonoBehaviour
{
    public TextMeshPro textObject;
    public void Move()
    {
        Vector3 pos = textObject.rectTransform.localPosition;
        pos.z += 0.1f;
        textObject.rectTransform.localPosition = pos;
    }

    public void Move2()
    {
        Vector3 pos = textObject.rectTransform.localPosition;
        pos.z -= 0.1f;
        textObject.rectTransform.localPosition = pos;
    }
}
