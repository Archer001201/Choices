using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemaraController : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Transform>().position = new Vector3(
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x,
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.y,
            -10);
    }
}
