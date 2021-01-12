using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStateUpdate : MonoBehaviour
{
    private Slider PlayerHPSlider;
    private Slider PlayerBRSlider;

    private void Awake()
    {
        PlayerHPSlider = GameObject.Find("HPBar").GetComponent<Slider>();
        PlayerBRSlider = GameObject.Find("BreathBar").GetComponent<Slider>();
    }

    private void Update()
    {
        PlayerHPSlider.value = PlayGameData.PlayerHP;
        PlayerBRSlider.value = PlayGameData.PlayerBreath;
    }

    public void BackToTitle(){ SceneManager.LoadScene("Title");  }
    public void ExitGame() { Application.Quit(); }
}
