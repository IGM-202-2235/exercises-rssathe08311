using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] Agent target;


    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 seekForce = Seek(target);

        return seekForce;
    }

    
}
