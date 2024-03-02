using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSummary : MonoBehaviour
{
    public Text scoreObj;

    public ListHandler listObj;

    public ListHandler winloseObj;


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

        double price = 10 * listObj.cart.Count;
        double tip = 0.2 * price;

        double stolen = 10 * listObj.pockets.Count;
        double gain1 = (40 - price) + tip + stolen;
        double gain2 = (40 - price) + stolen;

        if (listObj.cart.Count == 4)
        {
            scoreObj.text =
                "You Won!"
                + "Total Budget: 40"
                + "Items bought: -" + price
                + "Tip: +" + tip
                + "Items stolen: +" + stolen
                + "Net Gain: " + gain1;
        }
        else
        {
            scoreObj.text =
                "You Lost! Failed to complete order :("
                + "Total Budget: 40"
                + "Items bought: -" + price
                + "Items stolen: +" + stolen
                + "Net Gain: " + gain2;
        }

    }

}
