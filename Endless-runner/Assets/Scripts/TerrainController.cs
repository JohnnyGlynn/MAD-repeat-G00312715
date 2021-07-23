using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class TerrainController : MonoBehaviour
{

    public GameObject[] terrain;

    private Transform player;
    private float nextTile = 0.0f;
    private float tileLength = 10.0f;
    private int totalTerrain = 10;
    private float dontFall = 10.0f;
    private int lastPrimitive = 0;

    private List<GameObject> onScreen;

    // Start is called before the first frame update
    /*
    Generate inital platform and camera control
    */
    void Start()
    {
        onScreen = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < totalTerrain; i++)
        {
            if (i < 2)
                NewTile(0);
            else
                NewTile();
        }
    }

    // Update is called once per frame
    /*
    Generate terain, 
        pick from 
        blank platform, 
        platform with coin, 
        platform with obstacle, 
        platform with obstacle and coin, 
        no platform
    */
    void Update()
    {
        if(player.position.z - dontFall > (nextTile - totalTerrain * tileLength))
        {
            NewTile();
            CleanUp();
        }
    }

    //new tiles
    private void NewTile(int tileIndex = -1)
    {
        GameObject obj;
        if(tileIndex == -1)
            obj = Instantiate(terrain[Rand()]) as GameObject; //new random object
        else
            obj = Instantiate(terrain[tileIndex]) as GameObject;
        obj.transform.SetParent(transform);
        obj.transform.position = Vector3.forward * nextTile;
        nextTile += tileLength;
        onScreen.Add(obj);
    }

    //delete old tiles
    private void CleanUp(int tileIndex = -1)
    {
        Destroy(onScreen[0]);
        onScreen.RemoveAt(0);
    }

    //object randomisation
    private int Rand()
    {
        if (terrain.Length <= 1)
        {
            return 0;
        }

        int randIdx = lastPrimitive;
        while (randIdx == lastPrimitive)
        {
            randIdx = Random.Range(0, terrain.Length);
        }

        lastPrimitive = randIdx;
        return randIdx;
    }
}
