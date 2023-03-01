using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    //[SerializeField] AudioSource _BackSoundStop;
    [SerializeField]  GameObject _brikobj;
    [SerializeField]  GameObject _CoinObj;
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviaer playerBehaviaer = other.attachedRigidbody.GetComponent<PlayerBehaviaer>();
        if (playerBehaviaer)
        {
            playerBehaviaer.StartFinishBeheviour();
            FindObjectOfType<GameManager>().ShowFinishWindow();
            FindObjectOfType<Playermodifer>().Tgfinish();
            FindObjectOfType<PlayerBehaviaer>().SoundRun();
            Brik();
            
        }
       // _BackSoundStop.Stop();
    }

    public void Brik()
    {
        
       Destroy(_brikobj);
    }

   
}
