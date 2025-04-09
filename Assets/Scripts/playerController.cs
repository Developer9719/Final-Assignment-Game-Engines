using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float runSpeed = 1.5f;

    public bool isCharacterRunning = false;
    public bool isOnGround = true;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        movePlayer(h);
        playerJump();
    }

    void movePlayer(float hSpeed)
    {

    }

    void playerJump()
    {

    }
}
