using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private float speed = 5.0f;
    private float playerScore = 0;
    private string powerup = "";
    // Start is called before the first frame update
    //initialise player settings
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    /*
    Update player position
    Update next tiles/potential next collisions
    Update score
    Check Collisions
    --If obstacle collisions, hurt player, if health = 0/3 end game
    --If coin collisions, award player, update score
    --If powerup collisions, add effect player
    While powerup do
    --Ghost mode, no collions
    --double points
    --extra life
    Check difficulty level and adjust accordingly, score deciding factor factors
    adjust difficulty by
    --spawing more obstacled terain/not spawning a block
    --speed increase l1 100%, l2 150%, l3 250%
    */
    void Update()
    {
        controller.Move((Vector3.forward * speed) * Time.deltaTime);
        score();


        //check if grounded
        //check that not clipping into wall
        if (Input.GetButtonDown("Left"))
        {
            Debug.Log("left");
            //controller.SimpleMove(left * speed)?
            //move until wall

        }
        else if (Input.GetButtonDown("Right"))
        {
            Debug.Log("right");
            //controller.SimpleMove(right * speed)?
            //move until wall

        }
        else if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump");
            //controller.SimpleMove(jump * speed)?
            //jump to clear obstacles
            //potential double jump scenario??
            //jump();
        }
    }

    //move somthing
    void movementOption()
    {
        //left right
        //scrap this function probably
    }

    //jump
    void jump()
    {
        //potentially want to manipulate gravity here
        controller.Move(Vector3.up * Time.deltaTime);
        //potentially scrap
    }

    //score
    void score()
    {
        //if picks up coin add x score
        //add score while runngin
        //time manipulation
        playerScore += Time.deltaTime;
    }

    //hurt
    void getHurt()
    {
        //hit obstacle get hurt
    }

    //die
    void die()
    {
        //3 hits, die
    }

    void powerupStatus()
    {
        //handle powerups
        if (powerup == "")
        {
            //do nothing
        }
        else if (powerup == "2x")
        {
            //double scoring for x time

        }
        else if (powerup == "gm")
        {
            //do nothing
            //"god mode", no damage collisions off
        }
        else if (powerup == "xl")
        {
            //do nothing
            //add an extra health, regnerate lost health
        }
    }
}
