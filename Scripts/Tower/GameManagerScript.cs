using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// check health and win condition
public class GameManagerScript : MonoBehaviour
{
    public TowerHitPoints teamATower;
    public TowerHitPoints teamBTower;
    [SerializeField] private TextMeshProUGUI gameStatus;
    [SerializeField] private GameObject EndGameScreen;

    void Update()
    {
        // Check game over conditions
        if (teamATower.CurrentHealth <= 0)
        {
            TeamBWins();
        }
        else if (teamBTower.CurrentHealth <= 0)
        {
            TeamAWins();
        }
    }

    void TeamAWins()
    {
        // Handle Team A victory logic
        Debug.Log("You win!");
        EndGameScreen.SetActive(true);        
        gameStatus.text = "You win!";
        Time.timeScale = 0f;
    }

    void TeamBWins()
    {
        // Handle Team B victory logic
        Debug.Log("Enemy wins!");
        EndGameScreen.SetActive(true);
        gameStatus.text = "Enemy wins!";
        gameStatus.color = Color.red;
        Time.timeScale = 0f;
    }
}
