using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public abstract class Agent : MonoBehaviour
{

    [SerializeField] PhysicsObject physicsObject;

    float maxSpeed;
    Vector3 maxForce;

    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = physicsObject.maxSpeed;

        maxForce = physicsObject.mass * physicsObject.acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();
    }

    public abstract void CalcSteeringForces();

    public Vector3 Seek(GameObject target)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = target.transform.position - physicsObject.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.velocity;

        // Return seek steering force
        return seekingForce;
    }


    public Vector3 Flee(GameObject target)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = target.transform.position - physicsObject.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed * 2;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.velocity;

        // Return seek steering force
        return seekingForce;
    }

}
