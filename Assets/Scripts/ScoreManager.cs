using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    const int RED_BALLOON = 10;  //赤風船の得点

    public Text scoreText;  //スコアテキスト用変数

    private int score = 0;  //スコア計算用変数

	// Use this for initialization
	void Start ()
    {
        //スコアの初期値を代入
        scoreText.text = "SCORE：0";
	}
	
	// Update is called once per frame
	void Update ()
    {
        //スコア加算
		if( Input.GetKey(KeyCode.Space))
        {
            score += RED_BALLOON;

            scoreText.text = "SCORE：" + score.ToString();
        }
	}
}
