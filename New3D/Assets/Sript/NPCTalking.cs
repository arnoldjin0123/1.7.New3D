using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalking : MonoBehaviour
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
    [Header("TalkingSpeed")]
    public float TalkingSpeed;
    private string NPCTalkingWord;
    [Header("No Misstion Daiolouge"),TextArea(0,5)]
    public string NormalDaiolouge;
    //NPC正在說話Bool，快轉Bool，段落int
    private bool PlayerImTalkingArea = false;
    private bool NPCIsTalking = false;
    private bool DaioLouge1Talked = false;
    private bool Skip = false;
    private int paragraph = 0;

    private void Start()
    {
        NPCName.text = ThisNPCName;
    }
    private void Update()
    {
        Daiolouge.text = NPCTalkingWord;
        RightClickToSkipWord();
        SwitchToNextParagraph();
        NPCStartTalking();
        if (Input.GetKeyDown(KeyCode.Mouse1) && NPCIsTalking == false && Skip == false)
        {
            switch (paragraph) 
            {
                case 2:
                    StartCoroutine(NPCTalkingDaiolouge2());
                    break;
                case 3:
                    StartCoroutine(NPCTalkingDaiolouge3());
                    break;
                case 4:
                    ClosePanel();
                    break;
            }
            if (paragraph > 4)
            {
                if (PlayGameData.NowMIS_NUM != 3)
                {
                    if (paragraph % 2 == 1)
                    {
                        StartCoroutine(NPCNormalTalking());
                    }
                    else if (paragraph % 2 == 0)
                    {
                        MissionPanel.SetActive(true);
                        TalkingPanel.SetActive(false);
                    }
                }
                else if (PlayGameData.NowMIS_NUM == 3)
                {

                }
                
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerImTalkingArea = true;
            NPCANI.SetBool("Talking", true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerImTalkingArea = false;
            TalkingPanel.SetActive(false);
            NPCANI.SetBool("Talking", false);
            NPCIsTalking = false;
            StopAllCoroutines();
        }
    }
    private void RightClickToSkipWord()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && NPCIsTalking == true)
        {
            Skip = true;
        }
    }
    private void SwitchToNextParagraph()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && NPCIsTalking == false && PlayerImTalkingArea == true)
        {
            paragraph++;
        }
    }
    private void OpenPanel()
    {
        if (paragraph%2==1)
        {
            TalkingPanel.SetActive(true);
            MissionPanel.SetActive(false);
        }
    }
    private void ClosePanel()
    {
        if (paragraph <=4 )
        {
            NPCTalkingWord = "";
            NPCANI.SetBool("Talking", false);
            MissionPanel.SetActive(true);
            TalkingPanel.SetActive(false);
        }
    }
    private void NPCStartTalking()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && paragraph == 1 && DaioLouge1Talked ==false)
        {
            DaioLouge1Talked = true;
            GameObject.Find("PlayGameData").GetComponent<PlayGameData>().MISTalkToNPC_FIN();
            MissionPanel.SetActive(false);
            TalkingPanel.SetActive(true);
            StartCoroutine(NPCTalkingDaiolouge1());
            Debug.Log("Start Daiolouge");
        }
    }
    private IEnumerator NPCTalkingDaiolouge1()
    {
        NPCTalkingWord = "";
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
                GameObject.Find("PlayGameData").GetComponent<PlayGameData>().MISKiilMonster_Take();
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        NPCIsTalking = false;
        Skip = false;
        GameObject.Find("PlayGameData").GetComponent<PlayGameData>().MISKiilMonster_Take();
    }
    private IEnumerator NPCNormalTalking()
    {
        OpenPanel();
        NPCTalkingWord = "";
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
}
