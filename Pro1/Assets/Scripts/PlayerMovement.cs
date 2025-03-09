using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotationSpeed = 120f; // Speed for rotating using keys
    public float jumpPower = 7f;
    public float gravity = 10f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // Left/Right movement
        float moveZ = Input.GetAxis("Vertical");   // Forward/Backward movement

        float movementDirectionY = moveDirection.y;

        // 🔥 Fix: Inverted Forward Movement (moveZ is negated)
        moveDirection = (-transform.forward * moveZ + transform.right * moveX) * moveSpeed;

        // Jumping
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Apply movement
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotate using keyboard (A/D or Left/Right Arrows)
        float rotation = moveX * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
