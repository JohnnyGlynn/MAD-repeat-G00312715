using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform focus;
    private Vector3 offsetInit;

    // Start is called before the first frame update
    void Start()
    {
        focus = GameObject.FindGameObjectWithTag("Player").transform;
        offsetInit = transform.position - focus.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = focus.position + offsetInit;
    }
}
