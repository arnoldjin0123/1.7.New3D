using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAttackDesire : MonoBehaviour
{
    [Header("MoveingSpeed"), Range(0, 50)]
    public float MonsterSpeed = 2.5f;
    [Header("StopDistance"), Range(0, 10)]
    public float StopDistance = 5f;
    //指定欄位
    private Animator MonsterANI;
    private Transform player;
    private Transform NoTarget;
    private NavMeshAgent nav;
    //記時器
    [Header("Attack Cool Down Time"),Range(0,5)]
    public float ATKCD=0.5f;
    private float Timer_f=0f;
    //攻擊射線
    public Transform ATKPoint;
    public float ATKLengh;
    private RaycastHit HitObject;

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
            MonsterANI.SetBool("Walk", nav.remainingDistance > StopDistance);
            nav.SetDestination(player.position);
            Debug.Log("Target is Player");
        }
        if (PlayGameData.playerIn == false)
        {
            MonsterANI.SetBool("Walk", false);
            nav.SetDestination(NoTarget.position);
            Debug.Log("None Target");
        }
    }
    private void Attack()
    {
        if (PlayGameData.playerIn==true && nav.remainingDistance <= StopDistance)
        {
            Timer();
            if (Timer_f >= ATKCD)
            {
                Timer_f = 0;
                MonsterANI.SetTrigger("Attack");
                if (Physics.Raycast(ATKPoint.position, ATKPoint.forward, out HitObject, ATKLengh, 1 << 8))
                {
                    PlayerHurt.GetHurt = true;
                    Debug.Log(HitObject.collider.name+"is get hurt");
                }
            }
        }
    }
    private void Timer()
    {
        Timer_f += Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ATKPoint.position, ATKPoint.forward * ATKLengh);
    }
}
