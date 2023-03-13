using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSelection : MonoBehaviour
{
    private int index;
    public int optionAmount;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        select();
    }

    public void select()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) index--;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) index++;
        if (index < 0) index = optionAmount;
        if (index > optionAmount) index = 0;

        for (int i=0; i<optionAmount+1; i++)
        {
            if (i == index) transform.GetChild(i).GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f);
            else transform.GetChild(i).GetComponent<Image>().color = new Color(1,1,1);
        }
        
    }
}
