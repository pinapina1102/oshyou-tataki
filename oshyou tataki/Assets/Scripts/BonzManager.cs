using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonzManager : MonoBehaviour
{

    //オブジェクト参照
    private GameObject gameManager; //ゲームマネージャー

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

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
