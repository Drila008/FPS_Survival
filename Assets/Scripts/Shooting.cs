
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("Jee");
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 100, Color.red, 5f);
        }
    }
}
