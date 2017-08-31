using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBalloon : Item {

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	public override void Update() {
		base.Update();
		transform.position += Vector3.left * 0.03f;
	}

	protected override void OnGotten() {
		GameScene.score.bigBallonnCount += 1;
		AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Audios/item") , transform.position);
		base.OnGotten();
	}
}
