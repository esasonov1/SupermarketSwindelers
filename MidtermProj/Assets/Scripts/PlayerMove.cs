using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;
    public GameHandler gameHandlerObj;
    private CrateBehavior currCrate;
    // Start is called before the first frame update
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
        if(Input.GetKeyDown(KeyCode.E) && currCrate != null) {
            Debug.Log("E pressed, adding crate item to cart");
            currCrate.CollectItem(false);
        }
        if(Input.GetKeyDown(KeyCode.T) && currCrate != null) {
            Debug.Log("T pressed, theft, puting crate item in pocket");
            currCrate.CollectItem(true);
        }
        
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Crate")
        {
            currCrate = collision.gameObject.GetComponent<CrateBehavior>();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Crate" && currCrate == collision.gameObject.GetComponent<CrateBehavior>())
        {
            currCrate = null;
        }
    }

}
