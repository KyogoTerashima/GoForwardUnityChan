using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    //ゲームオーバーテキストを入れる
    private GameObject gameOverText;

    //走行距離のテキスト
    private GameObject runLengthText;

    //走った距離
    private float len = 0;

    //走る速度
    private float speed = 0.03f;

    //ゲームオーバーの判定
    private bool isGameOvere = false;

	// Use this for initialization
	void Start () {
        //シーンビューからオブジェクトの実態を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
		

    }
	
	// Update is called once per frame
	void Update () {

        if(isGameOvere == false)
        {
            //走った距離を更新
            this.len += this.speed;
            //走った距離を表示
            this.runLengthText.GetComponent<Text>().text = "Distance: " + this.len.ToString("F2") + "m";
        }

        //ゲームオーバーになった時
        if(isGameOvere == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
		
	}


    public void GameOver()
    {
        //ゲームオーバーになった際に画面上にゲームオーバーテキストを表示
       
            this.gameOverText.GetComponent<Text>().text = "GameOver";
            this.isGameOvere = true;
    }


}
