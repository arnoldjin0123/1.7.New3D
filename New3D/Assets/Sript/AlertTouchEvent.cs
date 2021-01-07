using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTouchEvent : MonoBehaviour
{
    private Animator MonsterANI;
    private void Awake()
    {
        MonsterANI = GameObject.Find("Monster").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayGameData.playerIn = true;
            MonsterANI.SetBool("Walk", true);
            Debug.Log("Player in");
            Debug.Log("PlayerIn="+PlayGameData.playerIn);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayGameData.playerIn = false;
            MonsterANI.SetBool("Walk", false);
            Debug.Log("Player out");
            Debug.Log("PlayerIn=" + PlayGameData.playerIn);
        }
    }
}
