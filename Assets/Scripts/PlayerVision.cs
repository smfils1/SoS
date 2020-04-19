using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerVision : MonoBehaviour
{

    private PlayerInput playerInput;
    public float mouseSensitivity = 100f;
    private CharacterController controller;
    public Transform body;
    public float speed = 10f;
    private float rotateX = 0f;

    private void Awake()
    {
        //Initialize fields
        playerInput = GetComponentInParent<PlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Rotate()
    {//
        float mouseX = playerInput.mouseX * mouseSensitivity * Time.deltaTime;
        float mouseY = playerInput.mouseY * mouseSensitivity * Time.deltaTime;

        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -70f, 70f);
        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
}
