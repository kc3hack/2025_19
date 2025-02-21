using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_ShareScenes : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("K_S_Share");
    }
}
