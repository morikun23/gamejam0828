using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public class TestScene : Scene {

		public override string m_sceneName {
			get { return "TestScene"; }
		}

		public override IEnumerator OnEnter() {
			AppManager.Instance.m_fade.Fill(Color.black);
			AppManager.Instance.m_fade.StartFade(new FadeIn() , Color.black , 0.5f);
			yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
		}

		public override IEnumerator OnUpdate() {
			while (true) {

				if (Input.GetKeyDown(KeyCode.Space)) {
					GameManager.Instance.SetNextScene(new TestScene());
					yield break;
				}

				yield return null;

			}
		}

		public override IEnumerator OnExit() {
			AppManager.Instance.m_fade.StartFade(new FadeOut() , Color.black , 0.5f);
			yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
		}
	}

}