using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LimitTime : MonoBehaviour
{

    GameObject limitTimeUI;
    float time = 10.00f;
    

    // Start is called before the first frame update
    void Start()
    {
        this.limitTimeUI = GameObject.Find("LimitTimeText");
    }

    // Update is called once per frame
    void Update()
    {
        //毎フレームごとに制限時間を減らしていく
        this.time -= Time.deltaTime;
        if(this.time < 0)
        {
            this.limitTimeUI.GetComponent<Text>().text = "オワオワリでぇ～す";
            /* Invoke("GoBackTitle",3.0f); */
        }
        else
        {
            //timeを文字列に変換した物をテキストに表示する
            this.limitTimeUI.GetComponent<Text>().text = this.time.ToString("F1");
        }
    }

  /*  void GoBackTitle()
    {
        SceneManager.LoadScene("TitleScene");
    } */
}
