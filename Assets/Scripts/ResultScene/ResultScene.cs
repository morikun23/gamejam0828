using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using ToyBox;

public class ResultScene : MonoBehaviour
{
    public GameObject iconDistance;     //アイコン：距離
    public GameObject iconRedBulloon;   //アイコン：赤風船
    public GameObject iconGoldBulloon;  //アイコン：金風船

    public GameObject textDistance;     //テキスト：距離
    public GameObject textRedBulloon;   //テキスト：赤風船
    public GameObject textGoldBulloon;  //テキスト：金風船

    public Text scoreDistance;     //スコア：距離
    public Text scoreRedBulloon;   //スコア：赤風船
    public Text scoreGoldBulloon;  //スコア：金風船
    public Text scoreResult;       //最終スコア

    public AudioSource sound1;

	private float time;

	private bool isClicked;

    //各スコアの数値
    int distance;
    int redBulloon;
    int goldBulloon;
    int human;
    int score;

	// Use this for initialization
	public void Start ()
    {
        //スコアの代入
        distance = 10;
        redBulloon = 10;
        goldBulloon = 10;
        human = 10;
        score = 0;

        time = 0;

        scoreResult.text = "スコア：0";
		
	}

	// Update is called once per frame
	public void Update ()
    {
		time += Time.deltaTime;
		ScoreDisplay();
    }

	//各スコアの表示
	void ScoreDisplay()
    {
        scoreDistance.text = "すすんだキョリ　" + GameScene.score.distace.ToString() + "M";
        scoreRedBulloon.text = "あかのふうせん　" + GameScene.score.balloonCount.ToString() + "コ";
        scoreGoldBulloon.text = "きんのふうせん　" + GameScene.score.bigBallonnCount.ToString() + "コ";

        if (score < GameScene.score.TotalScore)
        {
            score += (int)time * 100;
        }
        else if (score > 10000)
        {
            score = 10000;
        }

        scoreResult.text = "スコア：" + score.ToString();
    }

    //タイトルへ戻る
    public void BackTitle()
    {
        SceneManager.LoadScene("StartUp");
    }

	public void OnClick() {
		isClicked = true;
	}
}
