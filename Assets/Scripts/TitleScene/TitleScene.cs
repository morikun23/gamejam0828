using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;

public class TitleScene : ToyBox.Scene {

	bool isClicked;

	public override void Start() {
		base.Start();
		isClicked = false;
	}

	public override string m_sceneName {
		get { return "Title"; }
	}

	public override IEnumerator OnEnter() {
		AppManager.Instance.m_fade.StartFade(new FadeIn() , Color.black , 0.5f);
		yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
	}

	public override IEnumerator OnUpdate() {
		while (true) {
			if (isClicked) { break; }
			yield return null;
		}
	}

	public override IEnumerator OnExit() {
		AppManager.Instance.m_fade.StartFade(new FadeOut() , Color.black , 0.5f);
		yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

	public void OnClick() {
		isClicked = true;
	}
}
