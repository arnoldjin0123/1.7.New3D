using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHurt : MonoBehaviour
{
    static public bool GetHurt = false;
    private Animator MonsterANI;

    private Slider MonsterHPSL;
    private GameObject MonsterTopUI;

    private void Awake()
    {
        MonsterTopUI = GameObject.Find("MonsterImage");
        MonsterHPSL = GameObject.Find("MonsterHPSlider").GetComponent<Slider>();
        MonsterANI = GetComponent<Animator>();
    }
    private void Update()
    {
        MonsterHPSL.value = PlayGameData.MonsterHP;
        MonsterGetHurt();
        MonsterDie();
    }
    private void MonsterGetHurt()
    {
        if (GetHurt == true && PlayGameData.MonsterHP > 0)
        {
            MonsterANI.SetTrigger("Hurt");
            PlayGameData.MonsterHP -= 30;
            GetHurt = false;
            Debug.Log("Monster's HP have: " + PlayGameData.MonsterHP);
        }
    }
    private void MonsterDie()
    {
        if (PlayGameData.MonsterHP <= 0) { MonsterANI.SetTrigger("Die"); }
        if (PlayGameData.MonsterHP <= 0 && PlayGameData.playerIn == true)
        {
            Debug.Log("Monster Die");
            GameObject.Find("Alert").GetComponent<AlertTouchEvent>().enabled = false;
            PlayGameData.playerIn = false;
            MonsterTopUI.SetActive(false);
            GameObject.Find("PlayGameData").GetComponent<PlayGameData>().MISKillMonster_FIN();
        }
    }
}
