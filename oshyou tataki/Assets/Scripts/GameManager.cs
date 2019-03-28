using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    //定数定義
    private const int MAX_BONZ = 9;
    private const int LIMIT_TIME = 30;  //制限時間
    private const double RESPAWN_TIME = 0.5; //発生する秒数

    //オブジェクト参照
    public GameObject bonzPrefab;
    public GameObject canvasGame;
    public GameObject textScore;   //スコアテキスト
    public GameObject ImageBonz;

    //public GameObject imageSmoke; //
    //public GameObject Bonz;

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

    //


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
        GameObject bonz = (GameObject)Instantiate(bonzPrefab);
        bonz.transform.SetParent(canvasGame.transform, false);
        bonz.transform.localPosition = new Vector2(
           UnityEngine.Random.Range(-300.0f, 300.0f),
           UnityEngine.Random.Range(250.0f, -500.0f));
         
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

    //
    //和尚アニメ再生
    /*    AnimatorStateInfo stateInfo =
            ImageBonz.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash ==
                Animator.StringToHash("Base Layer.float@Bonz"))
        {
            //すでに再生中なら先頭から
            ImageBonz.GetComponent<Animator>().Play(stateInfo.fullPathHash, 0, 0.0f);
        }
        else
        {
            ImageBonz.GetComponent<Animator>().SetTrigger("isGetScore");
        }
    */

    



}

