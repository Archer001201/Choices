using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Choices.Dialogue;

public class P1_EventController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Event000")
        {
            collision.GetComponent<DialogueController>().setCanTalk(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Event000")
        {
            collision.GetComponent<DialogueController>().setCanTalk(false);
        }
    }
}