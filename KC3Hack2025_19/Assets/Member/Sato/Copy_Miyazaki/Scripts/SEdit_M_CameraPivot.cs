using UnityEngine;

public class SEdit_M_CameraPivot : MonoBehaviour
{
    public Transform target; // 追従するオブジェクト

    void Update()
    {
        if (target != null)
        {
            // 現在の自身の回転を取得
            Vector3 currentRotation = transform.eulerAngles;

            // Y軸回転のみターゲットに合わせる
            currentRotation.x = target.eulerAngles.x;
            currentRotation.y = target.eulerAngles.y;

            // 回転を反映
            transform.eulerAngles = currentRotation;
        }
        else
        {
            Debug.LogError("Target object is not assigned!");
        }
    }
}
