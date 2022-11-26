using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D MyRB;
    public bool isWalking;
    private float walkTime;
    private float WaitTime;
    private float Walkcounter;
    private float waitcounter;
    private int walkdirection;
    bool NPCcollision;
    public Collider2D Walkzone;
    private Vector2 MinWalk, Maxwalk; 

    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody2D>();

        waitcounter = WaitTime;
        Walkcounter = walkTime;

        ChooseDirection();
        MinWalk = Walkzone.bounds.min;
        Maxwalk = Walkzone.bounds.max;
    }

    // Update is called once per frame
    void Update()

    {
        moveSpeed = Random.Range(0, 3);
        walkTime = Random.Range(0, 5);
        WaitTime = Random.Range(0, 5);
        if (isWalking)
        {
            Walkcounter -= Time.deltaTime;
            
            switch (walkdirection)
            {
                case 0:
                    MyRB.velocity = new Vector2(0, moveSpeed);
                    if (transform.position.y > Maxwalk.y)
                    {
                        isWalking = false;
                        waitcounter = WaitTime;
                    }
                    break;
                case 1:
                    MyRB.velocity = new Vector2(moveSpeed, moveSpeed);
                    if (transform.position.y > Maxwalk.y || transform.position.y > Maxwalk.x)
                    {
                        isWalking = false;
                        waitcounter = WaitTime;
                    }
                    break;
                    
                case 2:
                    MyRB.velocity = new Vector2(moveSpeed, 0);
                    if (transform.position.y > Maxwalk.x)
                    {
                        isWalking = false;
                        waitcounter = WaitTime;
                    }
                    break;
                case 3:
                    MyRB.velocity = new Vector2(moveSpeed, - moveSpeed);
                    if (transform.position.y > Maxwalk.x || transform.position.y < Maxwalk.y)
                    {
                        isWalking = false;
                        waitcounter = WaitTime;
                    }
                    break;
                case 4:
                    MyRB.velocity = new Vector2(0, -moveSpeed);
                    if (transform.position.y < Maxwalk.y)
                    {
                        isWalking = false;
                        waitcounter = WaitTime;
                    }
                    break;
                case 5:
                    MyRB.velocity = new Vector2(-moveSpeed, -moveSpeed);
                    if (transform.position.y < Maxwalk.x || transform.position.y < Maxwalk.y)
                    {
                        isWalking = false;
                        waitcounter = WaitTime;
                    }
                    break;
                case 6:
                    MyRB.velocity = new Vector2(-moveSpeed, 0);
                    if (transform.position.y < Maxwalk.x )
                    {
                        isWalking = false;
                        waitcounter = WaitTime;
                    }
                    break;
                case 7:
                    MyRB.velocity = new Vector2(-moveSpeed, moveSpeed);
                    if (transform.position.y < Maxwalk.x || transform.position.y > Maxwalk.y)
                    {
                        isWalking = false;
                        waitcounter = WaitTime;
                    }
                    break;

            }
            if (Walkcounter < 0)
            {
                isWalking = false;
                waitcounter = WaitTime;
            }

        }
        else
        {
            waitcounter -= Time.deltaTime;

            MyRB.velocity = new Vector2(0, 0);

            if(waitcounter < 0)
            {
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection()
    {
        walkdirection = Random.Range(0, 8);
        isWalking = true;
        Walkcounter = walkTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "NPC")
        {
          
            NPCcollision= true; //we only move if !collidedWithPlayer
            isWalking = false;
            MyRB.velocity = new Vector2(0, 0);//stop moving
                                              //turn NPC into "wall"

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "NPC")
        {
            NPCcollision = false; //we only move if !collidedWithPlayer
            isWalking = true; //stop moving
            MyRB.velocity = new Vector2(0, 0);

        }
    }
}
