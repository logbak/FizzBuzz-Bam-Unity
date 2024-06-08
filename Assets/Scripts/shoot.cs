using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Transform projectileSpawn;
    public GameObject projectile;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();        
    }

    public void Shoot()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            audioSource.Play();
        }
    }
}
