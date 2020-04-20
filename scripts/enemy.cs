using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 1;
    bool shouldwalk = false;
    GameObject flyspot1obj, flyspot2obj,newenem;
    public GameObject enemyball;
    // Start is called before the first frame update
    void Start()
    {
        flyspot1obj= GameObject.Find("flyspot1");
        flyspot2obj = GameObject.Find("flyspot2"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldwalk)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
       
    }

    public void walkme()
    {
       // Debug.Log("Wakling the enemy");
        shouldwalk = true;
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (GameManager.instance.gameOn)
        {
            
            if (col.gameObject.CompareTag("flyspot"))  
            {
               // Debug.Log("Checking colission " + col.gameObject.name);
                //make flyspot1 inactive
                //activate flyspot2 if its inactive
                if (col.gameObject.name.Equals( "flyspot1"))
                {
                   
                    col.gameObject.SetActive(false);
                    
                    if (flyspot2obj)
                    {
                       // Debug.Log("Coming here 1");
                        flyspot2obj.SetActive(true);
                    }
                }

                if (col.gameObject.name.Equals("flyspot2"))
                {
                    col.gameObject.SetActive(false);
                    
                    if (flyspot1obj)
                    {
                       // Debug.Log("Coming here 2");
                        flyspot1obj.SetActive(true);
                    }
                }
                //spaw new enemy fly sprite
                newenem = Instantiate(enemyball, transform.position, Quaternion.identity);
                // Destroy this object
                Destroy(gameObject);
                

               // GameManager.instance.Shake(0.1f, 0.1f);
               
                 

               // AudioManager.instance.Play("xplosion");
                
            }
        }
    }//end of oncollision
}
