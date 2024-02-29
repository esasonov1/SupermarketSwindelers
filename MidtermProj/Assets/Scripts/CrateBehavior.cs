using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehavior : MonoBehaviour
{
    public GameObject grocerySprite;
    public ListHandler listHandler;
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
            listHandler = GameObject.FindWithTag("GameHandler").GetComponent<ListHandler>();
        }
        if (GameObject.FindWithTag("Player") != null){
            player = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        }
    }

    void collectItem(bool theft)
    {
        interactable = false;
        grocerySprite.SetActive(false);
        emptySprite.SetActive(true);
        fullSprite.SetActive(false);
        full = false;
        listHandler.AddItem(theft, groceryName);
    }

    void Update()
    {
        if(full)
        {
            if (distanceFromPlayer != player.lowestDist || !interactable)
            {
                isClosest = false;
                grocerySprite.SetActive(false);
            }
            if (interactable)
            {
                distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
                if (player.lowestDist == -1f || distanceFromPlayer < player.lowestDist || isClosest)
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
        
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactable = true;
        }
    }
 
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactable = false;
        }
    }
}
