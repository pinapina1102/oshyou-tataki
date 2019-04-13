using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*if ("ButtonBack" == )
        {
            //ボタンを押したら0.1秒後タイトルへ
            Invoke("GoBackTitle", 0.1f);
        }*/
    }

    //タイトルシーンに戻る
    public void GoBackTitle(){
        SceneManager.LoadScene("TitleScene");
    }

}
