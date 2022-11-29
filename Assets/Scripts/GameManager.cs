using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _startMenu;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] CoinManager _coinmanager;
   
    private void Start()
    {
        _levelText.text = SceneManager.GetActiveScene().name;
    }
    public void play()
    {
       
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviaer>().Play();
#if UNITY_WEBGL
         Progress.Instance.Save();
        
#endif

    }
    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }
    public void NextLevel()
    {

        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            _coinmanager.SaveToProgress();

            Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;
#if UNITY_WEBGL
            Progress.Instance.Save();

#endif

            SceneManager.LoadScene(next);
            
        }
        
    }
}
