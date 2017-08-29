using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPack : Item {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	public override void Update() {
		base.Update();
		transform.position += Vector3.left * 0.02f;
	}

	protected override void OnGotten() {
		player.Charge();
		base.OnGotten();
	}
	
}
