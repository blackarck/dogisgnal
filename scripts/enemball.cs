using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemball : MonoBehaviour
{
    // Start is called before the first frame update

    public float minspeed, maxspeed, speed;
    public int toppos;
    bool reachtop = false;
    Vector3 screenPos;
    GameObject bone1, bone2, bone3,player;
    public GameObject gameCanvas;
    void Start()
    {
      bone1= GameObject.Find("bone1");
      bone2 = GameObject.Find("bone2");
      bone3 = GameObject.Find("bone3");
      player= GameObject.Find("player");
        speed = Random.Range(minspeed, maxspeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.difficulty == 1)
        {
            speed= Random.Range(1.5f, 2f);
        }
        if (!reachtop) { 
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y < toppos )
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        else
        {
            reachtop = true;
            checkLost();
        }
        }

    }

    void checkLost()
    {
        
        if (GameManager.instance.life > 1)
        {
            GameManager.instance.life -= 1;
            //play lost sound
            if (GameManager.instance.life == 2)
            {
                bone3.SetActive(false);
            }
            if (GameManager.instance.life == 1)
            {
                bone2.SetActive(false);
            }
           

        }
        else
        {
             //remove last left bone
                bone1.SetActive(false);

            //play game over sound
            //show game over panel
            showGO();
            Destroy(gameObject);
        }

    }

    public void showGO()
    {
        player play = player.GetComponent<player>();
        play.showGO();
        
    }
}
