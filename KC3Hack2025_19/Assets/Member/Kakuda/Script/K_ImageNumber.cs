using UnityEngine;

public class K_ImageNumber : MonoBehaviour
{
    public void FindOn(int targetnumber)
    {
        DataBase_test.instance.Now_image = targetnumber;
    }
}
