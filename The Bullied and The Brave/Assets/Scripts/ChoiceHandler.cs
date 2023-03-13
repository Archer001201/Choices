using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceHandler : MonoBehaviour
{
    public string[] choices;
    [SerializeField] private GameObject choiceUI;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openChoiceUI()
    {
        if (!choiceUI.activeSelf)
        {
            choiceUI.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                choiceUI.transform.GetChild(i).gameObject.SetActive(false);
            }

            for (int i = 0; i < choices.Length; i++)
            {
                choiceUI.transform.GetChild(i).gameObject.SetActive(true);
                choiceUI.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = choices[i];
            }

            choiceUI.GetComponent<ChoiceSelection>().optionAmount = choices.Length - 1;
        }
        
    }
}
