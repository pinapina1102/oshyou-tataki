using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BonzManager : MonoBehaviour
{
    private Rigidbody2D rbody;  //制御用Rigidbody2D

    public float stoptime;      //停止までの時間

    public float deltime;       //消えるまでの秒数

    float time = 0f;


    //オブジェクト参照
    private GameObject gameManager; //ゲームマネージャー

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        gameManager = GameObject.Find("GameManager");
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = transform.up * 1;

    }

    void Update()
    {

        time += Time.deltaTime;  //和尚が動いた後に消える

        if (time > stoptime)
        {
        rbody.velocity = Vector2.zero;
        }
        if (time > deltime)
        {
            Destroy(this.gameObject);
        }

    }
    //和尚をクリックして取得
    public void TouchBonz()
    {
        if (Input.GetMouseButton(0) == false)
        {
            return;
        }

        gameManager.GetComponent<GameManager>().GetBonz();
        Destroy(this.gameObject);
    }

}

