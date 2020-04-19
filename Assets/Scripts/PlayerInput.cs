using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{//Get all user inputs
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    public float moveX { get; private set; }
    public float moveZ { get; private set; }



    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }
}

