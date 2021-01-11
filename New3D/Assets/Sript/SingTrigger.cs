using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingTrigger : MonoBehaviour
{
    [Header("Title Messege"), TextArea(0, 5)]
    public string SignTitleText;
    [Header("Detail Messege"),TextArea(0,5)]
    public string SignDetailText;

    private GameObject SignPannel;
    private Text UISignTitleText;
    private Text UISignDetailText;
    private int PlayerClick = 0;

    private float Timer_f;
    private bool Timer_On = false;
    private void Awake()
    {
        SignPannel = GameObject.Find("SignPanel");
        UISignTitleText = GameObject.Find("SignPanelTitleText").GetComponent<Text>();
        UISignDetailText = GameObject.Find("SignPanelDetailText").GetComponent<Text>();
    }
    private void Start()
    {
        SignPannel.SetActive(false);
    }
    private void Timer()
    {
        if (Timer_On == true)
        {
            Timer_f += Time.deltaTime;
        }
        if (Timer_f > 1)
        {
            Timer_On = false;
            Timer_f = 0f;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        Timer();
        if (col.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && Timer_On == false)
            {
                Timer_On = true;
                PlayerClick++;
            }
        }
        if (PlayerClick %2 == 1 )
        {
            UISignTitleText.text = SignTitleText;
            UISignDetailText.text = SignDetailText;
            SignPannel.SetActive(true);
        }
        if (PlayerClick % 2 == 0)
        {
            SignPannel.SetActive(false);
        }
    }
}
