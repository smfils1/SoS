using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerVision : MonoBehaviour
{

    private PlayerInput playerInput;
    public Transform vision;
    public Quaternion visionCenter;
    public float mouseSensitivity = 100f;
    private CharacterController controller;
    public float speed = 10f;
    private float visionLimit = 70f;

    private void Awake()
    {
        //Initialize fields
        playerInput = GetComponent<PlayerInput>();
        visionCenter = transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Rotate()
    {//
        RotateX();
        RotateY();     
    }

    private void RotateY()
    {
        float lookY = playerInput.look.y * mouseSensitivity * Time.deltaTime;
        Quaternion angle = Quaternion.AngleAxis(lookY, -Vector3.right);
        Quaternion rotation = vision.localRotation * angle;
        if (Quaternion.Angle(visionCenter, rotation) < visionLimit)
        {
            vision.localRotation = rotation;
        }
    }

    private void RotateX()
    {
        float lookX = playerInput.look.x * mouseSensitivity * Time.deltaTime;
        Quaternion angle = Quaternion.AngleAxis(lookX, Vector3.up);
        Quaternion rotation = transform.localRotation * angle;
        transform.localRotation = rotation;
    }


    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
}
