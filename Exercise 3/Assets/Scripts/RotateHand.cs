using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    //variables 
    Vector3 turnAmount = new Vector3(0, 0, -6);//moves 6 degrees every second so that a full rotation is completed in 1 minute 
    [SerializeField]
    Boolean useDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!useDeltaTime)
        {
            transform.Rotate(turnAmount);

        }
        else
        {
            transform.Rotate(turnAmount * Time.deltaTime);
        }
    }
}
