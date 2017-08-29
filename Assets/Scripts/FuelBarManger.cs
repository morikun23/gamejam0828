using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarManger : MonoBehaviour
{
	[SerializeField]
	Player player;

    private Slider slider;  //燃料ゲージのスライダー

    //private float fuelValue = 100;  燃料ゲージの値

	// Use this for initialization
	void Start ()
    {
        //スライダー(燃料ゲージ)を取得
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        slider.value = player.energy;
	}
}
