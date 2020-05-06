using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerVision : MonoBehaviour
{

    private PlayerInput playerInput;
    public Transform vision;
    public Transform weapon;
    public Quaternion visionCenter;
    private CharacterController controller;
    public float speed = 10f;
    private float visionLimit = 25f;

    private void Awake()
    {
        //Initialize fields
        playerInput = GetComponent<PlayerInput>();
        visionCenter = transform.localRotation;
    }

    private void Start()
    {
        if (GameManager.instance.controls == "keyboard")
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Rotate()
    {//
        RotateX();
        RotateY();     
    }

    private void RotateY()
    {
        float lookY = playerInput.look.y * GameManager.instance.ySensitivity * Time.deltaTime * 100f;
        Quaternion angle = Quaternion.AngleAxis(lookY, -Vector3.right);
        Quaternion rotation = vision.localRotation * angle;
        if (Quaternion.Angle(visionCenter, rotation) < visionLimit)
        {
            vision.localRotation = rotation;
            weapon.localRotation = vision.localRotation;
        }

    }

    private void RotateX()
    {
        float lookX = playerInput.look.x * GameManager.instance.xSensitivity * Time.deltaTime * 100;
        Quaternion angle = Quaternion.AngleAxis(lookX, Vector3.up);
        Quaternion rotation = transform.localRotation * angle;
        transform.localRotation = rotation;
    }

    public void RotateRecoil(float gunRecoil)
    {
        Quaternion angle = Quaternion.AngleAxis(gunRecoil, -Vector3.right);
        Quaternion rotation = vision.localRotation * angle;
        if (Quaternion.Angle(visionCenter, rotation) < visionLimit)
        {
            vision.localRotation = rotation;
            weapon.localRotation = vision.localRotation;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
}
