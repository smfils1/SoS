using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput playerInput;
    public Transform vision;

    // Start is called before the first frame update
    void Start()
    {
    //Initialize fields
            playerInput = GetComponent<PlayerInput>();

    }

    private void CheckShootingTarget()
    {Debug.Log(playerInput.isShooting);
        if (playerInput.isShooting)
        {
            
            RaycastHit target;
            
            if (Physics.Raycast(vision.position, vision.forward, out target, Mathf.Infinity))
            {
                IKillable enemy = target.collider.GetComponent<IKillable>();
                if (enemy != null) enemy.decreaseHealth(10);
            }
        }
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckShootingTarget();
    }
}
