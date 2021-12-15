using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;

    // Logic
    public float triggerLength = 3;
    public float chaseLength = 15;
    private bool chasing;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        playerTransform = Gamemanager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(1).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Is the player in range?
        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if(Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
            {
                chasing = true;
            }
            if (chasing)
            {
                Vector3 heading = (playerTransform.position - transform.position) * Time.deltaTime;
                heading = new Vector3(heading.x, 0, heading.z);
                transform.forward = Vector3.Normalize(heading);
                UpdateMotor(heading);
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        

    }
    protected override void ReceiveDamage(Damage dmg)
    {
        base.ReceiveDamage(dmg);
        
        //implement animation
        //anim.SetTrigger("GotHit");
    }


    protected override void Death()
    {
        Destroy(gameObject);
        Gamemanager.instance.experience += xpValue;
        Gamemanager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
