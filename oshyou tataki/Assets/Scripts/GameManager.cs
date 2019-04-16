using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    //定数定義
    private const int MAX_BONZ = 9;
    private const int LIMIT_TIME = 30;  //制限時間
    private const double RESPAWN_TIME = 0.2; //発生する秒数
    private List<Vector2> bonzposition = new List<Vector2>(); //Listの定義


    //オブジェクト参照
    public GameObject bonzPrefab;
    public GameObject canvasGame;
    public GameObject textScore;   //スコアテキスト
    public GameObject ImageBonz;
    public GameObject LimitTimeText;

    //メンバ変数
    private int score = 0;  //現在のスコア
    private int currentBonz = 0; //現在の和尚数
    private DateTime lastDateTime; //前回和尚を生成した時間
    private Vector2[] position = new Vector2[9]; //シャッフルする配列

    // Start is called before the first frame update
    void Start()
    {
        currentBonz = 1;
        //和尚生成
        for(int i=0; i<currentBonz; i++)
        {
            CreateBonz();
        }

        //初期設定
        lastDateTime = DateTime.UtcNow;

        RefreshScoreText();
    }

    // Update is called once per frame
    void Update()
    {
       if(currentBonz < MAX_BONZ){
            TimeSpan timeSpan = DateTime.UtcNow - lastDateTime;

            if (timeSpan >= TimeSpan.FromSeconds (RESPAWN_TIME)){
                while (timeSpan >= TimeSpan.FromSeconds(RESPAWN_TIME)){
                    CreateNewBonz();
                    timeSpan -= TimeSpan.FromSeconds(RESPAWN_TIME);
                }
            }
        }      
    }

    //新しい和尚の生成
    public void CreateNewBonz()
    {
        lastDateTime = DateTime.UtcNow;
        if(currentBonz >= MAX_BONZ)
        {
            return;
        }
        CreateBonz();
        currentBonz++;
    }

    //和尚生成
    public void CreateBonz()
    {
        int place = UnityEngine.Random.Range(0, 9);
        GameObject bonz = (GameObject)Instantiate(bonzPrefab);
        bonz.transform.SetParent(canvasGame.transform, false);

        switch (place) {
            case 0 : bonz.transform.localPosition = new Vector3
                (-220,  50, 0);
                break;
            case 1 : bonz.transform.localPosition = new Vector3
                (   0,  50, 0);
                break;
            case 2 : bonz.transform.localPosition = new Vector3
                ( 220,  50, 0);
                break;
            case 3:
                bonz.transform.localPosition = new Vector3
                (-220, -130, 0);
                break;
            case 4:
                bonz.transform.localPosition = new Vector3
                (   0, -130, 0);
                break;
            case 5:
                bonz.transform.localPosition = new Vector3
                ( 220, -120, 0);
                break;
            case 6:
                bonz.transform.localPosition = new Vector3
                (-220, -310, 0);
                break;
            case 7:
                bonz.transform.localPosition = new Vector3
                (   0, -310, 0);
                break;
            case 8:
                bonz.transform.localPosition = new Vector3
                ( 220, -310, 0);
                break;
        }
    }

    //和尚入手
    public void GetBonz()
    {
        score += 1;
        RefreshScoreText();
        currentBonz--;
    }

    //スコアテキスト更新
    void RefreshScoreText()
    {
        textScore.GetComponent<Text>().text =
            "得点：" + score;
    }
        
    void Bonz() {

        Invoke("", 5f);
    }

    void GoResult()
    {
        SceneManager.LoadScene("ResultScene");
    }
}

