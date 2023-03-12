using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
    public string[] choices;
    [SerializeField] private GameObject choiceUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openChoiceUI()
    {
        //if (!choiceUI.activeSelf)
        //{
            choiceUI.SetActive(true);
        //}
    }
}
