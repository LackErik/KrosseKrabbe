using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSimple : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 10f;
    float xAchse = 0f;
    float zAchse = 0f;
    float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHight = 0.5f;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        xAchse = Input.GetAxis("Horizontal");
        zAchse = Input.GetAxis("Vertical");
        Vector3 move = transform.right * xAchse + transform.forward * zAchse;
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * (-2) * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        cc.Move(move * Time.deltaTime * speed);
        cc.Move(velocity * Time.deltaTime);

    
    }
}
