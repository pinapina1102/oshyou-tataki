using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //定数定義
    private const int LIMIT_TIME = 30;  //制限時間

    //オブジェクト参照
    public GameObject Bonz;        //和尚
    public GameObject textScore;   //テキストスコア
    public GameObject imageBonz;  //和尚のアニメーション
    public GameObject imageSmoke; //

    //メンバ変数
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //和尚をクリック
    public void TouchBonz()
    {
        if (Input.GetMouseButton(0) == false)
        {
            return;
        }

        Destroy(this.gameObject);

        //和尚アニメ再生
        AnimatorStateInfo stateInfo =
            imageBonz.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash ==
                Animator.StringToHash("Base Layer.float@Bonz"))
        {
            //すでに再生中なら先頭から
            imageBonz.GetComponent<Animator>().Play(stateInfo.fullPathHash, 0, 0.0f);
        }
        else
        {
            imageBonz.GetComponent<Animator>().SetTrigger("isGetScore");
        }
    }
}

