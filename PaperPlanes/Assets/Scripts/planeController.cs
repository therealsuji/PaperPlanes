using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeController : MonoBehaviour
{
    public float speed;
    public Camera MainCamera;
    private Vector2 screenBounds;

    private float objectWidth;
    private float objectHeight;
    public float forwardSpeed;
    public float downAngle;
    public float upAngle;


    public float widthBound;
    public float heightBound;
    public float xSpeed;




    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

        objectWidth = transform.GetComponent<BoxCollider>().bounds.extents.x / 2; //extents = size of width / 2
        objectHeight = transform.GetComponent<BoxCollider>().bounds.extents.y / 2; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {


        if (!GameManager.instance.playerDead)
        {
            if (Input.touchCount > 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(upAngle, 0, 0), Time.deltaTime);
                transform.Translate(Input.acceleration.x * Time.deltaTime * xSpeed, 0.01f, forwardSpeed * Time.deltaTime);
            }
            else
            {
                if (transform.position.z > 20)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(downAngle, 0, 0), Time.deltaTime);
                    transform.Translate(Input.acceleration.x * Time.deltaTime * xSpeed, -0.01f, forwardSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Input.acceleration.x * Time.deltaTime * xSpeed, -0.01f, forwardSpeed * Time.deltaTime);

                }

            }
            if (transform.position.y < -8.5)
            {
                GameManager.instance.playerDead = true;
            }
        }
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -widthBound, widthBound);
        viewPos.y = Mathf.Clamp(viewPos.y, -heightBound, heightBound);
        transform.position = viewPos;
    }
}
