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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && currCrate != null) {
            Debug.Log("E pressed, collecting crate item");

            currCrate.CollectItem(false);
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            string droppedItem = gameHandlerObj.DropLastItem();

            if(droppedItem != null) {
                Debug.Log("D pressed, dropping: " + droppedItem);
            }
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
