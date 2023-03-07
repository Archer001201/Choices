using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Choices.Dialogue;

public class EventHandler
{
    public static event Action<DialoguePiece> ShowDialogueEvent;
    public static void CallShowDialogueEvent(DialoguePiece piece)
    {
        ShowDialogueEvent?.Invoke(piece);
    }
}
