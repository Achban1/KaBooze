using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Paused = false;
    public GameObject PauseMenu;
    public GameObject MenuMenu;
    // Update is called once per frame
    void Update()
    {

  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                
                Pause();
            }
        }



    }
    public void SwitchToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        MenuMenu.SetActive(false);
        Paused = false;
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        MenuMenu.SetActive(true);
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        Paused = true;
    }
}




