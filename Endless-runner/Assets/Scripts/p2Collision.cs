using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Collision : MonoBehaviour
{
    //get multiplayer controller to use functions
    public MultiplayerController mp;

    //pickups
    private int rod = 50;
    private int core = 100;

    private void OnTriggerEnter(Collider p)
    {
        //fell to death
        if (p.transform.CompareTag("DeathPlane"))
        {
            //Debug.Log("p2: Died");
            mp.die();
        }

        //got by enemy
        if (p.transform.CompareTag("Enemy"))
        {
            //Debug.Log("p2: Bad Guy got ya");
            mp.die();
        }

        //collected plutonium rod
        if (p.transform.CompareTag("Collectible"))
        {
            //Debug.Log("p2: Collected plutonium rod");
            mp.addScore2(rod);
            Destroy(p.gameObject);
        }

        //collected plutonium core
        if (p.transform.CompareTag("Collectible2"))
        {
            //Debug.Log("p2: Collected Core");
            mp.addScore2(core);
            Destroy(p.gameObject);
        }

    }
}
