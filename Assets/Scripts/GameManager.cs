using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    [DllImport("__Internal")]

    public static extern void ShowAdv();




    [SerializeField] GameObject _startMenu;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] CoinManager _coinmanager;
    //[SerializeField] AudioSource _BackSound;
    
    //[SerializeField] GameObject _ObjectSound;
    //[SerializeField] AudioSource _FinishSound;
    //[SerializeField] GameObject _finishobj;
   
    private void Start()
    {
        ShowAdv();
        _levelText.text = SceneManager.GetActiveScene().name;
           
    }
    public void play()
    {
         
        //_BackSound.Play();
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviaer>().Play();
#if UNITY_WEBGL
         Progress.Instance.Save();
        
#endif
        
    }
    public void ShowFinishWindow()
    {
        //_FinishSound.Play();
        //_BackSound.Stop();
      //  _ObjectSound.SetActive(false);
        
        _finishWindow.SetActive(true);
        
        
       
        
    }
    public void NextLevel()
    {
        
        //SceneManager.LoadScene(Progress.Instance.PlayerInfo.Level+1);
       int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            _coinmanager.SaveToProgress();

            Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;

            Progress.Instance.Save();

            //StartCoroutine(LoadYourAsyncScene());
           // int now = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.UnloadSceneAsync(sceneBuildIndex:now);
            SceneManager.LoadScene(next);
            
        }
        
    }
    /*IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(+1); // change "YourSceneName" with the scene you want to load

        // wait until the scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }*/
}
