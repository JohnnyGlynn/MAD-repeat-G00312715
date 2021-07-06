using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private float speed = 5.0f;
    private float playerScore = 0;
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
    }

    //move somthing
    void movementOption()
    {
        //left right
    }

    //jump
    void jump()
    {
        //potentially want to manipulate gravity here
        controller.Move(Vector3.up * Time.deltaTime);
    }

    //score
    void score()
    {
        //if picks up coin add x score
        //add score while runngin
        //time manipulation
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

    void powerup()
    {
        //handle powerups
    }
}
