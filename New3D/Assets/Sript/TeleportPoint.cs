using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class TeleportPoint : MonoBehaviour
{
    private GameObject Player;
    private GameObject FinishGamePannel;
    private Rigidbody PlayerGravity;
    private bool PlayerFly;
    private Animator FinishANI;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        PlayerGravity = GameObject.Find("Player").GetComponent<Rigidbody>();
        FinishANI = GameObject.Find("FinishGamePannel").GetComponent<Animator>();
        FinishGamePannel = GameObject.Find("FinishGamePannel");
    }
    private void Start()
    {
        FinishGamePannel.SetActive(false);
    }
    private void Update() {Fly(); }
    private void Fly() { if (PlayerFly == true) { Player.transform.Translate(0, 3f, 0); } }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Exit");
            FinishGamePannel.SetActive(true);
            FinishANI.SetTrigger("FinishAppear");
            PlayerGravity.useGravity = false;
            PlayerFly = true;
        }
    }
}
