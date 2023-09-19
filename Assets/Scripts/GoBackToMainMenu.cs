using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBackToMainMenu : MonoBehaviour
{

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchToMainMenu();
        }
    }

    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
