using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerController : MonoBehaviour
{
    //players
    public GameObject p1;
    public GameObject p2;

    //player object controllers
    private CharacterController p1Controller;
    private CharacterController p2Controller;

    public MultiplayerUiController ui;

    //zeroing vectors
    private Vector3 p1Movement = Vector3.zero;
    private Vector3 p2Movement = Vector3.zero;

    //physics attributes
    private float jumpVelocity = 6.0f;
    private float speed = 5.0f;
    private float gravity = 7.0f;

    //pickups
    private int rod = 50;
    private int core = 100;

    //player scores
    private float score1 = 0.0f;
    private float score2 = 0.0f;

    private float highestScore = 0.0f;

    void Start()
    {
        //get player controllers from their game objects
        p1Controller = p1.GetComponent<CharacterController>();
        p2Controller = p2.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (score1 > score2)
        {
            highestScore = score1;
        }else if (score1 < score2)
        {
            highestScore = score2;
        }

        //x - Left/Right
        p1Movement.x = Input.GetAxisRaw("Horizontal") * speed;
        p2Movement.x = Input.GetAxisRaw("Player2") * speed;

        //y - Jump 
        if (p1Controller.isGrounded && Input.GetButton("Jump"))
        {
            p1Movement.y = jumpVelocity;
        }

        if (p2Controller.isGrounded && Input.GetButton("Jump2"))
        {
            p2Movement.y = jumpVelocity;
        }

        p1Movement.y -= gravity * Time.deltaTime;
        p2Movement.y -= gravity * Time.deltaTime;

        //z - Run + Speed Difficulty
        if (highestScore < 750.0f)
        {
            p1Movement.z = speed;
            p2Movement.z = speed;
        }
        else if (highestScore > 1500.0f && highestScore < 3000.0f)
        {
            p1Movement.z = speed * 1.25f;
            p2Movement.z = speed * 1.25f;
        }
        else if (highestScore > 3000.0f && highestScore < 5000.0f)
        {
            p1Movement.z = speed * 1.75f;
            p2Movement.z = speed * 1.75f;
        }
        else if (highestScore > 5000.0f && highestScore < 100000.0f)
        {
            p1Movement.z = speed * 2.0f;
            p2Movement.z = speed * 2.0f;
        }
        else if (highestScore > 10000.0f)
        {
            p1Movement.z = speed * 3.0f;
            p2Movement.z = speed * 3.0f;
        }

        //Add all the movement
        p1Controller.Move(p1Movement * Time.deltaTime);
        p2Controller.Move(p2Movement * Time.deltaTime);

        //score tracking
        timeScore();
        ui.keepScore(score1, score2);

    }

    //"still standing" timer score
    public void timeScore()
    {
        score1 += Time.deltaTime;
        score2 += Time.deltaTime;
    }

    //award player 1 points
    public void addScore1(int s)
    {
        score1 += s;
    }

    //award player 2 points
    public void addScore2(int s)
    {
        score2 += s;
    }

    //A player has died, end the game
    public void die()
    {
        //Debug.Log("Dead");
        ui.DeathScreen(score1, score2);
    }


}
