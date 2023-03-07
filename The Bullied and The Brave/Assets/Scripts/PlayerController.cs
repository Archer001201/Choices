using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float speed;

    private Rigidbody2D rb;
    private float inputX, inputY;
    private Vector2 movementInput;

    private Animator anim;
    private GameObject dialogguePanel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dialogguePanel = GameObject.Find("Dialouge Canvas").transform.GetChild(0).gameObject;
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
}
