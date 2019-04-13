using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class ResultManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //ボタンを押したら0.1秒後タイトルへ
        Invoke("GoBackTitleScene", 0.1f);
    }

    //ステージシーンに戻る
    void GoBackTitleScene(){
        EditorSceneManager.LoadScene("TitleManager");
    }

}
