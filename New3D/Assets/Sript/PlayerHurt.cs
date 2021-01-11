using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class PlayerHurt : MonoBehaviour
{
    [Header("Dead Need Time"),Range(0,5)]
    public float deadTime = 2.5f;
    static public bool GetHurt = false;
    private Animator PlayerANI;
    //記時器
    private float Timer_f = 0f;
    private bool TimerOn = false;
    private void Awake()
    {
        PlayerANI = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerGetHurt();
        PlayerDie();
        Timer();
        PlayerCannotControl();
    }
    private void PlayerGetHurt()
    {
        if (GetHurt == true && PlayGameData.PlayerHP > 0)
        {
            PlayerANI.SetTrigger("Hurt");
            PlayGameData.PlayerHP -= 30;
            GetHurt = false;
            Debug.Log("Player's HP have: " + PlayGameData.PlayerHP);
        }
    }
    private void PlayerDie()
    {
        if (PlayGameData.PlayerHP <= 0)
        {
            PlayerANI.SetTrigger("Die");
            TimerOn = true;
            vThirdPersonController vt = GetComponent<vThirdPersonController>();
            vt.lockMovement = true;
            vt.lockRotation = true;
            Debug.Log("Player Die");
        }
    }
    private void PlayerCannotControl()
    {
        if (Timer_f >= deadTime) 
        { 
            PlayerANI.enabled = false;
            Debug.Log("You can't control");
            TimerOn = false;
        }
    }
    private void Timer()
    {
        if (TimerOn == true) 
        {
            Timer_f += Time.deltaTime;
            Debug.Log("Die Timer On");
        }
    }
}
