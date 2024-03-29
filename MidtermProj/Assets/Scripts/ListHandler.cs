using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ListHandler : MonoBehaviour
{
    public ScoreSummary scoreSummary;

    public BarHandler barHandlerObj;
    public GameHandler staticHandlerObj;

    public List<string> cart = new List<string>();
    public List<string> pockets = new List<string>();
    public List<string> order = new List<string>();
    public List<string> ordered = new List<string>();
    public List<string> stolen = new List<string>();
    public List<string> orderedErrors = new List<string>();

    public Text orderText;

    public int groceryCost;

    public float totalTime;

    public void Start()
    {
        if (GameObject.FindWithTag("StaticHandler") != null)
        {
            staticHandlerObj = GameObject.FindWithTag("StaticHandler").GetComponent<GameHandler>();
        }
        if (GameObject.FindWithTag("Bar") != null)
        {
            barHandlerObj = GameObject.FindWithTag("Bar").GetComponent<BarHandler>();
        }
        switch(staticHandlerObj.levelNum)
        {
            case 1:
                order.Add("tomato");
                order.Add("egg");
                order.Add("milk");
                order.Add("egg");
                break;
            default:
                Debug.Log("Unimplemented Level Number.");
                break;
        }
    }

    public void Update()
    {
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0f;
        }
        barHandlerObj.values[2] = totalTime * 2f;
        string listText = "<b>Grocery List: </b>";
        for (int i = 0; i < order.Count; i++)
        {
            listText += "\n - ";
            listText += order[i];
        }
        for (int i = 0; i < ordered.Count; i++)
        {
            listText += ("<color=grey>\n - " + ordered[i] + "</color>");
        }        
        for (int i = 0; i < stolen.Count; i++)
        {
            listText += ("<color= #8F7D99FF>\n - " + stolen[i] + "</color>");
        }
        for (int i = 0; i < orderedErrors.Count; i++)
        {
            listText += ("<color=#DD5555FF>\n - " + orderedErrors[i] + "</color>");
        }
        orderText.text = listText;
    }

    public void AddItem(bool theft, string name)
    {
        if (theft)
        {
            pockets.Add(name);
            if (order.Contains(name))
            {
                order.Remove(name);
                stolen.Add(name);
            }
            else
            {
                barHandlerObj.values[3] += groceryCost;
            }
        }
        else
        {
            cart.Add(name);
            barHandlerObj.values[0] -= groceryCost;
            barHandlerObj.values[1] += groceryCost;
            if (order.Contains(name))
            {
                order.Remove(name);
                ordered.Add(name);
            }
            else
            {
                orderedErrors.Add(name);
            }
        }
    }

    public void CalcScore()
    {
        if(order.Count == 0)
        {
            staticHandlerObj.scores[0] = (float)System.Math.Round(barHandlerObj.values[0],2);
        }
        else
        {
            staticHandlerObj.scores[0] = 0.00f;
        }
        staticHandlerObj.scores[1] = (float)System.Math.Round(barHandlerObj.values[1],2);
        staticHandlerObj.scores[2] = (float)System.Math.Round(barHandlerObj.values[2],2);
        staticHandlerObj.scores[3] = (float)System.Math.Round(barHandlerObj.values[3],2);
    }

    public void ReturnStolenItems()
    {
        barHandlerObj.values[3] = 0f;
        for(int i = 0; i < stolen.Count; i++)
        {
            order.Add(stolen[i]);
        }
        stolen.Clear();
        pockets.Clear();
    }
}