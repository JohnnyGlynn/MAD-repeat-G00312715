using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    //terrain collection
    public GameObject[] terrain;

    //position of the player
    private Transform player;

    //new tiles
    private float nextTile = 0.0f;
    private float tileLength = 10.0f;
    //max on screen
    private int totalTerrain = 10;

    //starter platform
    private float dontFall = 10.0f;

    private int lastPrimitive = 0;
    public float timer = 1.0f;

    //onscreen collection
    private List<GameObject> onScreen;

    void Start()
    {
        //List of tiles "alive"
        onScreen = new List<GameObject>();

        //Based on Player 1 tag for both single/multiplayer,
        //hence the z movement for scoring is modified in tandem in multiplayer
        //so that the second player cannot be outrun
        player = GameObject.FindGameObjectWithTag("Player1").transform;

        for (int i = 0; i < totalTerrain; i++)
        {
            if (i < 2)
                NewTile(0);//start randomising
            else
                NewTile();//give player safe start zone
        }
    }

    void Update()
    {
        if(player.position.z - dontFall > (nextTile - totalTerrain * tileLength))
        {
            //add new tile
            NewTile();
            //if tiles is at maximum start deleting
            CleanUp();
        }
    }

    //new tiles
    private void NewTile(int tileIndex = -1)
    {
        GameObject obj;
        if (tileIndex == -1)
        {
            obj = Instantiate(terrain[Rand()]) as GameObject; //new random object
        }
        else
        {
            //Always spawn the double wide tile in the center as the first tile
            //then start randomising left or right after return
            obj = Instantiate(terrain[tileIndex]) as GameObject;
            obj.transform.SetParent(transform);
            obj.transform.position = Vector3.forward * nextTile;
            nextTile += tileLength;
            onScreen.Add(obj);
            return;
        }

        //"procedurally" generate the levels, left/right shifting
        int x = Random.Range (0, 3);
        switch (x) {
        case 0:
                //left shift
                obj.transform.SetParent(transform);
                obj.transform.position = Vector3.left * 1f * nextTile;
                obj.transform.position = Vector3.forward * nextTile;
                obj.transform.position = (Vector3.forward * nextTile) + (Vector3.left * 1f);
                break;
        case 1:
                //go forward
                obj.transform.SetParent(transform);
                obj.transform.position = Vector3.forward * nextTile;
                break;
        case 2:
                //Right shift
                obj.transform.SetParent(transform);
                obj.transform.position = Vector3.right * 1f * nextTile;
                obj.transform.position = Vector3.forward * nextTile;
                obj.transform.position = (Vector3.forward * nextTile) + (Vector3.right * 1f);
                break;
        }

        //left only
        //obj.transform.position = Vector3.left * 0.5f;
        ////Debug.Log(obj.transform.position = Vector3.left * 0.5f);
        //obj.transform.position = Vector3.forward * nextTile;
        ////Debug.Log(obj.transform.position = Vector3.forward * nextTile);
        //obj.transform.position = (Vector3.forward * nextTile) + (Vector3.left * 0.5f * nextTile);
        ////Debug.Log(obj.transform.position = (Vector3.forward * nextTile) + (Vector3.left * 0.5f * nextTile));
        ////Debug.Log(nextTile);

        nextTile += tileLength;
        onScreen.Add(obj);
    }

    //delete old tiles
    private void CleanUp()
    {
        Destroy(onScreen[0]);
        onScreen.RemoveAt(0);
    }

    //object randomisation
    private int Rand()
    {
        //no random
        if (terrain.Length <= 1)
        {
            return 0;
        }
        //start randomising
        int randIdx = lastPrimitive;
        while (randIdx == lastPrimitive)
        {
            randIdx = Random.Range(0, terrain.Length);
        }

        lastPrimitive = randIdx;
        return randIdx;
    }
}
