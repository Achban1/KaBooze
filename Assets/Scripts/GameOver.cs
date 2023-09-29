using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Player playerIsDead;
    private bool gameOver;
    public GameObject GameOverMenu;


    void Start()
    {
        playerIsDead = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    void Update()
    {
        gameOver = playerIsDead.playerIsAlive;
        if (gameOver == false)
        {
            SwitchToGameOver();
           
        }
    }

    public void SwitchToGameOver()
    {
        GameOverMenu.SetActive(true);
        Invoke(nameof(Quit), 0.4f);
        Time.timeScale = 0.2f;
    }
    private void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
