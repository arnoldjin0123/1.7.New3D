using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator PlayerANI;
    private bool Combo1_P_ANI = false;
    private bool Combo2_P_ANI = false;

    private int NowCombo = 0;
    private bool CanGoNext = false;
    //Slow speed tools
    private bool Combo2SPGate = false;
    private float BugTimer_f = 0f;
    private int Waitani_P = 0;

    public Transform ATKPoint;
    public float ATKLengh;
    private RaycastHit HitObject;

    private void Awake() { PlayerANI = GetComponent<Animator>(); }
    private void Update()
    {
        UpdateCombo();
        CheckComboGo();
        BugTimer();
    }
    private void BugTimer()
    {
        if (Combo1_P_ANI ==true) { BugTimer_f += Time.deltaTime; }
        else if (Combo2_P_ANI == true) { BugTimer_f += Time.deltaTime; }
        else if (Combo1_P_ANI == false && Combo2_P_ANI == false) { BugTimer_f += Time.deltaTime; }
        if (BugTimer_f> 1.5f ) 
        {
            NowCombo = 0; 
            BugTimer_f = 0f;
            CanGoNext = false;
            Combo1_P_ANI = false;
            Combo2_P_ANI = false;
        }
    }
    private void UpdateCombo()
    {
        switch (NowCombo)
        {
            case 0:
                AttackStart();
                break;
            case 1:
                Combo1();
                break;
            case 2:
                Combo2();
                break;
        }
    }
    private void AttackStart()
    {
        Debug.Log("Now is AttakStart");
        PlayerANI.SetInteger("Combo", 0);
        if (Input.GetKeyDown(KeyCode.Mouse0))  
        { 
            NowCombo=1;
            if (Physics.Raycast(ATKPoint.position, ATKPoint.forward, out HitObject, ATKLengh, 1 << 9))
            {
                MonsterHurt.GetHurt = true;
                Debug.Log(HitObject.collider.name + "is get hurt");
            }
            Debug.Log("you has right click");
        }//進COMBO1
    }
    private void Combo1()
    {
        Debug.Log("Now is Combo1");
        PlayerANI.SetInteger("Combo", 1);
        if (Waitani_P == 1)
        {
            Debug.Log("You are in wait room");
            if (Combo1_P_ANI == true && Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("You can from combo1 go next combo");
                CanGoNext = true;
            }
            if (Combo1_P_ANI == false && CanGoNext == false)
            {
                Debug.Log("You will  from combo1 go back to 0");
                ResetCombo();
            }
        }
    }
    private void Combo2()
    {
        Debug.Log("Now is Combo2");
        PlayerANI.SetInteger("Combo", 2);
        if (Waitani_P == 1)
        {
            Debug.Log("Combo2: You are in wait room");
            if (Combo1_P_ANI == true && Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("Combo2: You can from combo1 go next combo");
                CanGoNext = true;
                Combo2SPGate = true;
            }
            if (Combo1_P_ANI == false && CanGoNext == false)
            {
                Debug.Log("Combo2: You will  from combo1 go back to 0");
                ResetCombo();
            }
        }
    }
    private void CheckComboGo()
    {
        Debug.Log("You are in check combo");
        if (CanGoNext == true && Combo1_P_ANI == false && Combo2_P_ANI == false)
        {
            Debug.Log("You are overing check combo");
            Waitani_P = 0;
            CanGoNext = false;
            if (NowCombo < 2)
            {
                if (Physics.Raycast(ATKPoint.position, ATKPoint.forward, out HitObject, ATKLengh, 1 << 9))
                {
                    MonsterHurt.GetHurt = true;
                    Debug.Log(HitObject.collider.name + "is get hurt");
                }
                NowCombo = 2; //進入COMBO2
                Debug.Log("You will go to combo 2");
            }
            if (NowCombo == 2 && Combo2SPGate == true)
            {
                if (Physics.Raycast(ATKPoint.position, ATKPoint.forward, out HitObject, ATKLengh, 1 << 9))
                {
                    MonsterHurt.GetHurt = true;
                    Debug.Log(HitObject.collider.name + "is get hurt");
                }
                Combo2SPGate = false;
                NowCombo = 1; //進入COMBO1
                Debug.Log("You will go to combo 1");
            }
        }
    }
    private void ResetCombo()
    {
        Waitani_P = 0;
        NowCombo = 0;
    }
    private void Combo1Start()
    {
        Combo1_P_ANI = true;
        Waitani_P = 1;
        Debug.Log("Combo 1 has start");
    }
    private void Combo1Finish()
    {
        Combo1_P_ANI = false;
        Debug.Log("Combo 1 has finish");
    }
    private void Combo2Start()
    {
        Combo2_P_ANI = true;
        Waitani_P = 1;
        Debug.Log("Combo 2 has start");
    }
    private void Combo2Finish()
    {
        Combo2_P_ANI = false;
        Waitani_P = 0;
        Debug.Log("Combo 2 has finish");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ATKPoint.position, ATKPoint.forward * ATKLengh);
    }
}
