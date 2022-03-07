using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;
    public Vector3 move;

    public InputManager inputManager;

    public float runModifier = 4.0f;
    public float walkModifier= 2.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        move.x = inputManager.movementAxis.x;
        move.z = inputManager.movementAxis.y;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
