using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    Camera cam;
    public bool gameOn = false;
    float shakeAmount = 0;
    public float DelayedTime = 2;
    public int score = 0;
    public int spawnControl = 0;
    public float speed, incrementSpeed, maxSpeed, origSpeed;
    public int switchCount;
    public int life = 3;
    public int difficulty = 0;  //0=easy 1=medium 2=godmode

    // Use this for initialization
    void Awake()
    {
        cam = Camera.main;
        origSpeed = speed;

        Application.targetFrameRate = 60;
        //Debug.Log("Starting game maanger");
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        StartCoroutine(WaitAndPrint(DelayedTime));
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (speed <= maxSpeed)
        {
            speed = speed + incrementSpeed;
        }

    }

    public void InitGame()
    {

        // Debug.Log("Game Init " + Time.time);
        gameOn = false;
        score = 0;
        speed = origSpeed;
        spawnControl = Random.Range(0, 2); //will give 0 or 1
        life = 3;                                   //spawnControl = 1;
                                           // Debug.Log("Spawn control is " + spawnControl);
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        // Debug.Log("starting co routine");
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        // gameStart = true;
        //Your Function You Want to Call
    }

    public void Shake(float amt, float length)
    {
        //to call Shake(0.1f, 0.1f);
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);

    }//end of shake

    public void DoShake()
    {
        if (shakeAmount > 0)
        {
            reInitCam();
            Vector3 camPos = cam.transform.position;
            float shakeAmtX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeAmtY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += shakeAmtX;
            camPos.y += shakeAmtY;
            cam.transform.position = camPos;
        }
    }

    public void StopShake()
    {
        CancelInvoke("DoShake");
        cam.transform.localPosition = Vector3.zero;

    }

    void reInitCam()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void GameOver()
    {
        enabled = false;
    }


}