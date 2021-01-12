using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCNewTalk : MonoBehaviour
{
    [Header("NPC")]
    public string ThisNPCName;
    public Animator NPCANI;

    [Header("Panel")]
    public GameObject TalkingPanel;
    public Text NPCName;
    public Text Daiolouge;

    public GameObject MissionPanel;

    [Header("MissionData")]
    public Misssion1 MissionData;
    [Header("MissionFinishData")]
    public Mission1Finish MissionFinishData;
    [Header("TalkingSpeed")]
    public float TalkingSpeed;
    private string NPCTalkingWord;
    [Header("No Misstion Daiolouge"), TextArea(0, 5)]
    public string NormalDaiolouge = "";

    private bool PlayerInTalkingArea = false;
    private bool NPCIsTalking = false;

    private bool Skip = false;
    private int normalParagraph = 0;
    private int paragraph = 0;
    private int FinishMISParagraph = 0;

    private float Timer_f = 0f;
    private bool Timer_On = false;

    private void Start()
    {
        NPCName.text = ThisNPCName;
    }
    private void Update()
    {
        Daiolouge.text = NPCTalkingWord;
        Timer();
        ParagraphPlus();
        ClickToSkip();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Player Enter");
            PlayerInTalkingArea = true;
            NPCANI.SetBool("Talking", true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Player Exit");
            PlayerInTalkingArea = false;
            NPCANI.SetBool("Talking", false);
            StopAllCoroutines();
            TalkingPanel.SetActive(false);
        }
    }

    private void ParagraphPlus()
    {
        if (PlayerInTalkingArea == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && NPCIsTalking == false && Skip == false)
            {
                Timer_On = true;
                if (PlayGameData.NowMIS_NUM == 1)
                {
                    paragraph++;
                    SwitchDaiolouge();
                }
                if (PlayGameData.NowMIS_NUM == 2)
                {
                    normalParagraph++;
                    SwitchDaiolouge();
                }
                if (PlayGameData.NowMIS_NUM == 3)
                {
                    FinishMISParagraph++;
                    SwitchDaiolouge();
                }
            }
        }
    }
    private void SwitchDaiolouge()
    {
        if (PlayGameData.NowMIS_NUM == 1)
        {
            switch (paragraph)
            {
                case 1:
                    StartCoroutine(NPCTalkingDaiolouge1());
                    break;
                case 2:
                    StartCoroutine(NPCTalkingDaiolouge2());
                    break;
                case 3:
                    StartCoroutine(NPCTalkingDaiolouge3());
                    break;
                case 4:
                    ClosePannel();
                    break;
            }
        }
        else if (PlayGameData.NowMIS_NUM == 2)
        {
            if (normalParagraph%2 == 1){StartCoroutine(NormalTalking());}
            else if (normalParagraph % 2 == 0){ ClosePannel(); }
        }
        else if (PlayGameData.NowMIS_NUM == 3)
        {
            switch (FinishMISParagraph)
            {
                case 1:
                    StartCoroutine (NPCFinishMISDaiolouge1());
                    break;
                case 2:
                    StartCoroutine(NPCFinishMISDaiolouge2());
                    break;
                case 3:
                    StartCoroutine(NPCFinishMISDaiolouge3());
                    break;
                case 4:
                    ClosePannel();
                    break;
            }
        }
    }
    private void Timer()
    {
        if (Timer_f<0.2f) { Timer_On = false; }
        if (Timer_On == true) {Timer_f += Time.deltaTime; }
    }
    private void ClickToSkip()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && NPCIsTalking == true && Skip == false 
            && Timer_On == false)
        {
                Skip = true;
        }
    }
    private void ClosePannel()
    {
            Debug.Log("ClosePannel");
            NPCTalkingWord = "";
            NPCANI.SetBool("Talking", false);
            MissionPanel.SetActive(true);
            TalkingPanel.SetActive(false);
        if (PlayGameData.NowMIS_NUM == 1)
        {
            GameObject.Find("PlayGameData").GetComponent<PlayGameData>().MISTalkToNPC_FIN();
        }
        if (PlayGameData.NowMIS_NUM == 2)
        { TalkingPanel.SetActive(false);}
        if (PlayGameData.NowMIS_NUM == 3)
        {
            GameObject.Find("PlayGameData").GetComponent<PlayGameData>().MISBackToNOC_FIN();
        }
    }

    private IEnumerator NormalTalking()
    {
        Debug.Log("Normal daiolouge");
        TalkingPanel.SetActive(true);
        MissionPanel.SetActive(false);
        NPCTalkingWord = "";
        Skip = false;
        for (int i = 0; i < NormalDaiolouge.Length; i++)
        {
            NPCIsTalking = true;
            NPCTalkingWord += NormalDaiolouge[i] + "";
            if (Skip == true)
            {
                NPCTalkingWord = NormalDaiolouge;
                Skip = false;
                NPCIsTalking = false;
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        NPCIsTalking = false;
        Skip = false;
    }

    private IEnumerator NPCTalkingDaiolouge1()
    {
        Debug.Log("Finish daiolouge1");
        TalkingPanel.SetActive(true);
        MissionPanel.SetActive(false);
        NPCTalkingWord = "";
        Skip = false;
        for (int i = 0; i < MissionData.Daiolouge1.Length; i++)
        {
            NPCIsTalking = true;
            NPCTalkingWord += MissionData.Daiolouge1[i] + "";
            if (Skip == true)
            {
                NPCTalkingWord = MissionData.Daiolouge1;
                Skip = false;
                NPCIsTalking = false;
                
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        NPCIsTalking = false;
        Skip = false;
    }
    private IEnumerator NPCTalkingDaiolouge2()
    {
        NPCTalkingWord = "";
        for (int i = 0; i < MissionData.Daiolouge2.Length; i++)
        {
            NPCIsTalking = true;
            NPCTalkingWord += MissionData.Daiolouge2[i] + "";
            if (Skip == true)
            {
                NPCTalkingWord = MissionData.Daiolouge2;
                Skip = false;
                NPCIsTalking = false;
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        NPCIsTalking = false;
        Skip = false;
    }
    private IEnumerator NPCTalkingDaiolouge3()
    {
        NPCTalkingWord = "";
        for (int i = 0; i < MissionData.Daiolouge3.Length; i++)
        {
            NPCIsTalking = true;
            NPCTalkingWord += MissionData.Daiolouge3[i] + "";
            if (Skip == true)
            {
                NPCTalkingWord = MissionData.Daiolouge3;
                Skip = false;
                NPCIsTalking = false;
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        NPCIsTalking = false;
        Skip = false;
    }

    private IEnumerator NPCFinishMISDaiolouge1()
    {
        TalkingPanel.SetActive(true);
        MissionPanel.SetActive(false);
        NPCTalkingWord = "";
        for (int i = 0; i < MissionFinishData.Daiolouge1.Length; i++)
        {
            Debug.Log("Finish mission daiolouge1");
            NPCIsTalking = true;
            NPCTalkingWord += MissionFinishData.Daiolouge1[i] + "";
            if (Skip == true)
            {
                NPCTalkingWord = MissionFinishData.Daiolouge1;
                Skip = false;
                NPCIsTalking = false;
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        NPCIsTalking = false;
        Skip = false;
    }
    private IEnumerator NPCFinishMISDaiolouge2()
    {
        Debug.Log("Finish mission daiolouge2");
        NPCTalkingWord = "";
        for (int i = 0; i < MissionFinishData.Daiolouge2.Length; i++)
        {
            NPCIsTalking = true;
            NPCTalkingWord += MissionFinishData.Daiolouge2[i] + "";
            if (Skip == true)
            {
                NPCTalkingWord = MissionFinishData.Daiolouge2;
                Skip = false;
                NPCIsTalking = false;
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        NPCIsTalking = false;
        Skip = false;
    }
    private IEnumerator NPCFinishMISDaiolouge3()
    {
        NPCTalkingWord = "";
        for (int i = 0; i < MissionFinishData.Daiolouge3.Length; i++)
        {
            Debug.Log("Finish mission daiolouge3");
            NPCIsTalking = true;
            NPCTalkingWord += MissionFinishData.Daiolouge3[i] + "";
            if (Skip == true)
            {
                NPCTalkingWord = MissionFinishData.Daiolouge3;
                NPCIsTalking = false;
                Skip = false;
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        NPCIsTalking = false;
        Skip = false;
    }
}
