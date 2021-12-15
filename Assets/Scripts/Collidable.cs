using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    protected new Collider collider;

    protected virtual void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    protected virtual void Update()
    {

    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger detected: " + other.name + " !!!");
    }

}
