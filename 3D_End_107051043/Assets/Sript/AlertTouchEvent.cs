using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTouchEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && PlayGameData.PlayerHP > 0)
        {
            PlayGameData.playerIn = true;
            Debug.Log("Player in");
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayGameData.playerIn = false;
            Debug.Log("Player out");
        }
    }
}
