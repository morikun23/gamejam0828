using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public int id;

	[SerializeField]
	GameObject balloon;

	[SerializeField]
	GameObject bigBalloon;

	[SerializeField]
	GameObject energy;

	[SerializeField]
	GameObject enemy;

	/// <summary>
	/// 生成情報
	/// 0 = 何もなし
	/// 1 = 風船
	/// 2 = タンク
	/// -1 = 敵
	/// </summary>

	const int COLUMN = 4;
	const int ROW = 8;

	Dictionary<int , int[,]> generateInfo = new Dictionary<int , int[,]> {
		{ 0 ,
			new int[COLUMN,ROW] {
			{0,0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0,0 }
			}
		},
		{ 1 ,
			new int[COLUMN,ROW] {
			{0,-1,0,1,0,2,0,0 },
			{0,0,1,2,1,0,0,0 },
			{0,1,0,0,0,2,0,0 },
			{0,0,0,0,-1,0,0,0 }
			}
		},
		{ 2 ,
			new int[COLUMN,ROW] {
			{0,-1,0,0,0,0,1,0 },
			{0,0,0,1,1,0,0,2 },
			{0,1,2,0,0,2,0,0 },
			{0,0,0,0,0,0,-1,0 }
			}
		},
		{ 3 ,
			new int[COLUMN,ROW] {
			{0,0,0,0,0,0,-1,0 },
			{0,1,0,1,0,0,2,0 },
			{0,0,0,0,0,1,0,0 },
			{0,-1,0,2,0,0,0,1 }
			}
		},
		{ 4 ,
			new int[COLUMN,ROW] {
			{0,-1,0,0,0,2,0,0 },
			{0,0,1,0,1,1,0,0 },
			{1,1,0,0,-1,0,1,0 },
			{-1,0,2,0,0,2,0,1 }
			}
		},
		{ 5 ,
			new int[COLUMN,ROW] {
			{-1,0,0,1,0,0,-1,0 },
			{0,0,1,0,1,2,0,0 },
			{0,1,2,2,0,1,0,0 },
			{1,0,0,-1,0,0,1,1 }
			}
		},
		{ 6 ,
			new int[COLUMN,ROW] {
			{0,0,0,0,1,0,0,0 },
			{-1,0,1,2,1,1,0,0 },
			{0,1,1,0,-1,2,1,0 },
			{1,0,0,0,0,0,0,1 }
			}
		},
		{ 7 ,
			new int[COLUMN,ROW] {
			{0,0,-1,0,1,0,0,0 },
			{0,2,1,1,1,2,1,0 },
			{1,1,0,0,0,0,-1,1 },
			{-1,0,0,0,0,0,0,0 }
			}
		},
		{ 8 ,
			new int[COLUMN,ROW] {
			{0,0,0,-1,-1,0,0,0 },
			{0,0,0,1,1,2,0,0 },
			{0,0,1,2,0,1,0,0 },
			{0,1,2,-1,-1,0,1,0 }
			}
		},
		{ 9 ,
			new int[COLUMN,ROW] {
			{0,0,0,-1,-1,0,1,1 },
			{0,2,0,0,1,1,0,0 },
			{0,0,1,1,0,0,2,0 },
			{1,1,0,-1,-1,0,2,0 }
			}
		},
		{ 10 ,
			new int[COLUMN,ROW] {
			{0,0,0,0,0,-1,0,0 },
			{0,-1,0,1,1,1,2,0 },
			{0,1,2,1,0,-1,1,0 },
			{1,-1,1,0,0,0,1,0 }
			}
		},
		{ 11 ,
			new int[COLUMN,ROW] {
			{0,0,0,0,0,0,2,0 },
			{0,0,-1,2,2,0,0,0 },
			{0,1,1,1,0,1,-1,1 },
			{1,0,-1,0,1,0,1,-1 }
			}
		},
		{ 12 ,
			new int[COLUMN,ROW] {
			{0,2,0,-1,-1,0,0,0 },
			{2,0,0,1,1,0,-1,0 },
			{0,0,1,-1,-1,1,1,2 },
			{0,2,0,0,0,0,-1,-1 }
			}
		},
		{ 13 ,
			new int[COLUMN,ROW] {
			{0,0,0,-1,0,1,2,0 },
			{0,-1,1,0,1,-1,0,0 },
			{0,1,2,-1,0,1,2,1 },
			{1,0,-1,0,0,0,-1,0 }
			}
		},
		{ 14 ,
			new int[COLUMN,ROW] {
			{0,0,0,-1,1,1,1,1 },
			{0,2,0,0,2,-1,-1,2 },
			{0,1,1,1,0,0,1,0 },
			{1,0,0,1,1,1,-1,-1 }
			}
		},
		{ 15 ,
			new int[COLUMN,ROW] {
			{0,0,0,2,-1,0,1,0 },
			{0,-1,0,2,1,-1,-1,0 },
			{1,1,0,1,2,1,0,1 },
			{0,-1,1,2,-1,1,1,0 }
			}
		},
	};

	GameScene sceneManager;

	public void Start() {
		sceneManager = FindObjectOfType<GameScene>();
		StartCoroutine(OnUpdate());
	}

	public IEnumerator OnUpdate() {
		while (true) {
			for (int i = 0; i < ROW; i++) {
				Generate(generateInfo[sceneManager.difficulty][id , i]);
				yield return new WaitForSeconds(1.5f);
			}
		}
	}
	
	private void Generate(int generateId) {
		GameObject generateObject = null;
		switch (generateId) {
			case 0: return;
			case 1:generateObject = Random.Range(0,11) > 8? bigBalloon : balloon; break;
			case 2: generateObject = energy; break;
			case -1:generateObject = enemy; break;
		}

		Instantiate(generateObject , transform.position , Quaternion.identity);

	}
}
