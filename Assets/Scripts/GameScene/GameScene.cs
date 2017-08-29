using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;

public class GameScene : ToyBox.Scene {

	[SerializeField]
	Player player;

	Introduction intro;

	public override void Start() {
		intro = GetComponent<Introduction>();
		base.Start();
	}

	public override string m_sceneName {
		get { return "Game"; }
	}

	public override IEnumerator OnEnter() {
		AppManager.Instance.m_fade.StartFade(new FadeIn() , Color.black , 0.5f);
		yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);

		yield return intro.PlayerJoin(player);
	}

	public override IEnumerator OnUpdate() {
		while (true) {
			yield return null;

			if (player.IsDead()) {
				break;
			}
		}
	}

	public override IEnumerator OnExit() {
		AppManager.Instance.m_fade.StartFade(new FadeOut() , Color.black , 0.5f);
		yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

}
