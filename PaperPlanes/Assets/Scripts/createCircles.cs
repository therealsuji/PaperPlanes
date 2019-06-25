using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCircles : MonoBehaviour
{
    public GameObject circle;
    void Start()
    {
        circle = Instantiate(circle);
        circle.transform.parent = this.gameObject.transform;
        circle.transform.position = RandomPointInBounds(this.GetComponent<BoxCollider>().bounds);
        circle.transform.rotation = Quaternion.identity;
    }


    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
