using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float speed;

    private Vector2 moveVector;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get raw input for movement
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Multiply normalized(sqrt(2x)||x) input by speed
        moveVector = moveInput.normalized * speed;

        // Run-Idle animation transition
        animator.SetBool("isRunning", 
            moveInput == Vector2.zero ? false : true);
    }

    private void FixedUpdate()
    {
        // Move the rigidbody
        rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime);
    }
}

