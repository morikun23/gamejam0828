using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;

public class StartUpScene : Scene {

	

	public override string m_sceneName {
		get { return "StartUp"; }
	}

	public override IEnumerator OnEnter() {
		AppManager.Instance.m_fade.Fill(Color.black);
		yield break;
	}

	public override IEnumerator OnUpdate() {
		yield break;	
	}

	public override IEnumerator OnExit() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
		yield return null;
		
	}
}
