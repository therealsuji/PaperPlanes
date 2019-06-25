using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstcleSpawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    Transform player;
    GameObject currentSpawnObj;
    GameObject closestSpawnedObj;
    List<GameObject> spawnedObjArray;
    float currentSpawnDistance = 50f;
    public float spawnDistance;
    void Start()
    {
        spawnedObjArray = new List<GameObject>();
        player = GameManager.instance.player.GetComponent<Transform>();

        for (int x = 0; x < 5; x++)
        {
            spawnObjects();
        }
        closestSpawnedObj = spawnedObjArray[0] as GameObject;

    }

    void FixedUpdate()
    {

        if (distanceToPlayer() < 500)
        {
            spawnObjects();
        }
        if (player.transform.position.z > 30)
        {
            if (distanceToPlayerFromClosestSpawn() > 50)
            {
                destroyPassedObj();

            }
        }



    }

    float distanceToPlayer()
    {

        return Vector3.Distance(player.position, currentSpawnObj.transform.position);
    }

    float distanceToPlayerFromClosestSpawn()
    {
        return Vector3.Distance(player.position, closestSpawnedObj.transform.position);
    }


    void destroyPassedObj()
    {
        Destroy(closestSpawnedObj);
        spawnedObjArray.RemoveAt(0);
        closestSpawnedObj = spawnedObjArray[0] as GameObject;

    }
    void spawnObjects()
    {
        GameObject obj = Instantiate(ObjectToSpawn);
        Vector3 pos = new Vector3(0, 2.5f, currentSpawnDistance);
        obj.transform.position = pos;
        currentSpawnObj = obj;
        spawnedObjArray.Add(obj);
        currentSpawnDistance += spawnDistance;
    }
}
