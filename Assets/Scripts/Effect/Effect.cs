using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

	[SerializeField]
	GameObject itemGetEffect;
	[SerializeField]
	GameObject damagedEffect;
	[SerializeField]
	GameObject gameOverEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ItemGet(Vector3 position) {
		//Instantiate(itemGetEffect , position , Quaternion.identity);
		
	}
}
