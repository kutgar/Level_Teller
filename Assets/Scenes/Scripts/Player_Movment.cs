using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    public float speed=3;  
    private Rigidbody2D rb2d;
    private Vector2 movment;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movment = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        moveCharecter(movment);
    }
    void moveCharecter(Vector2 direction)
    {
        //rb2d.AddForce(direction * speed);
        rb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
