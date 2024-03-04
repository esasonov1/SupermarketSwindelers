using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSummary : MonoBehaviour
{
    public Text scoreObj;

    public GameObject gameOverCanvas;

    public ListHandler listObj;

    public ListHandler winloseObj;


    // Start is called before the first frame update

    public void EndGame()
    {
        gameOverCanvas.SetActive(true);

        if (GameObject.FindWithTag("Score") != null)
        {
            scoreObj = GameObject.FindWithTag("Score").GetComponent<Text>();
        }


        if (GameObject.FindWithTag("GameHandler") != null)
        {
            listObj = GameObject.FindWithTag("GameHandler").GetComponent<ListHandler>();
        }

        double price = 10 * listObj.ordered.Count;
        double tip = 0.2 * price;

        double stolen = 10 * listObj.orderedErrors.Count;
        double gain1 = (40 - price) + tip + stolen;
        double gain2 = (40 - price) + stolen;

        if (listObj.ordered.Count == 4)
        {
            Debug.Log("you won!");
            scoreObj.text =
                "You Won!"
                + "Total Budget: 40 \n"
                + "Items bought: -" + price + "\n"
                + "Tip: +" + tip + "\n"
                + "Items stolen: +" + stolen + "\n"
                + "Net Gain: " + gain1;
        }
        else
        {
            Debug.Log("you lost...");
            Debug.Log(stolen);
            scoreObj.text =
                "You Lost! Failed to complete order :( \n"
                + "Total Budget: 40" + "\n"
                + "Items bought: -" + price + "\n"
                + "Items stolen: +" + stolen + "\n"
                + "Net Gain: " + gain2;
        }

    }

}
