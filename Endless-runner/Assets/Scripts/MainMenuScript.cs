using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Button StartGame_bt = null;
    [SerializeField] private Button Multiplayer_bt = null;
    [SerializeField] private Button Leaderboard_bt = null;
    [SerializeField] private Button Settings_bt = null;
    [SerializeField] private Button Quit_bt = null;

    GameObject[] mainMenu;
    GameObject[] MultiplayerMenu;
    GameObject[] Leaderboard;
    GameObject[] Settings;

    // Start is called before the first frame update
    void Start()
    {
        //PlayAnimationinTheBackgroundOrSomthing
        StartGame_bt.onClick.AddListener(() => { StartGame(); });
        Multiplayer_bt.onClick.AddListener(() => { StartMultiplayer(); });
        Leaderboard_bt.onClick.AddListener(() => { Settings(); });
        Settings_bt.onClick.AddListener(() => { Leaderboard(); });
        Quit_bt.onClick.AddListener(() => { Quit(); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        //change main to game?
        SceneManager.LoadScene("Main");
    }

    void StartMultiplayer()
    {
        //load multiplayer game
        //SceneManager.LoadScene("MainMenu");
        //load more ui components like pause
        //HideMenu(true, <SETTINGS/LEADERBOARD/MAINMENU>)
    }

    void Settings()
    {
        //open settings
        //load more ui components like pause
    }

    void Leaderboard()
    {
        //leaderboard
        //^^^^ maybe some aws?
        //load more UI components like pause
    }

    void Quit()
    {
        Application.Quit();
    }

    void HideMenu(bool tf, string[] tag)
    {
        //check for tags, set the tags based on tf true/false value
        for ()
        {

        }
    }

}
