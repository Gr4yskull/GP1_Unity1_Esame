using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image health;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TMP_Text coins;
    [SerializeField] TMP_Text enemiesDefeated;
    [SerializeField] TMP_Text timerTXT;
    [SerializeField] Button NormalBTTN,machineGunBTTN, areaBTTN;
    public int enemiesKilled=0;
    public bool isPaused;
    string minutesTXT;
    string secondsTXT;
    float timer;
    float minutes;
    float seconds;
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
        ClosePauseMenu();
    }

    private void Update()
    {
        timer+=Time.deltaTime;
        minutes=Mathf.Floor(timer/60);
        seconds=Mathf.Floor(timer%60);
        //check turret costs to make turret buttons interactable
        if (GameManager.Instance.coins < 5)
            NormalBTTN.interactable=false;
        if (GameManager.Instance.coins < 10)
            machineGunBTTN.interactable=false;
        if(GameManager.Instance.coins < 15)
            areaBTTN.interactable=false;
        else
        {
            NormalBTTN.interactable=true;
            machineGunBTTN.interactable=true;
            areaBTTN.interactable=true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused==false)
        {
            OpenPauseMenu();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ClosePauseMenu();
        }
    }

    //button to go back to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        isPaused=true;
        GameManager.Instance.status=GameStatus.GamePaused;
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        isPaused=false;
        GameManager.Instance.status=GameStatus.GameRunning;
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

    //updates the kill count
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
        timerTXT.text=minutesTXT+" "+secondsTXT;
        timerTXT.text=string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}

