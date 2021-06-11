using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGoal : MonoBehaviour {

	public Transform goal;
	[Header("移動速度"), Range(0, 5)]
	public float speed = 0.5f;
	[Header("保持距離"), Range(0,5)]
	public float accuracy = 0.7f;
	[Header("旋轉速度"), Range(0, 5)]
	public float rotSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 lookAtGoal = new Vector3(goal.position.x, 
										this.transform.position.y, 
										goal.position.z);
		Vector3 direction = lookAtGoal - this.transform.position;

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
												Quaternion.LookRotation(direction), 
												Time.deltaTime*rotSpeed);

		this.transform.Translate(0,0,speed*Time.deltaTime);
	}
}
