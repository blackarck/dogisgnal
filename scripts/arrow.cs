using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    public float speed;
    public float lifetime;
    public GameObject gameCanvas;
    public float distance;
    public LayerMask whatissolid;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyArrow", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(transform.right * speed * Time.deltaTime);
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distance, whatissolid);
        if (hitinfo.collider != null) {
            //Debug.Log("collider" + hitinfo.collider.tag);
            if (hitinfo.collider.CompareTag("enemy"))
            {
                DestroyArrow();
                DestroyEnemy(hitinfo);
                AudioManager.instance.Play("ballplop");
                
                GameManager.instance.Shake(0.1f, 0.1f);
                GameManager.instance.score += 1;
                xplodManager.Instance.Explosion("enemy", transform.position);
                //envoke particle effect
            }
        }
    }


   
    void DestroyEnemy(RaycastHit2D hitenem)
    {
        Destroy(hitenem.collider.gameObject);
    }

   void DestroyArrow()
    {
        Destroy(gameObject);
    }

    public void showGO()
    {
        mainPnl mainpnl = gameCanvas.GetComponent<mainPnl>();
        //mainpnl.showGameOver();
    }
}
