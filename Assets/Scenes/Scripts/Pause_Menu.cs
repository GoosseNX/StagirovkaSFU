using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    public static bool GameIsPause = false;

    public GameObject Pause_Menu_UI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Pause_Menu_UI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        Player.GetComponent<Player_Controller>().enabled = true;
        
    }
    void Pause()
    {
        Pause_Menu_UI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        Player.GetComponent<Player_Controller>().enabled = false;

    }
    public void DebugMetod()
    {
        Debug.Log("Hiii");
    }
    public void Exit()
    {
        Debug.Log("завершение игры");
        Application.Quit();
    }
    public void Restart() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
