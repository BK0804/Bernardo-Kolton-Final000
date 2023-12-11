using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    public float VelocidadRotacion = 200.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.8f;
    // Update is called once per frame
    private Animator anim;
    public float horizontal, vertical;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move;
       
        move = transform.forward * vertical + transform.right * horizontal;
        controller.Move(move * Time.deltaTime * playerSpeed);
        Vector3 finalSpeed = move * playerSpeed;

       

        if (Input.GetButtonDown("Jump") && groundedPlayer)

        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        anim.SetFloat("SpeedX", horizontal);
        anim.SetFloat("SpeedZ",vertical);
        anim.SetFloat("SpeedMag", finalSpeed.magnitude);
    }

}
