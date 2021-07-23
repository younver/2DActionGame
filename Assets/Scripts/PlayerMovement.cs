using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Input handling
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        //Speed multiplier
        moveAmount = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        //Moving the rigidbody
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
}

