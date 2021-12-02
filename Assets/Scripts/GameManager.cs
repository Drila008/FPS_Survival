using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] zombieSpawns;
    public GameObject[] ammoSpawns;
    public GameObject ammo;
    public GameObject zombie;

    public GameObject replayButton;
    public GameObject quitButton;

    

    public float zombieSpeed;
    public int zombieHealth;

    float difficultyTimer = 0f;
    float spawnTimer = 10f;
    float ammoTimer = 30f;

    float spawnDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        zombieSpeed = 1.3f;
        zombieHealth = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        difficultyTimer += Time.deltaTime;
        ammoTimer += Time.deltaTime;
        spawnTimer -= Time.deltaTime;

        if(difficultyTimer > 30)
        {
            zombieHealth++;
            zombieSpeed += 0.3f;

            spawnDelay--;
            difficultyTimer = 0f;
        }

        if (ammoTimer > 20)
        {
            Instantiate(ammo, ammoSpawns[Random.Range(0, ammoSpawns.Length)].transform.position, Quaternion.identity);
            ammoTimer = 0;
        }

        if(spawnTimer <= 0)
        {
            Instantiate(zombie, zombieSpawns[Random.Range(0, zombieSpawns.Length)].transform.position, Quaternion.identity);
            spawnTimer = spawnDelay;
        }

        

        
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
