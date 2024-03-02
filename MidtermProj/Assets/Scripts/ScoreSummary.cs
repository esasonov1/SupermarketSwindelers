using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSummary : MonoBehaviour
{
    public Text scoreObj;

    public ListHandler listObj;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Score") != null)
        {
            scoreObj = GameObject.FindWithTag("Score").GetComponent<Text>();
        }

        if (GameObject.FindWithTag("GameHandler") != null)
        {
            listObj = GameObject.FindWithTag("GameHandler").GetComponent<ListHandler>();
        }

        scoreObj.text = "Items in cart: " + listObj.cart.Count;

        int price = 5 * listObj.cart.Count;

    }

}
