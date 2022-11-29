using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviaer : MonoBehaviour
{
    [SerializeField] PlayerMove _PlayerMove;
    [SerializeField] PreFinishBeheviour _preFinishBeheviour;
    [SerializeField] Animator _animator;
    [SerializeField] AudioSource _stopSound;
    [SerializeField] AudioSource _FinishSound;
    [SerializeField] AudioSource _BackSound;
    void Start()
    {
        _PlayerMove.enabled = false;
        _preFinishBeheviour.enabled = false;
    }
   public void Play()
    {
        _PlayerMove.enabled = true;
    }
    public void StartPreFinishTrigger()
    {
        _PlayerMove.enabled = false;
        _preFinishBeheviour.enabled = true;
    }
    public void StartFinishBeheviour()
    {
        _preFinishBeheviour.enabled = false;
        _animator.SetTrigger("Dance");
        _stopSound.Stop();
        _FinishSound.Play();
    }

    bool isPaused = false;

    void OnGUI()
    {
        if (isPaused)
        {
            _BackSound.Stop();
        }
        
        

            if (isPaused)
            {
                _BackSound.Play();
            }
            
        
    }

    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
