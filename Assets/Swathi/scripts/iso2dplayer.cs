using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iso2dplayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;
    public static iso2dplayer instance;
    public bool iswalking;
    

    void Start()
    {
       // this.transform.position = new Vector2(11, -16);
    }
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
           // this.transform.position = new Vector2(-43, -41);
        }
        else
        {
            Destroy(gameObject);
        }

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveH, moveV);//OPTIONAL rb.MovePosition();

        Vector2 direction = new Vector2(moveH, moveV);

        

        FindObjectOfType<isocharacterrenderer>().SetDirection(direction);
    }
   
}
