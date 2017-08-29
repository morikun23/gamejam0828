using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour {

	public IEnumerator PlayerJoin(Player player) {
		Vector3 startPos = new Vector3(-10 , 2);
		Vector3 defaultPos = new Vector3(-7 , 0);

		player.GetComponent<Rigidbody2D>().isKinematic = true;

		int key = 100;
		int cnt = 0;
		while (cnt < key) {
			player.transform.position += ((defaultPos - startPos) / key);
			cnt++;
			yield return null;
		}

		player.GetComponent<Rigidbody2D>().isKinematic = false;

	}

	public IEnumerator ShowText() {
		yield break;
	}
}
