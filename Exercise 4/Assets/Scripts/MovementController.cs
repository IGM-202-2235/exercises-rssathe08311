using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;

    Vector3 direction = Vector3.up;

    Vector3 velocity = Vector3.zero;

    [SerializeField] float speed;

    [SerializeField] Camera cameraObject;

    public Vector3 Direction
    {
        set { direction = value.normalized; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Grab the GameObject’s starting position
        objectPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //do checks for object position here to make it stay within bounds, wrap the movement - make it a method that you pass a vecotor into :)))))

        ScreenWrap();

        //Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        //Add velocity to position
        objectPosition += velocity;

        //Validate new calculated position

        // “Draw” this vehicle at that position
        transform.position = objectPosition;

        if (direction != Vector3.zero)
        {
            //Set the vehicle's rotation to match the direction
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }
    }

    void ScreenWrap()
    {
        float totalCamHeight = (cameraObject.orthographicSize * 2f) / 2;
        float totalCamWidth = (totalCamHeight * cameraObject.aspect);

        if ((objectPosition.y >= totalCamHeight) || (objectPosition.y <= (totalCamHeight * -1)))
        {
            objectPosition.y *= -1;
        }
        if ((objectPosition.x >= totalCamWidth) || (objectPosition.x <= (totalCamWidth * -1)))
        {
            objectPosition.x *= -1;
        }
    }


}
