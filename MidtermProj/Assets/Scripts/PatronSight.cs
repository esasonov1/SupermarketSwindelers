using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronSight : MonoBehaviour
{
    private bool playerInSight = false;
    // Start is called before the first frame update

    public ListHandler listHandler;
    public SpriteRenderer visionRenderer;
    public Color defaultColor;
    public Color inVisionColor;
    public Color spottedColor;

    void Start()
    {
        visionRenderer = GetComponent<SpriteRenderer>();
        if (GameObject.FindWithTag("GameHandler") != null){
            listHandler = GameObject.FindWithTag("GameHandler").GetComponent<ListHandler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerInSight)
        {
            listHandler.ReturnStolenItems();
            visionRenderer.color = spottedColor;
            StartCoroutine(DelayColorChange(0.3f));
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSight = true;
            visionRenderer.color = inVisionColor;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSight = false;
            visionRenderer.color = defaultColor;
        }
    }

    IEnumerator DelayColorChange(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(playerInSight)
        {
            visionRenderer.color = inVisionColor;
        }
        else
        {
            visionRenderer.color = defaultColor;
        }
    }
}
