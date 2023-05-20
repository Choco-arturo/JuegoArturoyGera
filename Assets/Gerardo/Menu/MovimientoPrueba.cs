using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPrueba : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    private float directionX;
    private float directionY;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        //rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");


    }

    private void Move()
    {
        rb.velocity = new Vector2(directionX * speed, directionY * speed);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
