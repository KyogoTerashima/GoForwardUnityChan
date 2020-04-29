using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    private float speed = -12;
    //消滅
    private float deadLine = -10;

    private bool isSound = false;

    private GameObject unitychan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
		//画面外に出たら消滅
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

        GameObject unitychan = GameObject.Find("UnityChan2D");
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        string yourTag = other.gameObject.tag;

        if (yourTag == "GroundTag" || yourTag == "CubeTag")
        {
            GetComponent<AudioSource>().Play();
            Debug.Log(yourTag);
        }
        else if (yourTag == "UnityChan")
        {
            GetComponent<AudioSource>().volume = 0;
            Debug.Log(yourTag);
        }
    }


}
