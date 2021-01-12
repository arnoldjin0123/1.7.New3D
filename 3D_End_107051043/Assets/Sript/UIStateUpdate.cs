using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStateUpdate : MonoBehaviour
{
    private GameObject GameOverPannel;
    private Slider PlayerHPSlider;
    private Slider PlayerBRSlider;
    private float DeadTime_f = 0;
    private bool DeadTimer_On = false;

    private void Awake()
    {
        PlayerHPSlider = GameObject.Find("HPBar").GetComponent<Slider>();
        PlayerBRSlider = GameObject.Find("BreathBar").GetComponent<Slider>();
        GameOverPannel = GameObject.Find("GameOverPanel");
    }
    private void Start()
    {
        GameOverPannel.SetActive(false);
    }
    private void Update()
    {
        PlayerHPSlider.value = PlayGameData.PlayerHP;
        PlayerBRSlider.value = PlayGameData.PlayerBreath;
        DeadTimer();
        if (PlayGameData.PlayerHP <= 0) 
        { 
            DeadTimer_On = true;
            if (DeadTime_f > 6f){ GameOverPannel.SetActive(true); }
        }
    }
    private void DeadTimer() { if (DeadTimer_On == true) { DeadTime_f += Time.deltaTime; } }
    public void BackToTitle(){ SceneManager.LoadScene("Title");  }
    public void ExitGame() { Application.Quit(); }
    public void ResetGame(){ SceneManager.LoadScene("BaseLevel"); }
}
