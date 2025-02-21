using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_TitleScenes : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("k_Title");
    }
}
