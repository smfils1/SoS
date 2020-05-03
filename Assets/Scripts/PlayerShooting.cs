using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput playerInput;
    public Transform vision;
    public float fireRate = 15f;
    private float nextTimeToFire;
    // Start is called before the first frame update
    void Start()
    {
    //Initialize fields
            playerInput = GetComponent<PlayerInput>();

    }

    private void ShootingTarget()
    {
        if (playerInput.isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            RaycastHit target;
            if (Physics.Raycast(vision.position, vision.forward, out target, Mathf.Infinity))
            {
                GameObject item = target.collider.gameObject;
                
                if (item.tag == "Enemy") {
                    IKillable enemy = item.GetComponent<IKillable>();
                    enemy.decreaseHealth(10);

                }
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {
        ShootingTarget();
    }
}
