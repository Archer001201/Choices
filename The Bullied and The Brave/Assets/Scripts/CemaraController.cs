using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemaraController : MonoBehaviour
{
    int timer;

    private void Start()
    {
        timer = 90;
    }

    private void FixedUpdate()
    {
        if (timer > 0) timer--;
    }

    private void Update()
    {
        
        if (timer <= 0)
        {
            GetComponent<Transform>().position = new Vector3(
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x,
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.y,
            -10);
        }
        
    }
}
