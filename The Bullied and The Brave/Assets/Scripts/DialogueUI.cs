using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Choices.Dialogue;
using DG.Tweening;

/*
 * 此脚本挂载在Dialogue Canvas上以获取对话详情以及更新对话UI
 */
public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueBox;

    public Text dialogueText;

    public Image characterFace;

    public TextMeshProUGUI characterName;

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += OnShowDailogueEvent;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= OnShowDailogueEvent;
    }

    private void OnShowDailogueEvent(DialoguePiece piece)
    {
        StartCoroutine(ShowDialogue(piece));
    }

    private IEnumerator ShowDialogue(DialoguePiece piece)
    {
        if (piece != null)
        {
            piece.isDone = false;

            dialogueBox.SetActive(true);
            //continueBox.SetActive(false);

            dialogueText.text = string.Empty;

            if (piece.name != string.Empty)
            {
                //faceLeft.gameObject.SetActive(true);
                //faceRight.gameObject.SetActive(true);
                //characterFace.gameObject.SetActive(true);
                characterFace.sprite = piece.faceImage;
                characterName.text = piece.name;  
            }
            else
            {
                characterFace.gameObject.SetActive(false);
                characterName.gameObject.SetActive(false);
            }
            yield return dialogueText.DOText(piece.dialogueText, 1f).WaitForCompletion();

            piece.isDone = true;

            //if (piece.hasToPause && piece.isDone)
                //continueBox.SetActive(true);
        }
        else
        {
            dialogueBox.SetActive(false);
            yield break;
        }
    }
}
