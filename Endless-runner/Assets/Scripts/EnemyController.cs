using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float patrolTime = 3.0f;
    private bool forward = true;

    // Update is called once per frame
    void Update()
    {
        patrol();
    }

    void patrol()
    {
        //Go forward for patrol time, reverse direction at the end
        if(forward == true)
        {
            patrolTime -= Time.deltaTime;//decrease patrol time
            transform.position += Vector3.forward * Time.deltaTime;
            if(patrolTime < 0) {
                forward = false;
            }
        } else if (forward == false)
        {
            patrolTime += Time.deltaTime;//increase patrol time
            transform.position += Vector3.back * Time.deltaTime;
            if (patrolTime >= 3)
            {
                forward = true;
            }
        }
    }
}
