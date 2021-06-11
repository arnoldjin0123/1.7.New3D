using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTest : MonoBehaviour
{
    public float movespeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("遊戲開始");
    }

    // Update is called once per frame
    void Update()
    {
        //按鍵只偵測一次
        if (Input.GetKey("w"))
        {
            transform.Translate(0, 0, movespeed);
            //Debug.Log("遊戲進行時間[幀數]為(deltaTime)：" + Time.deltaTime + "秒");
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, -movespeed);
            //Debug.Log("遊戲進行時間[幀數]為(deltaTime)：" + Time.deltaTime + "秒");
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(-movespeed, 0, 0);
            //Debug.Log("遊戲進行時間「秒數」為Time.time：" + Time.time + "秒");
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(movespeed, 0, 0);
            //Debug.Log("遊戲進行時間「秒數」為Time.time：" + Time.time + "秒");
        }
    }
}
