using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //定数定義
    private const int LIMIT_TIME = 30;  //制限時
    private const int MAX_BONZ = 9; //和尚の最大出現数

    //オブジェクト参照
    public GameObject bonzPrefab;
    public GameObject canvasGame;
    public GameObject textScore;   //スコアテキスト

    //public GameObject[] imageBonz =　new GameObject[9];  //和尚のアニメーション
    //public GameObject imageSmoke; //
    //public GameObject Bonz;

    //メンバ変数
    private int score = 0;  //現在のスコア


    // Start is called before the first frame update
    void Start()
    {
        //和尚生成
        for(int i=0; i<MAX_BONZ; i++)
        {
            CreateBonz();
        }
        RefreshScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //和尚生成
    public void CreateBonz()
    {
        GameObject bonz = (GameObject)Instantiate(bonzPrefab);
        bonz.transform.SetParent(canvasGame.transform, false);
        bonz.transform.localPosition = new Vector3(
           UnityEngine.Random.Range(-300.0f, 300.0f),
           UnityEngine.Random.Range(250.0f, -500.0f),
           0f);
    }

    //和尚入手
    public void GetBonz()
    {
        score += 1;
        RefreshScoreText();
    }

    //スコアテキスト更新
    void RefreshScoreText()
    {
        textScore.GetComponent<Text>().text =
            "得点：" + score;
    }

      /*  //和尚アニメ再生
        AnimatorStateInfo stateInfo =
            Bonz.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash ==
                Animator.StringToHash("Base Layer.float@Bonz"))
        {
            //すでに再生中なら先頭から
            Bonz.GetComponent<Animator>().Play(stateInfo.fullPathHash, 0, 0.0f);
        }
        else
        {
            Bonz.GetComponent<Animator>().SetTrigger("isGetScore");
        }
    }
    */
}

