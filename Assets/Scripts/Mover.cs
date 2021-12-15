using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{

    protected Animator anim;

    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    public float movementSpeed = 1.00f;

    //movedirection from 1-8 clockwise starting right is 0 if nothing changed
    private int moveDirection;

    //references
    private SpriteRenderer spriteRenderer;


    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public int getMoveDirection()
    {
        return moveDirection;
    }

    protected virtual void UpdateMotor(Vector3 input)
    {

        // reduce pushForce every frame, based off recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);
        

        //reset moveDelta
        moveDelta = new Vector3(input.x* movementSpeed , input.y , input.z* movementSpeed) ;

        //add intrinsic movement
        transform.position += moveDelta;

        //add extrinsic movement
        transform.position += pushDirection;

        anim = GetComponent<Animator>();
        //set walk annimation
        if (input.x != 0 || input.z != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //transform.Translate(new Vector3(pushDirection.x , 0, pushDirection.z));
    }

    public void PortMover(Vector3 input)
    {
        transform.position = input;
    }


}
