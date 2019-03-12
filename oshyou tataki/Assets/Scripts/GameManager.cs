using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    //オブジェクト参照
    public GameObject osyou;        //和尚
    public GameObject textScore;    //テキストスコア

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
    public void TouchOshou (){
        if (Input.GetMouseButton (0) == false) {
            return;
        }
        Destroy(this.gameObject);
    }
}
