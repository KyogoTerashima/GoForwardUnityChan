using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    //スクロールの速度
    private float scrollSpeed = -0.03f;
    //背景終了位置
    private float deadLine = -16;
    //背景開始位置
    private float startLine = 15.8f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(this.scrollSpeed, 0, 0);

        //画面外に出たら、画面右端に移動
        if(transform.position.x < deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
		
	}
}
