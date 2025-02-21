using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_MapScenes : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("k_GoogleMap");
    }
}
