using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;

    public ListHandler listHandler;
    public GameHandler gameHandlerObj;
    private bool playerInSight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            // listHandler = GameObject.GetComponent<ListHandler>();

        }
        changeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        movePatron();
        if (Input.GetKeyDown(KeyCode.Q) && playerInSight)
        {
            listHandler.ReturnStolenItems();
        }
    }

    void movePatron()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void changeDirection(){
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Invoke("changeDirection", Random.Range(2, 5)); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSight = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSight = false;
        }
    }
}
