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
    [SerializeField] Button NormalBTTN,machineGunBTTN, areaBTTN;
    Player player;

    EnemySpawner enemy;
    private void OnEnable()
    {
        Player.OnPlayerDeath+=GameOver;
        Player.OnHit+=UpdateHealth;
        GameManager.OnCoinsAdded+=UpdateCounter;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath-=GameOver;
        Player.OnHit-=UpdateHealth;
        GameManager.OnCoinsAdded-=UpdateCounter;
    }

    private void Start()
    {
        player=FindAnyObjectByType<Player>();
        gameOver.SetActive(false);
    }

    private void Update()
    {
        //check turret costs to make turret buttons interactable
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Updates the HUD Helthbar
    public void UpdateHealth()
    {
        health.fillAmount=player.currentHP/player.maxHP;
    }

    //Updates the HUD currency
    public void UpdateCounter()
    {
        coins.text="Coins:"+GameManager.Instance.coins.ToString();
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

