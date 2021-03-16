using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float gravity;

    Vector3 velocity;

    CharacterController playerController;

    public bool isGround;
    public bool isDead = false;


    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    public LayerMask deadMask;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isDead = Physics.CheckSphere(groundCheck.position, groundDistance, deadMask);

        Move();

        if (isDead)
        {
            resetPosition();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        playerController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -1 * gravity);
            isGround = false;
        }

        playerController.Move(velocity * Time.deltaTime);



    }

    void resetPosition()
    {
        transform.position = new Vector3(0, 30f, 0);
    }


}
