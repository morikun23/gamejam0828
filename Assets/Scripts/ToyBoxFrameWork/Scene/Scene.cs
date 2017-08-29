using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public abstract class Scene : MonoBehaviour {

		public virtual void Start() {
			StartCoroutine(GameLoop());
		}

		public abstract string m_sceneName { get; }

		public abstract IEnumerator OnEnter();

		public abstract IEnumerator OnUpdate();

		public abstract IEnumerator OnExit();

		protected IEnumerator GameLoop() {
			while (true) {

				Debug.Log(m_sceneName + "EnterStart");
				//シーンを開始する
				yield return OnEnter();
				Debug.Log(m_sceneName + "EnterEnd");

				Debug.Log(m_sceneName + "UpdateStart");
				//シーンを実行する
				yield return OnUpdate();
				Debug.Log(m_sceneName + "UpdateEnd");

				Debug.Log(m_sceneName + "ExitStart");
				//シーンを終了する
				yield return OnExit();
				Debug.Log(m_sceneName + "ExitEnd");
			}
		}
	}
}