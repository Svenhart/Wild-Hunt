using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    private Patrol preyPatrol;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.GetComponent<Patrol>()!= null )
        {
            this.preyPatrol = other.GetComponent<Patrol>();
            this.preyPatrol.Respawn();
            this.preyPatrol = null;
        }
    }
}
