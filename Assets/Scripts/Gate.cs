using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] int _value;


    [SerializeField] DeformationType _deformationType;
    [SerializeField] GateAppearaence _gateAppearaence;
    // Start is called before the first frame update
    private void OnValidate()
    {
        _gateAppearaence.UpdateVisual(_deformationType, _value);

    }
    private void OnTriggerEnter(Collider other)
 
    {

        Playermodifer playermodifer = other.attachedRigidbody.GetComponent<Playermodifer>();
        if (playermodifer != null)
        {
            if (_deformationType == DeformationType.Width)
            {
                playermodifer.AddWidtch(_value);
            }
            else if (_deformationType == DeformationType.Height)
            {
                playermodifer.AddHeight(_value);
            }
            Destroy(gameObject);
        }
    }
}
