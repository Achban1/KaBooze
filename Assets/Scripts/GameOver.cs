using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Player dead;
    private bool gameOver;
    public GameObject GameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        dead = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = dead.playerIsAlive;
        if (gameOver == false)
        {
            SwitchToGameOver();
            Debug.Log("Game Over!");
        }
    }

    public void SwitchToGameOver()
    {
        GameOverMenu.SetActive(true);
        Invoke("quit", 0.4f);
        Time.timeScale = 0.2f;
        

    }
    private void quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
