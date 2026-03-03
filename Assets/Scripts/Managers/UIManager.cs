using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image health;
    [SerializeField] GameObject gameOver;
    [SerializeField] TMP_Text coins;
    [SerializeField] TMP_Text enemiesDefeated;
    Player player;

    EnemySpawner enemy;
    private void OnEnable()
    {
        Player.OnPlayerDeath+=GameOver;
        Player.OnHit+=UpdateHealth;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath-=GameOver;
        Player.OnHit-=UpdateHealth;
    }

    private void Start()
    {
        player=FindAnyObjectByType<Player>();
        gameOver.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateHealth()
    {
        health.fillAmount=player.currentHP/player.maxHP;
    }

    //when the event OnPlayerDeath is called 
    public void GameOver()
    {
        //pauses the game, activates the game over screen and shows the enemies defeated text
        GameManager.Instance.status=GameStatus.GamePaused;
        gameOver.SetActive(true);
        enemiesDefeated.text="Enemies defeated:";//inserisci numero nemici sconfitti;
    }
}

