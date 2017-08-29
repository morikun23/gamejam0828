using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	
	int energy;

	const int ENERGY_MAX = 100;

	[SerializeField]
	int jumpPower;

	bool isDead;

	const int JUMP_COST = 10;

	public enum State {
		RISING,		//上昇中
		DESCENT,	//下降中
	}

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		energy = ENERGY_MAX;
	}
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (energy > JUMP_COST) {
				rb.AddForce(Vector2.up * jumpPower);
				energy -= JUMP_COST;
			}
		}
	}

	void FixedUpdate () {
		if(rb.velocity.y > 2) {
			rb.velocity = Vector2.up * 2;
		}
		else if(rb.velocity.y < -1) {
			rb.velocity = Vector2.down ;
		}
	}

	public bool IsDead() {
		return isDead;
	}

	public void Charge(int value = ENERGY_MAX) {
		energy = ENERGY_MAX;
	}

	public void Damage(int value) {
		energy -= value;
	}
}
