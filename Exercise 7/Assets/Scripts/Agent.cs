using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{

    [SerializeField] public PhysicsObject physicsObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = CalculateSteeringForces();
        physicsObject.ApplyForce(force);

    }

    protected abstract Vector3 CalculateSteeringForces();

    public Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * physicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.velocity;

        // Return seek steering force
        return seekingForce;

    }

    public Vector3 Seek(Agent target)
    {
        return Seek(target.transform.position);
    }

    
    public Vector3 Flee(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity =  transform.position - targetPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * physicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 fleeingForce = desiredVelocity - physicsObject.velocity;

        // Return seek steering force
        return fleeingForce;
    }

    public Vector3 Flee(Agent target)
    {
        return Flee(target.transform.position);
    }

}
