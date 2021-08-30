using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    //game object collections for showing/hiding
    GameObject[] ui;
    GameObject[] pauseMenu;
    GameObject[] endScreen;

    //score
    [SerializeField]public Text scoreUI;
    [SerializeField] public Text finalScore;

    //pause button
    [SerializeField] private Button Pause_bt = null;

    //pause menu buttons
    [SerializeField] private Button Resume_bt = null;
    [SerializeField] private Button Restart_bt = null;
    [SerializeField] private Button MainMenu_bt = null;
    [SerializeField] private Button Quit_bt = null;

    //endscreen
    [SerializeField] private Button EndMainMenu_bt = null;
    [SerializeField] private Button Retry_bt = null;

    void Start()
    {
        //pause button
        Pause_bt.onClick.AddListener( () => { Pause(); } );

        //pause menu buttons
        Resume_bt.onClick.AddListener(() => { Resume(); });
        Restart_bt.onClick.AddListener(() => { Restart(); });
        MainMenu_bt.onClick.AddListener(() => { MainMenu(); });
        Quit_bt.onClick.AddListener(() => { Quit(); });

        //endscreen
        EndMainMenu_bt.onClick.AddListener(() => { MainMenu(); });
        Retry_bt.onClick.AddListener(() => { Restart(); });

        //objects by tag
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        endScreen = GameObject.FindGameObjectsWithTag("EndScreen");
        ui = GameObject.FindGameObjectsWithTag("UI");

        ShowPauseMenu(false);
        ShowEndScreen(false);
    }

    //award score
    public void keepScore(float score)
    {
        scoreUI.text = "Score: "+((int)score).ToString();
    }

    //show hide pause menu
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

    //show/hide end screen
    void ShowEndScreen(bool i)
    {
        if (i == true)
        {
            //Showing end screen
            foreach (GameObject go in endScreen)
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
            //Hiding endscreen
            foreach (GameObject go in endScreen)
            {
                go.SetActive(false);
            }
        }
    }

    //take score, show end screen
    public void DeathScreen(float score)
    {
        finalScore.text = "Your Score: " + ((int)score).ToString();
        Time.timeScale = 0;
        ShowEndScreen(true);
    }

    //pause
    void Pause()
    {
        ShowPauseMenu(true);
        Time.timeScale = 0;
    }

    //resume
    void Resume()
    {
        ShowPauseMenu(false);
        Time.timeScale = 1;
    }

    //restart
    void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //back to main menu
    void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    //terminate application
    void Quit()
    {
        Application.Quit();
        Time.timeScale = 1;//probably not needed
    }
}
