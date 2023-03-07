using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Choices.Dialogue;

/*
 * Player2的事件控制脚本
 * 当玩家触碰到事件的碰撞盒将会搜索事件名称，如果事件与该玩家相关就是触发聊天提示
 * 当玩家离开事件的碰撞盒，聊天提示关闭
 */
public class P2_EventController : MonoBehaviour
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

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
