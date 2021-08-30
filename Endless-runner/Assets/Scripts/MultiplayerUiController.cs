using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiplayerUiController : MonoBehaviour
{
    //collections for ui components
    GameObject[] ui;
    GameObject[] pauseMenu;
    GameObject[] endScreen;

    //score
    [SerializeField] public Text p1Score;
    [SerializeField] public Text p2Score;
    [SerializeField] public Text finalScore;

    //winner decision
    [SerializeField] public Text Winner;

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
        Pause_bt.onClick.AddListener(() => { Pause(); });

        //pause menu buttons
        Resume_bt.onClick.AddListener(() => { Resume(); });
        Restart_bt.onClick.AddListener(() => { Restart(); });
        MainMenu_bt.onClick.AddListener(() => { MainMenu(); });
        Quit_bt.onClick.AddListener(() => { Quit(); });

        //endscreen
        EndMainMenu_bt.onClick.AddListener(() => { MainMenu(); });
        Retry_bt.onClick.AddListener(() => { Restart(); });

        //get objects based on tag, add to ui item collections
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        endScreen = GameObject.FindGameObjectsWithTag("EndScreen");
        ui = GameObject.FindGameObjectsWithTag("UI");

        //hide pause/endscreen
        ShowPauseMenu(false);
        ShowEndScreen(false);
    }

    //"Still standing" time score
    public void keepScore(float score1, float score2)
    {
        p1Score.text = "Score: " + ((int)score1).ToString();
        p2Score.text = "Score: " + ((int)score2).ToString();
    }

    //show pause
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

    //Show end screen
    void ShowEndScreen(bool i)
    {
        if (i == true)
        {
            //Showing Pause Menu
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
            //Hiding pause
            foreach (GameObject go in endScreen)
            {
                go.SetActive(false);
            }
        }
    }

    //determine a winner/draw, show the end screen
    public void DeathScreen(float score1, float score2)
    {
        if (score1 > score2)
        {
            Winner.text = "Player1 wins!";
        }
        else if (score1 < score2)
        {
            Winner.text = "Player2 wins!";
        } else if (score1 == score2)
        {
            Winner.text = "Draw";
        }

        finalScore.text = "Scores\nPlayer1: " + ((int)score1).ToString() + " \nPlayer2: " + ((int)score2).ToString();

        Time.timeScale = 0;

        //present the deathscreen
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
