using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    Transform player;
    public Vector3 offset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(offset.x, player.position.y + offset.y, player.position.z + offset.z);
        transform.position = pos;
    }
}
