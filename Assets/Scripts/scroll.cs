﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {
    [SerializeField] //属性　これをつけることで変数にオプションを付けられる
    scroll pair;

    SpriteRenderer MainSpriteRenderer;
    
    // publicで宣言し、inspectorで設定可能にする
    public Sprite StandbySprite;
    public Sprite HoldSprite;
    public Sprite SlashSprite;

    // Use this for initialization
    void Start () {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // 何かしらのタイミングで呼ばれる
    void ChangeStateToHold()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        // 例) HoldSpriteに変更
        MainSpriteRenderer.sprite = HoldSprite;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(-0.03f, 0, 0);
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        if (transform.position.x + -0.03f +0.1f <= -width)
        {
<<<<<<< HEAD
            transform.position = new Vector3(width, 0, 0);
            pair.transform.position = new Vector3(width, 0, 0);
            pair.transform.position = transform.position - new Vector3(width / 2 + width / 2, 0, 0);
=======
			Debug.Log("SCROLL");
            transform.position = pair.transform.position + new Vector3(width, 0 , 0);
			//pair.transform.position = new Vector3(width, 0, 0);
			//pair.transform.position = tra
>>>>>>> 1919d9bd98e4a77013cdbb682b4a9d876a792e1f
        }
	}
}
