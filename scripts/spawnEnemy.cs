using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    GameObject newenemy;
    public float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        if (GameManager.instance.gameOn)
        {

            if (timeBtwSpawn <= 0)
            {
                newenemy = Instantiate(enemy,  transform.position , Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawn;

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
