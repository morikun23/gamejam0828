using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	[SerializeField]
	GameObject smokeEffect;

	[SerializeField]
	GameObject boomEffect;

	void OnCollisionEnter2D(Collision2D collision) {
		try {
			Debug.Log("Grounded");
			Instantiate(smokeEffect , collision.transform.position + Vector3.up * 1.5f,Quaternion.identity);
			Instantiate(boomEffect , collision.transform.position,Quaternion.identity);
			collision.gameObject.GetComponent<Player>().Die();
		}
		catch {
			Debug.Log("error");
			return;
		}
	}
}
