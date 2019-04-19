using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{

    public Text highScoreLabel;
    public Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        //ハイスコアを表示
        highScoreLabel.text = "HighScore : " + PlayerPrefs.GetInt("HighScore");

        //スコアを表示
        scoreLabel.text = "Score : " + PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void HighScoreReset()
    {
        PlayerPrefs.DeleteAll();
    }

    //タイトルシーンに戻る
    public void GoBackTitle(){
        SceneManager.LoadScene("TitleScene");
    }
}
