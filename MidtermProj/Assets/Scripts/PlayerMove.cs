using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;
    public GameHandler gameHandlerObj;
    public List<CrateBehavior> cratesInRange;
    public float lowestDist = -1f;

    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        if(cratesInRange.Count == 0)
        {
            lowestDist = -1f;
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Crate")
        {
            cratesInRange.Add(collision.gameObject.GetComponent<CrateBehavior>());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Crate")
        {
            cratesInRange.Remove(collision.gameObject.GetComponent<CrateBehavior>());
        }
    }
}
