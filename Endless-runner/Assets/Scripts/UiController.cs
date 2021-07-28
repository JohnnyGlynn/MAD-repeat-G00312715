using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{

    private float score = 0.0f;
    private float health = 3.0f;
    private int timer;

    GameObject[] ui;
    GameObject[] pauseMenu;

    //pause button
    [SerializeField] private Button Pause_bt = null;

    //pause menu buttons
    [SerializeField] private Button Resume_bt = null;
    [SerializeField] private Button Restart_bt = null;
    [SerializeField] private Button MainMenu_bt = null;
    [SerializeField] private Button Quit_bt = null;

    // Start is called before the first frame update
    /*
    Load main menu
        Options:
        Load single-player game
        Load multi-player game
        Scoreboard
        Options (Volume, Screen size?)
        Exit
    */
    void Start()
    {
        //pause button
        Pause_bt.onClick.AddListener( () => { Pause(); } );

        //pause menu buttons
        Resume_bt.onClick.AddListener(() => { Resume(); });
        Restart_bt.onClick.AddListener(() => { Restart(); });
        MainMenu_bt.onClick.AddListener(() => { MainMenu(); });
        Quit_bt.onClick.AddListener(() => { Quit(); });

        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        ui = GameObject.FindGameObjectsWithTag("UI");
        //pauseBackground = GameObject.get
        ShowPauseMenu(false);
    }

    // Update is called once per frame
    //Probably not neccesary
    void Update()
    {
        
    }

    //void HidePauseMenu()
    //{
    //    foreach (GameObject go in pauseMenu)
    //    {
    //        go.SetActive(false);
    //    }
    //}

    void ShowPauseMenu(bool i)
    {
        if (i == true)
        {
            //Showing Pause Menu
            foreach (GameObject go in pauseMenu)
            {
                go.SetActive(true);
            }

            //Hiding UI
            foreach (GameObject u in ui)
            {
                u.SetActive(false);
            }

        }
        else if (i == false)
        {
            //Hiding pause
            foreach (GameObject go in pauseMenu)
            {
                go.SetActive(false);
            }

            //Showing UI
            foreach (GameObject u in ui)
            {
                u.SetActive(true);
            }
        }
    }

    /*All relevant code for the in game UI, 
        Score, 
        Health, 
        Poweup status,
        Multiplayer:
            Scores,
            Health,
            Powerup,
            Scoreboard/Leader/Something to see whos winning????
    */

    void Pause()
    {
        ShowPauseMenu(true);
        Time.timeScale = 0;
    }

    void Resume()
    {
        ShowPauseMenu(false);
        Time.timeScale = 1;
    }

    void Restart()
    {
        //Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Quit()
    {
        Application.Quit();
    }
}
