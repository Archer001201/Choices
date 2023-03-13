using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Choices.Dialogue;

public class P1_Controller : MonoBehaviourPun
{
    public float speed;
    public int brave;

    private Rigidbody2D rb;
    private float inputX, inputY;
    private Vector2 movementInput;

    private Animator anim;
    private GameObject dialogguePanel;
    //private GameObject choiceUI;
    GameObject eventObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dialogguePanel = GameObject.Find("Dialouge Canvas").transform.GetChild(0).gameObject;
        //choiceUI = GameObject.Find("Dialouge Canvas").transform.GetChild(1).gameObject;
        eventObject = null;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        if (!dialogguePanel.activeSelf) PlayerInput();

        if (eventObject != null && eventObject.CompareTag("Event") && eventObject.GetComponent<P1_DialogueController>().canTalk
            && Input.GetKeyDown(KeyCode.Space) && !eventObject.GetComponent<P1_DialogueController>().isTalking)
        {
            StartCoroutine(eventObject.GetComponent<P1_DialogueController>().DialogueRoutine());
        }

        switchAnim();
    }

    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0 && inputY != 0)
        {
            inputX *= 0.6f;
            inputY *= 0.6f;
        }
        movementInput = new Vector2(inputX, inputY);
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.deltaTime);
    }

    private void switchAnim()
    {
        if (inputX != 0 || inputY != 0)
        {
            anim.SetBool("Move", true);
        }
        else anim.SetBool("Move", false);

        if (inputX > 0)
        {
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
        }
        else if (inputX < 0)
        {
            anim.SetBool("Right", false);
            anim.SetBool("Left", true);
        }
        else
        {
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }

        if (inputY > 0)
        {
            anim.SetBool("Down", false);
            anim.SetBool("Up", true);
        }
        else if (inputY < 0)
        {
            anim.SetBool("Down", true);
            anim.SetBool("Up", false);
        }
        else
        {
            anim.SetBool("Down", false);
            anim.SetBool("Up", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        eventObject = collision.gameObject;

        if (collision.gameObject.CompareTag("Event"))
        {
            //collision.GetComponent<P1_DialogueController>().enabled = true;
            if (collision.GetComponent<P1_DialogueController>().dialogueList.Count != 0)
                collision.GetComponent<P1_DialogueController>().canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        eventObject = null;

        if (collision.gameObject.CompareTag("Event"))
        {
            collision.GetComponent<P1_DialogueController>().canTalk = false;
            collision.transform.GetChild(0).gameObject.SetActive(false);
            //collision.GetComponent<P1_DialogueController>().enabled = false;
        }
    }
}
