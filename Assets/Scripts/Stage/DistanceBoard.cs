using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceBoard : MonoBehaviour {

	Text text;

	int distance;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.root.position += Vector3.left * 0.03f;
		if (transform.position.x < -12) {
			UpdateText();
		}
	}

	public void UpdateText() {
		distance += 5;
		GameScene.score.distace += 50;
		text.text = distance.ToString() + "km";
		transform.root.position = new Vector3(12 , transform.root.position.y , 0);
	}
}
