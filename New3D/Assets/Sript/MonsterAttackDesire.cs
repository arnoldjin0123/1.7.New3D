using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAttackDesire : MonoBehaviour
{
    [Header("MoveingSpeed"), Range(0, 50)]
    public float MonsterSpeed=2.5f;
    [Header("StopDistance"), Range(0, 10)]
    public float StopDistance=5f;
    //指定欄位
    private Animator MonsterANI;
    private Transform player;
    private Transform NoTarget;
    private NavMeshAgent nav;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        MonsterANI = GetComponent<Animator>();

        player = GameObject.Find("Player").transform;
        NoTarget = GameObject.Find("Alert").transform;

        nav.speed = MonsterSpeed;
        nav.stoppingDistance = StopDistance;

    }
    private void Update()
    {
        Track();
        Attack();
    }

    private void Track()
    {
        if (PlayGameData.playerIn == true)
        {
            nav.SetDestination(player.position);
            Debug.Log("Target is Player");
        }
        if (PlayGameData.playerIn == false)
        {
            nav.SetDestination(NoTarget.position);
            Debug.Log("None Target");
        }
    }
    private void Attack()
    {
        if (PlayGameData.playerIn == true)
        {
            MonsterANI.SetTrigger("Attack");
            PlayGameData.PlayerHP -= 30;
            Debug.Log("Character Get Damage");
        }
    }
}
