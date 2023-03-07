using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * 挂载到事件物体上的脚本
 * 设置事件的对话详情（角色头像，名字，对话内容）
 * 事件必须要有碰撞盒
 */
namespace Choices.Dialogue
{
    //[RequireComponent(typeof(NPCMovement))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class DialogueController : MonoBehaviour
    {
        //private NPCMovement npc => GetComponent<NPCMovement>();
        public UnityEvent OnFinishEvent;
        public List<DialoguePiece> dialogueList = new List<DialoguePiece>();

        private Stack<DialoguePiece> dailogueStack;

        private bool canTalk;
        private bool isTalking;
        private GameObject uiSign;
        private void Awake()
        {
            uiSign = transform.GetChild(0).gameObject;
            FillDialogueStack();
        }

        private void Update()
        {
            uiSign.SetActive(canTalk);

            if (canTalk & Input.GetKeyDown(KeyCode.Space) && !isTalking)
            {
                StartCoroutine(DialogueRoutine());
            }
        }

        /// <summary>
        /// 构建对话堆栈
        /// </summary>
        private void FillDialogueStack()
        {
            dailogueStack = new Stack<DialoguePiece>();
            for (int i = dialogueList.Count - 1; i > -1; i--)
            {
                dialogueList[i].isDone = false;
                dailogueStack.Push(dialogueList[i]);
            }
        }

        private IEnumerator DialogueRoutine()
        {
            isTalking = true;
            if (dailogueStack.TryPop(out DialoguePiece result))
            {
                //传到UI显示对话
                EventHandler.CallShowDialogueEvent(result);
                
                yield return new WaitUntil(() => result.isDone);
                isTalking = false;
            }
            else
            {
                EventHandler.CallShowDialogueEvent(null);
                FillDialogueStack();
                isTalking = false;

                OnFinishEvent?.Invoke();
            }
        }

        public void SetCanTalk(bool result)
        {
            canTalk = result;
        }
    }
}

