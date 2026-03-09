using UnityEngine;
using System;

public enum GameStatus
{
    GamePaused,
    GameRunning
}

public class GameManager : MonoBehaviour
{
    public GameStatus status;
    public int coins;
    public static GameManager Instance;
    public static event Action OnCoinsAdded;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    public void OnEnable()
    {
        EnemyDamage.OnEnemyDeath+=GetCoins;
    }

    public void Disable()
    {
        EnemyDamage.OnEnemyDeath-=GetCoins;
    }

    public void GetCoins(int money)
    {
        coins+=money;
        OnCoinsAdded?.Invoke();
    }
    public void RemoveCoins(int money)
    {
        coins-=money;
        OnCoinsAdded.Invoke();
    }
    
    private void Start()
    {
        status=GameStatus.GameRunning;
        GetCoins(50);
    }
    private void Update()
    {
        if(status==GameStatus.GamePaused)
            Time.timeScale=0f;
        else
            Time.timeScale=1f;
    }

}
