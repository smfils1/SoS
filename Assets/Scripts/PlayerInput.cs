using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInput : MonoBehaviour
{//Get all user inputs
    private PlayerControls controls;
    public Vector2 move;
    public Vector2 look;
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    public float moveX { get; private set; }
    public float moveZ { get; private set; }


    private void Awake()
    {
        if(GameManager.instance.controls == "gamepad")
        {
            controls = new PlayerControls();
            controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
            controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
            controls.Gameplay.Look.canceled += ctx => look = Vector2.zero;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.controls == "gamepad")
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }

    }

    void OnEnable()
    {
       controls.Gameplay.Enable();
    }

    void OnDisable()
    {
       controls.Gameplay.Disable();
    }
}

