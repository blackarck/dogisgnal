using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


    public float moveSpeed;
    private Rigidbody2D rb2d;
    bool flagMComplete = true,upallow=true,downallow=true;
    public int minpos, maxpos;
    public Animator anim;
    public GameObject gameCanvas;
    public float playerskip;
    Vector3 screenPos;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerskip = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOn)
        {
            if (Input.GetKey("up") && flagMComplete && upallow)
            {
                moveup();
            }
            else if (Input.GetKey("down") && flagMComplete && downallow)
            {
                movedown();
            }
            if (Input.GetKeyUp("up") || Input.GetKeyUp("down"))
            {
                flagMComplete = true;
            }   

        }
    }//end of update

    private void moveup()
    {
        transform.position = new Vector2(transform.position.x , transform.position.y + 0.8f);
        flagMComplete = false;
        downallow = true;
        checkMove();

    }
    private void movedown()
    {
        transform.position = new Vector2(transform.position.x , transform.position.y - 0.8f);
        flagMComplete = false;
        upallow = true;
        checkMove();
    }

    private void checkMove()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y > maxpos  )
        {
            upallow = false;

        }
        if (  screenPos.y < minpos)
        {
            downallow = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (GameManager.instance.gameOn)
        {
            //Debug.Log("Checking colission ");
            if (col.gameObject.tag == "ground" || col.gameObject.tag == "enemy") // GameObject is a type, gameObject is the property
            {
                 
               // xplodManager.Instance.Explosion("xplod", transform.position);
                GameManager.instance.gameOn = false;
                GameManager.instance.Shake(0.1f, 0.1f);
              //  anim.Play("newPlayerCrash");
             //   AudioManager.instance.Stop("maintrack");

             //   AudioManager.instance.Play("xplosion");
              //  Invoke("showGO", 1);
            }
        }
    }//end of oncollision

    public void showGO()
    {
        mainPnl mainpnl = gameCanvas.GetComponent<mainPnl>();
        GameManager.instance.gameOn = false;
        mainpnl.showGameOver();
    }

}//end of class
