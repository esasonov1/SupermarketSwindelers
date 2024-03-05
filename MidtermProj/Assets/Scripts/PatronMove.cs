using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        changeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        movePatron();

    }

    void movePatron()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void changeDirection(){
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Invoke("changeDirection", Random.Range(2, 5)); 
    }


}
