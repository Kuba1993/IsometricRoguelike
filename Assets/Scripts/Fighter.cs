
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    //Push
    protected Vector3 pushDirection;

    //receive damage and die function
    protected virtual void ReceiveDamage(Damage dmg)
    {
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            pushDirection = new Vector3(pushDirection.x, 0, pushDirection.z);

            Gamemanager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if(hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
        }
    }

    protected virtual void Death()
    {

    }

}
