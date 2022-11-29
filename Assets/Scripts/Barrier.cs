using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] GameObject _BriksEffectsPrefab;
    private void OnTriggerEnter(Collider other)
    {
        Playermodifer playermodifer = other.attachedRigidbody.GetComponent<Playermodifer>();
        if (playermodifer)
        {
            playermodifer.HitBarrier();
            Destroy(gameObject);
            Instantiate(_BriksEffectsPrefab, transform.position, transform.rotation);
        }
    }
}
