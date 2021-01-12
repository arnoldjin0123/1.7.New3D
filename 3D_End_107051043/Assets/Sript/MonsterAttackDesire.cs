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
    //無目標時，亂走
    [Header("No target random walk change direction trigger time")]
    public float RW_ChangeTime = 5f; //每幾秒切換一次方向
    [Header("No target random walk speed"),Range(0f,1f)]
    public float RW_Speed = 0.1f; //閒置亂走時的速度
    private float RW_Timer_f = 0f; //切換方向計時器
    private bool RW_Timer_On = false; // 切換方向計時器開關
    private bool RW_DirectionChange = false; //是否可以變換方向了
    private int RW_Direction = 0; //1234=前後左右
    private bool RW_StartWalking = false;

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
        RW_Walking();
        Attack();
    }

    private void Track()
    {
        if (PlayGameData.playerIn == true && PlayGameData.MonsterHP > 0)
        {
            RW_StartWalking = false;
            RW_Timer_On = false;
            MonsterANI.SetBool("Walk", false);
            MonsterANI.SetBool("Run", nav.remainingDistance > StopDistance);
            nav.SetDestination(player.position);
            Debug.Log("Target is Player");
            if (PlayGameData.PlayerHP < 0)
            {
                PlayGameData.playerIn = false;
            }
        }
        if (PlayGameData.playerIn == false && PlayGameData.MonsterHP > 0)
        {
            MonsterANI.SetBool("Run", false);
            nav.SetDestination(NoTarget.position);
            RW_Timer_On = true;
            RandomWalkTimer();
            NoTargetWalk();
            Debug.Log("None Target");
        }
        else if (PlayGameData.playerIn == false)
        {
            nav.SetDestination(NoTarget.position);
        }
    }
    private void NoTargetWalk()
    {
        if (RW_DirectionChange == true)
        {
            RW_DirectionChange = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            MonsterANI.SetBool("Walk", true);
            RW_Direction = Random.Range(-181, 181);
            transform.rotation = Quaternion.Euler(0, RW_Direction, 0);
            RW_StartWalking = true;
        }
    }
    private void RW_Walking()
    {
        if (RW_StartWalking == true)
        {
            transform.Translate(0, 0, RW_Speed);
        }
    }
    private void RandomWalkTimer()
    {
        if (RW_Timer_On == true)
        {
            RW_Timer_f += Time.deltaTime;
            if (RW_Timer_f > RW_ChangeTime)
            { 
                RW_DirectionChange = true; 
                RW_Timer_f = 0f; 
            }
        }
    }
    private void Attack()
    {
        if (PlayGameData.playerIn==true && nav.remainingDistance <= StopDistance)
        {
            ATKTimer();
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
    private void ATKTimer()
    {
        Timer_f += Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ATKPoint.position, ATKPoint.forward * ATKLengh);
    }
}
