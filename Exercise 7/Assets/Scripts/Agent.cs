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

    //the only difference between evade and flee is target.calcFuturePosition * time
    public Vector3 Evade(Agent target)
    {
        return Flee(target.CalcFuturePosition(5f));
    }

    public Vector3 CalcFuturePosition(float futureTime)
    {
        return transform.position + (physicsObject.Direction * futureTime);
    }

    public Vector3 Wander(float futureTime, float circleRadius)
    {
        Vector3 futurePosition = CalcFuturePosition(futureTime);

        float randAngle = Random.Range(0f, Mathf.PI * 2f);

        Vector3 wanderPoint = futurePosition;

        wanderPoint.x += Mathf.Cos(randAngle) * circleRadius;
        wanderPoint.y += Mathf.Sin(randAngle) * circleRadius;
        


        return Seek(wanderPoint);
    }
}
