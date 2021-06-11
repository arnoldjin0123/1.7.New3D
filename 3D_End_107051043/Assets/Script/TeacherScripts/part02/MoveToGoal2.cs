using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal2 : MonoBehaviour
{
    public float speed = 0.3f;
    public Transform goal;
    public Vector3 direction;
    [Header("追蹤距離"), Range(0, 5)]
    public float distance = 0.5f;
    //新增旋轉變數
    [Header("旋轉速度"), Range(0, 5)]
    public float rotSpeed = 0.1f;

    //新增面向目標的3軸變數
    Vector3 lookAtGoal;

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(goal.position);
        //修正移動物件會偏移 Y 軸
        lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        
        
        direction = lookAtGoal - this.transform.position;
        Debug.DrawRay(this.transform.position, direction, Color.red);

        //使用 Slerp 方法，使移動物件，旋轉朝向目標物
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                           Quaternion.LookRotation(direction),
                                            Time.deltaTime * rotSpeed);
        if (direction.magnitude > distance)
        {
            //移動有許多寫法，如下三種：
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            //this.transform.Translate(this.transform.position.x, this.transform.position.y, this.transform.position.z.CompareTo(direction.normalized * speed * Time.deltaTime));
            //this.transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }
}
