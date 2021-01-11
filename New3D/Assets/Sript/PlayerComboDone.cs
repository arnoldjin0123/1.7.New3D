using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboDone : MonoBehaviour
{
    public bool FinishCombo1 = true;
    public bool FinishCombo2 = true;
    public void Combo1Start()
    {
        FinishCombo1 = false;
    }
    public void Combo1Finish()
    {
        FinishCombo1 = true;
    }
    public void Combo2Start()
    {
        FinishCombo2 = false;
    }
    public void Combo2Finish()
    {
        FinishCombo2 = true;
    }
}
