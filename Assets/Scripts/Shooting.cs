
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float shootCD;
    bool shootOnCD;
    public GameObject playerCamera;
    public GameObject projectile;
    enum Weapons { Rifle, Shotgun, Pistol};
    Weapons equipped;

    void Start()
    {
        shootCD = 0f;
        equipped = Weapons.Rifle;
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetButton("Fire1") && !shootOnCD) // Had problems creating the shooting using raycast so using projectiles instead
        {
            switch(equipped)
            {

            }

            
            shootOnCD = true;
            StartCoroutine(ShootCooldown());
        }

        if(Input.GetButtonDown("Weapon1"))
        {

        }

        if (Input.GetButtonDown("Weapon2"))
        {

        }

        if (Input.GetButtonDown("Weapon3"))
        {

        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        shootOnCD = false;
    }


}
