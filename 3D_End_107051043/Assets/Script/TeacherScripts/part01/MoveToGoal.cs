using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform goal;
    public Vector3 direction;
    [Header("追蹤距離"), Range(0, 5)]
    public float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(goal.position);
        //goal.position: 我們想去的目標位置
        //this.transform.position: 我們目前正所在的位置
        Debug.DrawRay(this.transform.position, direction, Color.red);
        direction = goal.position - this.transform.position;
        //if (direction.magnitude > distance)
        //{
        //    this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        //}

    }
}
