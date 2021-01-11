using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGameData : MonoBehaviour
{
    //玩家資料
    static public bool playerIn = false;
    static public int PlayerHP = 100;
    static public int PlayerBreath = 100;
    //怪物資料
    static public int MonsterHP = 100;
    //UI資料
    private Text UIMISName;
    private Text UIMISDetal;
    private Text UIFinishWord;
    private GameObject FinishWordActive;
    //任務群組資訊
    private string MISName = " 目前沒有任何任務 ";
    private string MISDetal = " 想幹嘛就幹嘛~ ";
    private string FinishWord = " ";
    //記時器
    public float UIFinishWord_ContinueTime = 7f;
    private float Timer_f;
    private bool TimerOn = false;
    private void Awake()
    {
        UIMISName = GameObject.Find("MissionText").GetComponent<Text>();
        UIMISDetal = GameObject.Find("MissionDetal").GetComponent<Text>();
        UIFinishWord = GameObject.Find("FinishMissionText").GetComponent<Text>();
        FinishWordActive = GameObject.Find("FinishMissionText");
        FinishWordActive.SetActive(false);
    }
    private void Start()
    {
        MISTalkToNPC_Take();
    }
    private void Update()
    {
        UIMISName.text = MISName;
        UIMISDetal.text = MISDetal;
        UIFinishWord.text = FinishWord;
        Timer();
        FinishWordDisapear();
    }
    private void Timer()
    {
        if (TimerOn == true) {Timer_f += Time.deltaTime;}
    }
    private void FinishWordDissplay()
    {
        FinishWordActive.SetActive(true);
        TimerOn = true;
    }
    private void FinishWordDisapear()
    {
        if (Timer_f > UIFinishWord_ContinueTime)
        {
            FinishWordActive.SetActive(false);
            TimerOn = false;
            Timer_f = 0;
        }
    }
    private void ClearMIS()
    {
        MISName = ("目前沒有任何任務");
        MISDetal = ("想幹嘛就幹嘛~");
    }
    public void MISTalkToNPC_Take()
    {
        MISName = ("這裡是誰，我是哪裡?");
        MISDetal = ("尋找綠衣村名並和他對話");
        Debug.Log("You have take the NPCtalk mission");
    }
    public void MISTalkToNPC_FIN()
    {
        FinishWord = ("完成與村民的對話");
        Debug.Log("You have finish the NPCtalk missioin");
        FinishWordDissplay();
        ClearMIS();
    }
    public void MISKiilMonster_Take()
    {
        MISName = ("討伐從天而降的獸人");
        MISDetal = ("跟著路牌尋找獸人並擊敗他");
        Debug.Log("You have take the KillMoster mission");
    }
    public void MISKillMonster_FIN()
    {
        FinishWord = ("完成獸人討伐");
        Debug.Log("You have finish the KillMoster missioin");
        FinishWordDissplay();
        ClearMIS();
    }
    public void MISBackToNPC_Take()
    {
        MISName = ("回報任務");
        MISDetal = ("會去綠衣村民那裡回報任務");
        Debug.Log("You have take the BackToNPC mission");
    }
    public void MISBackToNOC_FIN()
    {
        FinishWord = ("你將回到你應待的世界");
        FinishWordDissplay();
        ClearMIS();
        Debug.Log("You have finish the BackToNPC missioin");
    }
}
