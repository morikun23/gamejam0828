using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceBoard : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.root.position += Vector3.left * 0.02f;

	}

	public void SetDistance(int distance) {
		text.text = distance.ToString() + "km";
	}
}
