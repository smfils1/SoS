using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    private PlayerInput playerInput;
    public float mouseSensitivity = 100f;
    private CharacterController controller;
    public float speed = 10f;

    private void Awake()
    {
        //Initialize fields
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
    }

    private void Move()
    {//
        Vector3 moveDirectionX = transform.right * playerInput.moveX;
        Vector3 moveDirectionZ = transform.forward * playerInput.moveZ;
        Vector3 moveDirection = moveDirectionX + moveDirectionZ;
        controller.SimpleMove(moveDirection * speed);

    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
