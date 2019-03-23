using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonzManager : MonoBehaviour
{
    public LayerMask blockLayer;

    private Rigidbody2D rbody;  //制御用Rigidbody2D

    private float moveSpeed = 1;    //移動速度

    //オブジェクト参照
    private GameObject gameManager; //ゲームマネージャー

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        rbody = GetComponent<Rigidbody2D>();
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

    private void FixedUpdate()
    {
        bool isBlock;

        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);
        transform.localScale = new Vector2(-1, 1);

        isBlock = Physics2D.Linecast(
            new Vector2(transform.position.x, transform.position.y + 0.5f),
            new Vector2(transform.position.x + 0.3f, transform.position.y + 0.5f),
            blockLayer);

    }
}
