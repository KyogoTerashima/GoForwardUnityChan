using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    //ユニティちゃんのアニメーションするためのコンポーネントを入れる
    Animator animator;
    //地面の位置
    private float groundLevel = -3.0f;

    //リジットを入れる
    Rigidbody2D rigid2d;

    //ジャンプの速度の減衰
    private float dump = 0.8f;

    //ジャンプの速度  
    float jumpVelocity = 20;

    //ゲームオーバーになる位置
    private float deadLine = -9;

    private bool isUnity = false;


	// Use this for initialization
	void Start () {

        this.animator = GetComponent<Animator>();
        this.rigid2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //走るアニメーションを再生するために、Animatorのパラメータ更新
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ中は足音を消す
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力を加える
            this.rigid2d.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向への力を減衰する
        if (Input.GetMouseButton(0) == false)
        {
            if(this.rigid2d.velocity.y > 0)
            {
            this.rigid2d.velocity *= this.dump;

            }
        }

        if(gameObject.transform.position.x < this.deadLine)
        {
            //UiコントローラーのGameOver関数を呼び出して画面上にGameOverと表示
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            Destroy(gameObject);
        }

    }

    public void OnCollisionEnter2D()
    {
        this.isUnity = true;
    }

}
