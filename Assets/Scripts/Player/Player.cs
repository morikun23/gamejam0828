using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	
	public int energy { get; private set; }

	const int ENERGY_MAX = 100;

	[SerializeField]
	int jumpPower;

	const float GRAVITY_MAX = 2;

	public bool isFreeze;
	bool isDead;

	const int JUMP_COST = 10;

	public enum State {
		RISING,		//上昇中
		DESCENT,	//下降中
	}

	public State currentState { get; private set; }

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		energy = ENERGY_MAX;
	}
	
	void Update() {

		if(isFreeze) return;

		if (Input.GetMouseButtonDown(0)) {
			if (energy >= JUMP_COST) {
				rb.velocity = Vector2.zero;
				rb.AddForce(Vector2.up * jumpPower);
				energy -= JUMP_COST;
			}
		}
	}

	void FixedUpdate () {
		currentState = (rb.velocity.y > 0) ? State.RISING : State.DESCENT;

		if(rb.velocity.y > GRAVITY_MAX) {
			rb.velocity = Vector2.up * GRAVITY_MAX;
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

	public void Die() {
		isDead = true;
		isFreeze = true;
		Debug.Log(isDead);
	}
}
