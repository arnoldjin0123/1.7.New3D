using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTouchEvent : MonoBehaviour
{
    public bool PlayerIn = false;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerIn = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerIn = false;
        }
    }
}
