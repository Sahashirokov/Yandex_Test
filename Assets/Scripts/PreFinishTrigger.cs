using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviaer playerBehaviaer = other.attachedRigidbody.GetComponent<PlayerBehaviaer>();
        if (playerBehaviaer)
        {
            playerBehaviaer.StartPreFinishTrigger();
            
        }

    }
}
