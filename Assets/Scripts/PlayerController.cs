using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("General")]
    public float gravityScale = -20f;
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    [Header("Camera")]
    public float rotationSensibility = 30f;
    [Header("Jump")]
    public float jumpHeight = 1.9f;
    [Header("References")]
    public Transform objectToRotate; // El objeto que quieres rotar

    private float cameraVerticalAngle;
    private Vector3 moveInput = Vector3.zero;
    private Vector3 rotationInput = Vector3.zero;
    private CharacterController characterController;
    private Vector2 move;
    private Vector2 look;
    private bool isSprinting;
    private bool isJumping;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Look();
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        isJumping = context.ReadValueAsButton();
    }

    private void Move()
    {
        if (characterController.isGrounded)
        {
            moveInput = new Vector3(move.x, 0, move.y);
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);

            if (isSprinting)
            {
                moveInput = transform.TransformDirection(moveInput) * runSpeed;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            }

            if (isJumping)
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            }
        }

        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }

    private void Look()
    {
        rotationInput = new Vector3(-look.y, look.x, 0) * rotationSensibility * Time.deltaTime;
        cameraVerticalAngle += rotationInput.x;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -90f, 90f);

        objectToRotate.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
        transform.Rotate(Vector3.up * rotationInput.y);
    }
}
