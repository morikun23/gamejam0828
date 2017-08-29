using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	
	public virtual void Update() {
		if(transform.position.x < -12f) {
			Destroy(this.gameObject);
		}
	}

	protected Player player;

	[SerializeField]
	protected GameObject effect;

	protected virtual void OnGotten() {
		GameObject emergedEffect = Instantiate(effect , transform.position , Quaternion.identity);
		Destroy(this.gameObject);
		Destroy(emergedEffect , 1.5f);
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			player = collider.gameObject.GetComponent<Player>();
			OnGotten();
		}
	}
}
