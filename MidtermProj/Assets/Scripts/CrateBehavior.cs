using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehavior : MonoBehaviour
{
    public GameObject grocerySprite;
    public GameHandler gameHandlerObj;
    public string groceryName;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    public void CollectItem(bool theft)
    {
        grocerySprite.SetActive(false);
        gameHandlerObj.AddItem(theft, groceryName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
