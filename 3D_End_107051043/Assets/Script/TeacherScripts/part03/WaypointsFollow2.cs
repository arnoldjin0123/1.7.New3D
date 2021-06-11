using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsFollow2 : MonoBehaviour
{

	// 定義 waypoint 取代原本的 goal，並使用陣列[]，因為可能有多個waypoints要跟隨
	//public GameObject[] waypoints;
	// 使用 Unity 內建 circuit 取代原本 waypoint 程式
	public UnityStandardAssets.Utility.WaypointCircuit circuit;
	int currentWP = 0; // 作為 waypoints[] 陣列使用的 索引index
					   //public Transform goal; //不使用單一 goal 方法
	[Header("面對目標方向")]
	public Vector3 direction;

	[Header("移動速度"), Range(0, 10)]
	public float speed = 2.0f;
	[Header("追蹤距離"), Range(0, 5)]
	public float distance = 1.0f;
	[Header("旋轉速度"), Range(0, 5)]
	public float rotSpeed = 2f;
	[Header("目標ＷＰ邊號")]
	public string currentWPname = "";


	// Use this for initialization
	void Start()
	{
		// 尋找具有 waypoint 標籤的 遊戲物件(sphere)
		//不再使用 tag = waypoints 方式，改用 Circuit 方式
		//waypoints = GameObject.FindGameObjectsWithTag("waypoint"); 
	}

	// Update is called once per frame
	void Update()
	{

		//如果場景沒有任何 waypoint 則回傳 0 (不動作)
		//if (waypoints.Length == 0) return;

		if (circuit.Waypoints.Length == 0) return;


		//原本的 goal.position.x 修改為 waypoints[] 陣列使用
		Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWP].transform.position.x,
										this.transform.position.y,
										circuit.Waypoints[currentWP].transform.position.z);
		direction = lookAtGoal - this.transform.position;
		Debug.DrawRay(this.transform.position, direction, Color.red);


		currentWPname = ("WP目標編號: " + currentWP);

		//使用 Slerp 方法，使移動物件，旋轉朝向目標物
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction),
										Time.deltaTime * rotSpeed);

		//this.transform.LookAt(lookAtGoal);


		// 當追到第一個目標時
		if (direction.magnitude < distance)
		{
			//新增管理waypoints 索引序號
			currentWP++;

			if (currentWP >= circuit.Waypoints.Length)
			{
				currentWP = 0; //序號歸零，從頭開始
			}
		}

		this.transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
