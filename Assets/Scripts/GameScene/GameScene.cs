using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;

public class GameScene : ToyBox.Scene {

	public class Score {
		public int distace;
		public int balloonCount;
		public int bigBallonnCount;
		public int rescueCount;
		public int TotalScore {
			get {
				int a = bigBallonnCount * 100;
				int b = balloonCount * 10;
				int c = rescueCount;
				int d = distace * 10;
				return a + b + c + d;
			}
		}

	}

	public int difficulty { get; private set; }
	private float interval;
	public static Score score;

	[SerializeField]
	Player player;

	Introduction introduction;
	Conclusion conclusion;

	[SerializeField]
	DistanceBoard board;

	public override void Start() {
		score = new Score();
		player.isFreeze = true;
		introduction = GetComponent<Introduction>();
		conclusion = GetComponent<Conclusion>();
		base.Start();
	}

	public override string m_sceneName {
		get { return "Game"; }
	}

	public override IEnumerator OnEnter() {
		AppManager.Instance.m_fade.StartFade(new FadeIn() , Color.black , 0.5f);
		yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);

		yield return introduction.PlayerJoin(player);
	}

	public override IEnumerator OnUpdate() {
		player.isFreeze = false;
		difficulty = 1;

		while (true) {
			interval -= 0.1f;
			if(interval < 0) {
				interval = 40f;
				difficulty += 1;
				if(difficulty > 15) {
					difficulty = 10;
				}
				Debug.Log(difficulty);
			}
			yield return null;

			if (player.IsDead()) {
				break;
			}
		}
		yield return conclusion.GameOver();
	}

	public override IEnumerator OnExit() {
		AppManager.Instance.m_fade.StartFade(new FadeOut() , Color.black , 0.5f);
		yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
	}
}