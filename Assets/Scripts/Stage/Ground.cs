using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		try {
			Debug.Log("Grounded");
			collision.gameObject.GetComponent<Player>().Die();
		}
		catch {
			Debug.Log("error");
			return;
		}
	}
}
