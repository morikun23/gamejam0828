using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		transform.position += Vector3.left * 0.03f;
		if(transform.position.x < -15) {
			Destroy(this.gameObject);
		}
	}
}
