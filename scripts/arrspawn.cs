using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrspawn : MonoBehaviour
{
    public GameObject arrow;
    public float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 1f;
    bool frsttimeonly = true;
    int spawnOn = 1;


    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.difficulty==2)
        {
            startTimeBtwSpawn = 0.7f;
        }

        if (GameManager.instance.spawnControl == 1 && frsttimeonly)
        {
            // Debug.Log("Disabling spawn block");
            spawnOn = 0;
            frsttimeonly = false;
        }

        if (GameManager.instance.gameOn)
        {
            if (timeBtwSpawn <= 0)
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // Debug.Log("spawn and fire weapon here");
                    AudioManager.instance.Play("shoot");
                    Instantiate(arrow, transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;
                }
               
                if (startTimeBtwSpawn > minTime)
                {
                    startTimeBtwSpawn -= decreaseTime;
                }
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }

        }
    }
}
