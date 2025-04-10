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
    // Jumping
    public LayerMask Ground;
    public float raycastDistance = 0.6f; // Scale of character is 1 so from the middle to the bottom is 0.5, 0.6 will detect anything just below the character
    private bool isOnGround;
    public float jump = 100f;


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

        // Ground Check: https://www.youtube.com/watch?v=o8DDsFccxBE 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, Ground))
        {
            isOnGround = true;
        } else
        {
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse); // ForceMode.Impulse force is added instantly
        }
        movement = new Vector3(hAxis, 0, vAxis); // Creates a vector for 3d motion with the horizontal motion and vertical motion, the 0 means theres no jumping motion
        
    }

    void FixedUpdate() // Sets a force to a rigidbody element in each frame
    {
        move(movement);
        Debug.Log("Project Gravity: " + Physics.gravity);
    }

    void move(Vector3 direction)
    {
        rb.AddForce(direction * movementSpeed, ForceMode.VelocityChange); // Character movement with jump
    }
}
