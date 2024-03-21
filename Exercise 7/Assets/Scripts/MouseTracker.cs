using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTracker : MonoBehaviour
{
    [SerializeField] PhysicsObject physicsObject;

    [SerializeField] Vector3 mousePosition;

    Vector3 mouseForce = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        mousePosition = (Vector3)Mouse.current.position.ReadValue();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseForce = mousePosition - transform.position;


        physicsObject.ApplyForce(mouseForce);
    }
}
