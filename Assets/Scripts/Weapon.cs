using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{

    // Damage struct
    //TODO: implement with initial value and function
    public int damagePoint = 10;
    public float pushForce = 2.0f;
    

    //Swing
    public float attackSpeed = 1;
    private Animator anim;
    private float swingCooldown = 0.5f;
    private float lastSwing;
    private Vector3 initialPosition;
    private Quaternion initialRotation;


    protected override void Start()
    {
        collider = GetComponent<BoxCollider>();
        anim = GetComponentInParent<Animator>();
        initialPosition = this.transform.localPosition;
        initialRotation = this.transform.localRotation;

        anim.SetFloat("AttackSpeed", attackSpeed);
        swingCooldown /= attackSpeed;
    }

    protected override void Update()
    {
        base.Update();

       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > swingCooldown)
            {
                lastSwing = Time.time;
                collider.enabled = true;
                Swing();
            }

        }
        //check if attacking and set collider invis
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Combo0") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            collider.enabled = false;
            Debug.Log("weaponIdle!");
        }

    }


    protected void OnTriggerEnter(Collider coll)
    {
        Debug.Log("collision detected!!");
        if(coll.tag == "Enemy")
        {
            if (coll.name == "Player")
                return;
            
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
        };


            coll.SendMessage("ReceiveDamage", dmg);
            
            Debug.Log(coll.name);
        }

    }


    private void Swing()
    {
        anim.SetBool("isWalking", false);
        anim.SetTrigger("Swing");
    }
    
}
