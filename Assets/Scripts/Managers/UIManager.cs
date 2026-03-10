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
    public int enemiesKilled=0;
    Player player;

    EnemySpawner enemy;
    private void OnEnable()
    {
        Player.OnPlayerDeath+=GameOver;
        Player.OnHit+=UpdateHealth;
        GameManager.OnCoinsAdded+=UpdateCounter;
        EnemyDamage.OnKill+=UpdateKillCount;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath-=GameOver;
        Player.OnHit-=UpdateHealth;
        GameManager.OnCoinsAdded-=UpdateCounter;
        EnemyDamage.OnKill-=UpdateKillCount;
    }

    private void Start()
    {
        player=FindAnyObjectByType<Player>();
        gameOver.SetActive(false);
    }

    private void Update()
    {
        //check turret costs to make turret buttons interactable
        if (GameManager.Instance.coins >= 5)
            NormalBTTN.interactable=true;
        if (GameManager.Instance.coins >= 10)
            machineGunBTTN.interactable=true;
        if(GameManager.Instance.coins>=15)
            areaBTTN.interactable=true;
        else
        {
            NormalBTTN.interactable=false;
            machineGunBTTN.interactable=false;
            areaBTTN.interactable=false;
        }
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

    public void UpdateKillCount()
    {
        enemiesKilled++;
    }


    //when the event OnPlayerDeath is called 
    public void GameOver()
    {
        //pauses the game, activates the game over screen and shows the enemies defeated text
        GameManager.Instance.status=GameStatus.GamePaused;
        gameOver.SetActive(true);
        enemiesDefeated.text="Enemies defeated: "+ enemiesKilled;//inserisci numero nemici sconfitti;
    }
}

