using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Mover
{
    private Vector3 heading;
    //player moveDirection 
    Vector3 forward, right;
    

    protected override void Start()
    {
        //base.Start();

        //movement
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
       heading = CalculateMove();
       if ((Input.GetAxis("HorizontalKey") != 0 || Input.GetAxis("VerticalKey") != 0) )
           transform.forward = Vector3.Normalize(heading);

       UpdateMotor(heading);

    }

    private Vector3 CalculateMove()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = rightMovement + upMovement;

        return heading;
    }

}
