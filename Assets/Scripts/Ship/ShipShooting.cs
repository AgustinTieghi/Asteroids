using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private float timer;
    private float initialTimer;
    private bool isButtonPressed;
    private void Start()
    {
        initialTimer = timer;       
    }

    private void Update()
    {
        if (ShipController.instance.shoot)
        {

            if (!isButtonPressed)
            {             
                Shoot(); 
                timer = initialTimer; 
                isButtonPressed = true;  
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {               
                Shoot();  
                timer = initialTimer;  
            }
        }
        else
        {
            isButtonPressed = false;  
        }
    }

    void Shoot()
    {
        this.GetComponent<AudioSource>().Play();
        GameObject spawnedAmmo = Instantiate(ammo, this.transform.position, Quaternion.identity);
        spawnedAmmo.GetComponent<AmmoScript>().direction = this.transform.up;
    }
}
