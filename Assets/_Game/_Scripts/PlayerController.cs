using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Changeable from inspector
    [SerializeField] float movementSpeed = 1f;

    // Storing components into cache for ease

    Rigidbody2D rb;
    Vector2 movementDirection;

    // variables that can accessed from any methoud in this class
    float inputHorizontal;
    float inputVertical;
    bool facingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
    }

    private void Movement()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(inputHorizontal, inputVertical);
    }
    private void FixedUpdate()
    {
        //physics stuff should be in fixedupdate
        //This code is adding velocity to movement
        rb.velocity = movementDirection * movementSpeed;
    }
    private void Rotate()
    {
        /*This code is flipping our character
         check in inspector and you can do it for up and down too
         but it wont look good 
        */
        if (!facingRight && inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            facingRight = true;
        }
        if (facingRight && inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            facingRight = false;
        }
    }


}
