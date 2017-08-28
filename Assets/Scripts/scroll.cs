using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {
    [SerializeField] //属性　これをつけることで変数にオプションを付けられる
    scroll pair;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-0.06f, 0, 0);
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        if (transform.position.x + -0.06f <= -width)
        {
            transform.position = new Vector3(width, 0, 0);
            pair.transform.position = new Vector3(width, 0, 0);
            pair.transform.position = transform.position - new Vector3(width / 2 + width / 2, 0, 0);
        }
	}
}
