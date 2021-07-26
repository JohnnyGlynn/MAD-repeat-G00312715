using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{

    private float score = 0.0f;
    private float health = 3.0f;
    private int timer;

    [SerializeField] private Button pause = null; 

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
        pause.onClick.AddListener(() => { ingameUI(); });
    }

    // Update is called once per frame
    //Probably not neccesary
    void Update()
    {
        
    }

    //Function for N options to load bits
    void option1_to_N()
    {

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
    void ingameUI()
    {
        Debug.Log("Hello " + gameObject.name);
    }
}
