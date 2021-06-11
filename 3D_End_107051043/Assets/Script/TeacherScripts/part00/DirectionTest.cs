using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTest : MonoBehaviour
{

    private Vector3 v1, v2;
    private Vector3 directionToGranny;


    private void Awake()
    {
        v1 = this.transform.position;
        v2 = GameObject.Find("Granny").transform.position;

        print("v1- Stevie: " + v1);
        print("v2- Granny: " + v2);
        directionToGranny = v2 - v1;
        print("directionToGranny:" + directionToGranny);
        this.transform.position += directionToGranny.normalized;
    }   

    private void Update()
    {
        //v1 = GameObject.Find("Stevie").transform.position;


        
    }
}

