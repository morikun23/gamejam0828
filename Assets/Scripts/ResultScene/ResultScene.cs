using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    //各スコアの数値
    int distance;
    int redBulloon;
    int goldBulloon;
    int human;
    int score;

	// Use this for initialization
	void Start ()
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
	void Update ()
    {
        //スコアの表示
        ScoreDisplay();

        time += Time.deltaTime;
    }

    //各スコアの表示
    void ScoreDisplay()
    {
        scoreDistance.text = "すすんだキョリ　" + distance.ToString() + "M";
        scoreRedBulloon.text = "あかのふうせん　" + redBulloon.ToString() + "コ";
        scoreGoldBulloon.text = "きんのふうせん　" + goldBulloon.ToString() + "コ";

        if (score < 10000)
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
        SceneManager.LoadScene("Title");
    }
}
