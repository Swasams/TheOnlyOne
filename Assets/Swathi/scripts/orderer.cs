using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderer : MonoBehaviour
{
    private SpriteRenderer rendy;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        rendy = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("PlayerSprite");
        rendy.sortingOrder = (int)(-this.transform.position.y * 100);
    }
       /* if (Player.transform.position.y <= this.transform.position.y)
        {
            {
               // Debug.Log("back");
               
            }
            
        }
        if (Player.transform.position.y > this.transform.position.y)
        {
            //Debug.Log("front");
            rendy.sortingOrder = (int)(100);
        }
    }*/
}
