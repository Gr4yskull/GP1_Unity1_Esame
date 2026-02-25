using UnityEngine;

public enum GameStatus
{
    GamePaused,
    GameRunning
}

public class GameManager : MonoBehaviour
{
    public GameStatus status;
    public int coins;
   //public static event Action AddCoins;

    private void Update()
    {
        if(status==GameStatus.GamePaused)
            Time.timeScale=0f;
        else
            Time.timeScale=1f;
    }

}
