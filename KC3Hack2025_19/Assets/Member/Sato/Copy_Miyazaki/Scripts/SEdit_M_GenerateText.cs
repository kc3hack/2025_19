using UnityEngine;
using TMPro;

public class SEdit_M_GenerateText : MonoBehaviour
{
    public GameObject Origin;
    public GameObject Pivot;
    public GameObject ImageTarget;
    public GameObject creatTextObject;
    private int count = 0;

    public void GenerateText()
    {
        switch (count)
        {
            case 0:
                CreateTextAtOffset(new Vector3(0, 0.2f, 0), "Hello World!");
                break;
            case 1:
                CreateTextAtOffset(new Vector3(-0.3113458f, 0.1177335f, -0.1886542f), "もちもち");
                break;
            case 2:
                CreateTextAtOffset(new Vector3(-0.4047848f, 0.3891025f, -0.09521508f), "ざわざわ");
                break;
            case 3:
                CreateTextAtOffset(new Vector3(0.4047848f, 0.3891025f, -0.09521508f), "ドキドキ");
                break;
            case 4:
                CreateTextAtOffset(new Vector3(0.3113458f, 0.1177338f, -0.1886542f), "ゴロゴロ");
                break;
            case 5:
                CreateTextAtOffset(new Vector3(0, 0.9403095f, -0.1177335f), "<●>　<●>");
                break;
        }
        count++;
    }

    void CreateTextAtOffset(Vector3 positionOffset, string text)
    {
        GameObject newText = Instantiate(creatTextObject, Origin.transform.position + positionOffset, Quaternion.identity);

        newText.transform.SetParent(ImageTarget.transform, true);

        newText.transform.rotation = Quaternion.LookRotation(Pivot.transform.position - newText.transform.position);

        Vector3 eulerAngles = newText.transform.eulerAngles;
        eulerAngles.x = eulerAngles.x * -1;
        eulerAngles.y += 180f;
        newText.transform.eulerAngles = eulerAngles;

        newText.GetComponent<TextMeshPro>().text = text;
    }


    // void Count1()
    // {
    //     GameObject newText = Instantiate(creatTextObject, Origin.transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);

    //     newText.transform.SetParent(ImageTarget.transform, true);

    //     newText.transform.rotation = Quaternion.LookRotation(Pivot.transform.position - newText.transform.position);

    //     Vector3 eulerAngles = newText.transform.eulerAngles;
    //     eulerAngles.x = eulerAngles.x * -1;
    //     eulerAngles.y += 180f;
    //     newText.transform.eulerAngles = eulerAngles;

    //     newText.GetComponent<TextMeshPro>().text = "Hello World!";
    // }

    // void Count2()
    // {
    //     GameObject newText = Instantiate(creatTextObject, Origin.transform.position + new Vector3(-0.3113458f, 0.1177335f, -0.1886542f), Quaternion.identity);

    //     newText.transform.SetParent(ImageTarget.transform, true);

    //     newText.transform.rotation = Quaternion.LookRotation(Pivot.transform.position - newText.transform.position);

    //     Vector3 eulerAngles = newText.transform.eulerAngles;
    //     eulerAngles.x = eulerAngles.x * -1;
    //     eulerAngles.y += 180f;
    //     newText.transform.eulerAngles = eulerAngles;

    //     newText.GetComponent<TextMeshPro>().text = "Hello World!";
    // }

    // void Count3()
    // {
    //     GameObject newText = Instantiate(creatTextObject, Origin.transform.position + new Vector3(-0.4047848f, 0.3891025f, -0.09521508f), Quaternion.identity);

    //     newText.transform.SetParent(ImageTarget.transform, true);

    //     newText.transform.rotation = Quaternion.LookRotation(Pivot.transform.position - newText.transform.position);

    //     Vector3 eulerAngles = newText.transform.eulerAngles;
    //     eulerAngles.x = eulerAngles.x * -1;
    //     eulerAngles.y += 180f;
    //     newText.transform.eulerAngles = eulerAngles;

    //     newText.GetComponent<TextMeshPro>().text = "Hello World!";
    // }

    // void Count4()
    // {
    //     GameObject newText = Instantiate(creatTextObject, Origin.transform.position + new Vector3(0.4047848f, 0.3891025f, -0.09521508f), Quaternion.identity);

    //     newText.transform.SetParent(ImageTarget.transform, true);

    //     newText.transform.rotation = Quaternion.LookRotation(Pivot.transform.position - newText.transform.position);

    //     Vector3 eulerAngles = newText.transform.eulerAngles;
    //     eulerAngles.x = eulerAngles.x * -1;
    //     eulerAngles.y += 180f;
    //     newText.transform.eulerAngles = eulerAngles;

    //     newText.GetComponent<TextMeshPro>().text = "Hello World!";
    // }

    // void Count5()
    // {
    //     GameObject newText = Instantiate(creatTextObject, Origin.transform.position + new Vector3(0.3113458f, 0.1177338f, -0.1886542f), Quaternion.identity);

    //     newText.transform.SetParent(ImageTarget.transform, true);

    //     newText.transform.rotation = Quaternion.LookRotation(Pivot.transform.position - newText.transform.position);

    //     Vector3 eulerAngles = newText.transform.eulerAngles;
    //     eulerAngles.x = eulerAngles.x * -1;
    //     eulerAngles.y += 180f;
    //     newText.transform.eulerAngles = eulerAngles;

    //     newText.GetComponent<TextMeshPro>().text = "Hello World!";
    // }
}