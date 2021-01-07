using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAttack : MonoBehaviour
{
    [Header("MoveingSpeed"), Range(0, 50)]
    public float MonsterSpeed=2.5f;
    [Header("StopDistance"), Range(0, 10)]
    public float StopDistance=5f;
    //指定欄位
    private Transform player;
    private NavMeshAgent nav;
    private Animator MonsterANI;
    //警戒範圍
    private bool PlayerIn = false;
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        MonsterANI = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
}
}
