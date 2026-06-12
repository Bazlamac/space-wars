using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void QuitGame()
    {
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #else
            Application.Quit();
     #endif
    }

}

