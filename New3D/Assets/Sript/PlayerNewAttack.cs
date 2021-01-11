using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNewAttack : MonoBehaviour
{

    private Animator PlayerANI;

    private int NowCombo = 0;
    private bool CanGoNext = false;
    private bool ATKCD = false;

    private float Timer_f;
    private bool Timer_On = false;

    private bool ThisCombo1Finish = false;
    private bool ThisCombo2Finish = false;

    private void Awake()
    {
        PlayerANI = GetComponent<Animator>();
        ThisCombo1Finish = GetComponent<PlayerComboDone>().FinishCombo1;
        ThisCombo2Finish = GetComponent<PlayerComboDone>().FinishCombo2;

    }
    private void Update()
    {
        StartAttack();
        CheckComboGo();
        Timer();
    }
    private void Timer()
    {
        if (Timer_On==true)
        {
            Timer_f += Time.deltaTime;
        }
        if (Timer_f > 0.5)
        {
            Timer_On = false;
        }
    }

    private void StartAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ATKCD == false)
        {
            ATKCD = true;
            NowCombo++;
            Debug.Log("Start ATK");
            Combo1();
        }
    }
    private void Combo1()
    {
        ATKCD = false;
        PlayerANI.SetInteger("Combo", NowCombo);
        Timer_On = true;
        Debug.Log("Start combo1");
        if (ThisCombo1Finish == false && Input.GetKeyDown(KeyCode.Mouse0))
        {
                CanGoNext = true;
                CheckComboGo();
                Debug.Log("Combo1: Go next combo");
        }
        if(ThisCombo1Finish == true && Timer_On == false)
        {
            ResetCombo();
            Debug.Log("Combo1: Ready to reset combo");
        }
    }
    private void Combo2()
    {
        ATKCD = false;
        PlayerANI.SetInteger("Combo", NowCombo);
        Timer_On = true;
        if (ThisCombo2Finish == false && Input.GetKeyDown(KeyCode.Mouse0))
        {
                CanGoNext = true;
                CheckComboGo();
                Debug.Log("Combo2: Go next combo");
        }
        if (ThisCombo2Finish == true && CanGoNext == false)
        {
            ResetCombo();
            Debug.Log("Combo2: Ready to reset combo");
        }
    }
    private void ResetCombo()
    {
        NowCombo = 0;
        PlayerANI.SetInteger("Combo", NowCombo);
        Debug.Log("Reset combo");
    }
    private void CheckComboGo()
    {
        if (CanGoNext == true && NowCombo < 2)
        {
            Debug.Log("Go to combo 2");
            NowCombo ++ ;
            Combo2();
        }
        if (CanGoNext == true && NowCombo >=2)
        {
            Debug.Log("Back to combo 1");
            NowCombo = 1;
            Combo1();
        }
    }
}
