using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCube : MonoBehaviour
{
    public Vector3 editRoate;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("down"))
        {
            transform.Rotate(-10, 0, 0);
            Debug.Log("啊咿呀！向下囉～");
        }

        if (Input.GetKey("up"))
        {
            transform.Rotate(10, 0, 0);
            Debug.Log("喔喔喔！向上轉向上啦！");
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -10, 0);
            Debug.Log("喔喔喔！向上轉向上啦！");
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 10, 0);
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(0, 0, -0.2f);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, 0.2f);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(-0.2f, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(0.2f, 0, 0);
        }

    }
}
