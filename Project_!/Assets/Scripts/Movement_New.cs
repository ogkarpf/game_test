using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_New : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    CharacterController characterController;
    public Camera cam;

    private bool isGrounded;

    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded)
        {
            isGrounded = true;
        }
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float vertical = Input.GetAxis("Vertical") * moveSpeed;
        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);

        if (isGrounded == true && Input.GetButton("Jump"))
            moveVector.y = jumpSpeed;
            moveVector.y -= gravity * Time.deltaTime;

            characterController.Move(moveVector * Time.deltaTime);
            isGrounded = false;
        
        if (isGrounded == true && Input.GetButton("Jump") && Input.GetButton("Horizontal"))
            moveVector.y = jumpSpeed * 2;
            moveVector.y -= gravity * Time.deltaTime;

            characterController.Move(moveVector * Time.deltaTime);
            isGrounded = false;
        
    }
}