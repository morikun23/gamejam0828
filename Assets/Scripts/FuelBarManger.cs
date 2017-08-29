using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarManger : MonoBehaviour
{
    const int FUEL_DOWN = 1;  //燃料の減少値

    private Slider slider;  //燃料ゲージのスライダー

    private float fuelValue = 100;  //燃料ゲージの値

    Player player;

	// Use this for initialization
	void Start ()
    {
        //スライダー(燃料ゲージ)を取得
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //燃料ゲージを減らす
        player = GetComponent<Player>();

        Debug.Log(player);

        if( player )
        {
            player.Damage(FUEL_DOWN);
        }
        
    }
}
