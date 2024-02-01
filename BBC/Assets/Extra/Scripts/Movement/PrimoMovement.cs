using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private PlayerInputs playerInputs;
    Vector2 playerInputWalk;
    bool playerInputJump;

    private void Start()
    {
        playerInputs = new PlayerInputs();
        controller = gameObject.AddComponent<CharacterController>();
        playerInputs.Primo.Walk.performed += Walk;
        //playerInputs.Primo.Jump.performed += Jump;
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }

    private void Walk(InputAction.CallbackContext context)
    {
        playerInputWalk = context.ReadValue<Vector2>();
    }

    private bool Jump(InputAction.CallbackContext context)
    {
        playerInputJump = context.ReadValue<bool>();
        return playerInputJump;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(playerInputWalk.x, 0, playerInputWalk.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (playerInputJump && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}