using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public float rotate = 15.0f;

    void Update()
    {
        rotation();
    }

    //rotate the collectible
    void rotation()
    {
        transform.Rotate(Vector3.right, rotate * Time.deltaTime);
    }
}
