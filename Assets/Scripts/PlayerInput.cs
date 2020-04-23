using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInput : MonoBehaviour
{//Get all user inputs
    private PlayerControls controls;
    public Vector2 move;
    public Vector2 look;
    public bool isShooting;

    private void Awake()
    {
        controls = new PlayerControls();
    }
    private void Start()
    {

        if (GameManager.instance.controls == "gamepad")
        {
            controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
            controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
            controls.Gameplay.Look.canceled += ctx => look = Vector2.zero;
            controls.Gameplay.Shoot.performed += ctx => isShooting = ctx.ReadValueAsButton();
            controls.Gameplay.Shoot.canceled += ctx => isShooting = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.controls == "keyboard")
        {
            look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            isShooting = Input.GetButton("Fire1");
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

