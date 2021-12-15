using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    public Transform lookAt;
    public float boundX = 0.05f;
    public float boundY = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        float deltaZ = lookAt.position.z - transform.position.z;
        if (deltaZ > boundY || deltaZ < -boundY)
        {
            if (transform.position.z < lookAt.position.z)
            {
                delta.z = deltaZ - boundY;
            }
            else
            {
                delta.z = deltaZ + boundY;
            }
        }


        transform.position += new Vector3(delta.x, 0, deltaZ);
        //transform.position = lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
