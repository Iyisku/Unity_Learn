using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Movement : MonoBehaviour
{
    //      **Public Variables**    
    public float MovementSpeed =5;     //Movement Speed of the Sprite Character
    public float MaxSpeed =8;          //Max Movement Speed of the Character
    public Rigidbody2D rb;             //Reference to the Rigidbody Component

    //      **Private Variables
    private Vector2 MoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();

        // ** Rotate Towards Movement Direction
        //
        if (rb.velocity.x!=0 || rb.velocity.y!=0)  // ** Prevents Rotation reset
        {
            transform.up = rb.velocity.normalized;
        }
    }

    //Get Movement Input from Keyboard
    private void OnMove(InputValue mval )
    {
        MoveDirection = mval.Get<Vector2>().normalized;
    }

    private void Move()
    {
        if (!rb.velocity.Equals(MaxSpeed))
        {
            /*
            //  Direct Movement (No Drag)
            //  
            rb.velocity = new Vector2(MoveDirection.x * MovementSpeed, MoveDirection.y * MovementSpeed);
            */



            //Movement with Drag
            //
            rb.AddForce(new Vector2(MoveDirection.x * MovementSpeed, MoveDirection.y * MovementSpeed));
        }
    }
}
