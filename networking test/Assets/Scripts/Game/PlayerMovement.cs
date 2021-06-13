using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    Vector2 moveVelocity;

    PhotonView view;

    void Start()
    {
        view = this.GetComponent<PhotonView>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
        }
    }

    void FixedUpdate()
    {
        if(view.IsMine)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }
    }
}
