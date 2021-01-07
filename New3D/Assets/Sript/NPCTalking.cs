using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalking : MonoBehaviour
{
    [Header("NPC")]
    public string ThisNPCName;
    public Text NPCName;
    public Animator NPCANI;

    [Header("Panel")]
    public GameObject TalkingPanel;

    private void Start()
    {
        NPCName.text=ThisNPCName ;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name=="Player")
        {
            TalkingPanel.SetActive(true);
            NPCANI.SetBool("Talking",true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            TalkingPanel.SetActive(false);
            NPCANI.SetBool("Talking", false);
        }
    }
}
