using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Characters controller
    private CharacterController controller;

    //Ui functions
    public UiController ui;

    //zeroing
    private Vector3 movement = Vector3.zero;

    //physics attributes
    private float jumpVelocity = 6.0f;
    private float speed = 5f;
    private float gravity = 7.0f;

    //score
    private float score = 0.0f;

    //pickups
    private int rod = 50;
    private int core = 100;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //x
        movement.x = Input.GetAxisRaw("Horizontal") * speed;
        //y
        //http://docs.unity3d.com/Documentation/ScriptReference/CharacterController.Move.html
        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            movement.y = jumpVelocity;
        }
        movement.y -= gravity * Time.deltaTime;
        //z
        if(score < 750.0f)
        {
            movement.z = speed;
        } else if (score > 1500.0f && score < 3000.0f)
        {
            movement.z = speed * 1.25f;
        } else if (score > 3000.0f && score < 5000.0f)
        {
            movement.z = speed * 1.75f;
        } else if (score > 5000.0f && score < 100000.0f)
        {
            movement.z = speed * 2.0f;
        } else if (score > 10000.0f)
        {
            movement.z = speed * 3.0f;
        }
        
        //assign movements to the controller
        controller.Move(movement * Time.deltaTime);

        timeScore();
        ui.keepScore(score);

    }

    //collision detection
    private void OnTriggerEnter(Collider p)
    {
        //fell to death
        if (p.transform.CompareTag("DeathPlane"))
        {
            //Debug.Log("You died");
            die();
        }

        //hit by enemy
        if (p.transform.CompareTag("Enemy"))
        {
            //Debug.Log("Bad Guy got ya");
            die();
        }

        //collected plutonium rod
        if (p.transform.CompareTag("Collectible"))
        {
            //Debug.Log("Collected plutonium rod");
            addScore(rod);
            Destroy(p.gameObject);
        }

        //collected plutonium core
        if (p.transform.CompareTag("Collectible2"))
        {
            //Debug.Log("Collected plutonium core");
            addScore(core);
            Destroy(p.gameObject);
        }
    }

    //"Still standing" timer score
    public void timeScore()
    {
        score += Time.deltaTime;
    }

    //award score
    public void addScore(int s)
    {
        score += s;
    }

    //die
    void die()
    {
        //Debug.Log("Dead");
        ui.DeathScreen(score);
    }
}
