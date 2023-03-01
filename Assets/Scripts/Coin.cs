using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float _rotatespeed;
    [SerializeField] GameObject _effectprefab;
   
   
    private CoinManager _manager;
    void Update()
    {
        transform.Rotate(0, _rotatespeed * Time.deltaTime, 0);
       
    }
    private void  OnTriggerEnter(Collider other)
    {
      FindObjectOfType<PlayerBehaviaer>().Dcoin();  
      FindObjectOfType<CoinManager>().AddOne();
       // _manager.AddOne();
       
        Destroy(gameObject);
        Instantiate(_effectprefab, transform.position, transform.rotation);
         

    }

   
}
