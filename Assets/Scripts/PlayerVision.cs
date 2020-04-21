using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerVision : MonoBehaviour
{

    private PlayerInput playerInput;
    public Transform vision;
    public float mouseSensitivity = 100f;
    private CharacterController controller;
    public Transform body;
    public float speed = 10f;
    private float rotateX = 0f;
    private float visionLimit = 70f;

    private void Awake()
    {
        //Initialize fields
        playerInput = GetComponent<PlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Rotate()
    {//
        RotateX();
        RotateY();
     /*float mouseX = playerInput.mouseX * mouseSensitivity * Time.deltaTime;
             float mouseY = playerInput.mouseY * mouseSensitivity * Time.deltaTime;

             rotateX -= mouseY;
             rotateX = Mathf.Clamp(rotateX, -70f, 70f);
             transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
             body.Rotate(Vector3.up * mouseX);
        float lookX = playerInput.mouseX * mouseSensitivity * Time.deltaTime;
        Quaternion angle = Quaternion.AngleAxis(lookX, Vector3.up);
        Quaternion rotation = transform.localRotation * angle;
        transform.localRotation = rotation;*/
       
    }

    private void RotateY()
    {
        float lookY = playerInput.look.y * mouseSensitivity * Time.deltaTime;
        Quaternion visionCenter = vision.localRotation;
        Quaternion angle = Quaternion.AngleAxis(lookY, -Vector3.right);
        Quaternion rotation = visionCenter * angle;
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
