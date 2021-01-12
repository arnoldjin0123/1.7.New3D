using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleExit : MonoBehaviour
{
    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
