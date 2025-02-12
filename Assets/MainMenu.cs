using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Multiplayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Singleplayer()
    {
        
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
