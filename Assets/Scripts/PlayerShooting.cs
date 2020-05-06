using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform vision;
    public float fireRate = 15f;
    public AudioClip gunShootingClip;
    public float gunRecoil;

    private PlayerInput playerInput;
    private float nextTimeToFire;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize fields
        playerInput = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();
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
                    enemy.decreaseHealth(10 * ((GameManager.instance.level / 10) + 1));
                }
            }

            audioSource.clip = gunShootingClip;
            audioSource.Play();
            GetComponent<PlayerVision>().RotateRecoil(gunRecoil);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShootingTarget();
    }
}
