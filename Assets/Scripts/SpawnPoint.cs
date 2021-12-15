using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        Gamemanager.instance.portPlayer(this.transform.position);
    }
}
