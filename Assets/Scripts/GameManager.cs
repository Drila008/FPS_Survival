using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float zombieSpeed;
    public int zombieHealth;
    // Start is called before the first frame update
    void Start()
    {
        zombieSpeed = 1.3f;
        zombieHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
