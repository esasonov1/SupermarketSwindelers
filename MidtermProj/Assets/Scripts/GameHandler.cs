using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public List<string> cart = new List<string>();
    public List<string> pockets = new List<string>();
    public List<string> order = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddItem(bool theft, string name)
    {
        if(theft)
        {
            pockets.Add(name);
        }
        else
        {
            cart.Add(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
