using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D MyRB;
    public bool isWalking;
    public float walkTime;
    public float WaitTime;
    private float Walkcounter;
    private float waitcounter;
    private int walkdirection;

    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody2D>();

        waitcounter = WaitTime;
        Walkcounter = walkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            Walkcounter -= Time.deltaTime;
            
            switch (walkdirection)
            {
                case 0:
                    MyRB.velocity = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    MyRB.velocity = new Vector2(moveSpeed, moveSpeed);
                    break;
                case 2:
                    MyRB.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 3:
                    MyRB.velocity = new Vector2(moveSpeed, - moveSpeed);
                    break;
                case 4:
                    MyRB.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 5:
                    MyRB.velocity = new Vector2(-moveSpeed, -moveSpeed);
                    break;
                case 6:
                    MyRB.velocity = new Vector2(-moveSpeed, 0);
                    break;
                case 7:
                    MyRB.velocity = new Vector2(-moveSpeed, moveSpeed);
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


}
