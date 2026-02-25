using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //when you click the button you change into the play scene
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayGround");
    }

    //when you click the button you quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
