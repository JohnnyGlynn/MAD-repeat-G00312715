using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Button StartGame_bt = null;
    [SerializeField] private Button Multiplayer_bt = null;
    [SerializeField] private Button HowTo_bt = null;
    [SerializeField] private Button Quit_bt = null;
    [SerializeField] private Button BackToMenu_bt = null;


    GameObject[] MainMenu;
    GameObject[] MultiplayerMenu;
    GameObject[] HowTo;
    GameObject[] Settings;

    void Start()
    {
        StartGame_bt.onClick.AddListener(() => { StartGame(); });//start single player
        Multiplayer_bt.onClick.AddListener(() => { StartMultiplayer(); });//start multi player
        HowTo_bt.onClick.AddListener(() => { HowToPlay(); });//show how to play screen
        Quit_bt.onClick.AddListener(() => { Quit(); });//quit application

        BackToMenu_bt.onClick.AddListener(() => { BackToMenu(); });//back to main menu from how to play

        MainMenu = GameObject.FindGameObjectsWithTag("UI");//get main menu items
        HowTo = GameObject.FindGameObjectsWithTag("HowToPlay");//get how to play items

        ShowHowToPlay(false);//hide how to play
    }

    //start game
    void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    //start multiplayer
    void StartMultiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    void HowToPlay()
    {
        ShowHowToPlay(true);
    }

    void BackToMenu()
    {
        ShowHowToPlay(false);
    }

    //show/hide how to play
    void ShowHowToPlay(bool tf)
    {
        if (tf == true)
        {
            //Showing howto
            foreach (GameObject go in HowTo)
            {
                go.SetActive(true);
            }

            //Hiding main menu
            foreach (GameObject u in MainMenu)
            {
                u.SetActive(false);
            }

        }
        else if (tf == false)
        {
            //Hiding howto
            foreach (GameObject go in HowTo)
            {
                go.SetActive(false);
            }

            //Showing main menu
            foreach (GameObject u in MainMenu)
            {
                u.SetActive(true);
            }
        }
    }

    //terminate application
    void Quit()
    {
        Application.Quit();
    }

}
