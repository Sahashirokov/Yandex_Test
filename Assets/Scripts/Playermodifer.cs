using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermodifer : MonoBehaviour
{
    [SerializeField] int _widtch;
    [SerializeField] int _height;

    [SerializeField] Renderer _renderer;
    float _widtchMultiplayer = 0.0005f;
    float _heightMultiplaer = 0.01f;
    [SerializeField] Transform _topSpine;
    [SerializeField] Transform _BottomSpine;
    [SerializeField] Transform _collidertransform;


    [SerializeField] AudioSource _increaseSound;
    [SerializeField] GameObject _increaseObject;
    [SerializeField] AudioSource _blowSound;
    [SerializeField] GameObject _blowObject;
    //[SerializeField]  AudioSource _stopA;

    public void Start()
    {
        SetWidtch(Progress.Instance.PlayerInfo.Width);
        SetHeight(Progress.Instance.PlayerInfo.Height);

    }

    void Update()
    {
        float OffsetY = _height * _heightMultiplaer + 0.17f;
        _topSpine.position = _BottomSpine.position + new Vector3(0, OffsetY, 0);
        _collidertransform.localScale = new Vector3(1, 1 + _height * _heightMultiplaer, 1);
       /* if (Input.GetKeyDown(KeyCode.W))
        {
            AddWidtch(20);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            AddHeight(20);
        }
       if (_height < 0 || _widtch <0)
        {
            Die();
        }*/
    }
    public void AddWidtch(int value)
    {
       // _increaseObject.SetActive(true);
        //_blowObject.SetActive(true);
        _widtch += value ;
        UpdateWidtch();
        if(value > 0)
        {
            _increaseSound.Play();
        }
        else
        {
            _blowSound.Play();
        }
    }
    public void AddHeight(int value)
    {
        _height+= value;
        if (value > 0)
        {
            _increaseSound.Play();
        }
        else
        {
            _blowSound.Play();
        }
    }

    public void SetWidtch(int value)
    {
        _widtch = value;
        UpdateWidtch();
    }
    public void SetHeight(int value)
    {
        _height = value;

    }



    public void HitBarrier()
    {
        
        if(_height > 0)
        {
            _height -= 50;
        }else if (_widtch >0)
        {
            _widtch -= 50;
            UpdateWidtch();
        }
        else
        {
            Die();
        }
    }

    public void UpdateWidtch()
    {
        _renderer.material.SetFloat("_PushValue", _widtch * _widtchMultiplayer);

    }
    void Die()
    {
        _increaseObject.SetActive(false);
        _blowObject.SetActive(false);
        FindObjectOfType<FinishTrigger>().Brik();
        FindObjectOfType<PlayerBehaviaer>().SoundRun();
       // _stopA.Stop();
        FindObjectOfType<GameManager>().ShowFinishWindow();
        Destroy(gameObject);
    }

     public void Tgfinish()
    {
        Destroy(_increaseObject);
        Destroy(_blowObject);
    }
}
