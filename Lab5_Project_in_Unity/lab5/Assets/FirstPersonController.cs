using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FirstPersonController : MonoBehaviour
{
	Animator anim;
    public CharacterController controller;
    public float Speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groungCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
    	anim = GetComponent<Animator> ();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groungCheck.position, groundDistance, groundMask);

        if ((Input.GetKeyUp (KeyCode.W)) || (Input.GetKeyUp (KeyCode.A)) || (Input.GetKeyUp (KeyCode.S)) || (Input.GetKeyUp (KeyCode.D)))
        {
        	anim.SetBool("walk", !anim.GetBool("walk"));	
        }
        if (Input.GetKeyUp (KeyCode.Space))
        {
        	anim.SetBool("jump", !anim.GetBool("jump"));
        }
        if (isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * Speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") &&  isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

       	velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}