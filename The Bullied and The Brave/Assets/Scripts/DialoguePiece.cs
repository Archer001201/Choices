using UnityEngine;
using UnityEngine.Events;

namespace Choices.Dialogue
{
    [System.Serializable]
    public class DialoguePiece
    {
        [Header("Dialogue Details")]
        public Sprite faceIamge;
        public bool onLeft;
        public string name;
        [TextArea]
        public string dialogueText;
        public bool hasToPause;
        [HideInInspector] public bool isDone;
        public UnityEvent afterTalkEvent;
    }
}

