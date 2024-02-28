using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehavior : MonoBehaviour
{
    public GameObject grocerySprite;
    public GameHandler gameHandlerObj;
    public PlayerMove player;
    public GameObject emptySprite;
    public GameObject fullSprite;
    public string groceryName;
    public float distanceFromPlayer;
    public bool isClosest;
    public bool interactable;
    public bool full;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
        if (GameObject.FindWithTag("Player") != null){
            player = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        }
    }

    void collectItem(bool theft)
    {
        grocerySprite.SetActive(false);
        emptySprite.SetActive(true);
        fullSprite.SetActive(false);
        full = false;
        gameHandlerObj.AddItem(theft, groceryName);
    }

    // Update is called once per frame
    void Update()
    {
        if(full)
        {
            if (distanceFromPlayer != player.lowestDist)
            {
                isClosest = false;
                grocerySprite.SetActive(false);
            }
            if (interactable)
            {
                distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
                if (player.lowestDist == -1f || distanceFromPlayer <= player.lowestDist || isClosest)
                {
                    player.lowestDist = distanceFromPlayer;
                    isClosest = true;
                    grocerySprite.SetActive(true);
                }
            }
            if (isClosest)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    collectItem(false);
                }
                else if(Input.GetKeyDown(KeyCode.Q))
                {
                    collectItem(true);
                }
            }
        }
    }
        
    void OnTriggerEnter2D(Collider2D other) //This checks if the player collides with this interactable's collider
    {
        if (other.tag == "Player")
        {
            interactable = true;
        }
    }
 
    void OnTriggerExit2D(Collider2D other) //This checks if the player leaves the collider of the interactable.
    {
        if (other.tag == "Player")
        {
            interactable = false;
        }
    }
}
