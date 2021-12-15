using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage
    public int damage = 1;
    public float pushForce = 5;
    public float attackSpeed = 0.5f;
    public float attackRange = 1;
    private float lastTimeHit;

    //References
    private Animator anim;
    private Transform playerTransform;

    protected override void Start()
    {
        base.Start();
        collider = GetComponent<BoxCollider>();
        playerTransform = Gamemanager.instance.player.transform;
        anim = GetComponentInParent<Animator>();
    }
    protected override void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.parent.position) < attackRange)
        {
            collider.enabled = true;
            anim.SetTrigger("Attack");
        }

        //check if attacking and set collider invis
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            collider.enabled = false;
            Debug.Log("weaponIdle!");
        }
    }

    protected void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player" && coll.name == "Player" && Time.time - lastTimeHit > attackSpeed)
        {
            lastTimeHit = Time.time;

           //new damage object to best send to the player
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }

    }

}
