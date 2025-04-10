using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Rotation frozen on all axis in inspector of rigidbody element to prevent character from falling over

    // Variables
    public float movementSpeed = 10f;
    public Rigidbody rb; // For physics interactions
    public Vector3 movement;
    // User Inputs
    public float hAxis;
    public float vAxis;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Gets the rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxis("Horizontal"); // Stores A/D input
        vAxis = Input.GetAxis("Vertical"); // Stores W/S input

        movement = new Vector3(hAxis, 0, vAxis); // Creates a vector for 3d motion with the horizontal motion and vertical motion, the 0 means theres no jumping motion
    }

    void FixedUpdate() // Sets a force to a rigidbody element in each frame
    {
        move(movement);
    }

    void move(Vector3 direction)
    {
        rb.velocity = direction * movementSpeed; // Sets the velocity (speed and direction) of a rigidbody element
    }
}
