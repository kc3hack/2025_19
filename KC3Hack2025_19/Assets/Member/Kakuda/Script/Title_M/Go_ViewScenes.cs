using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_ViewScenes : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("K_S_View");
    }
}
