using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ToyBox {
	public class GameManager : MonoBehaviour {

		#region Singleton実装
		private static GameManager m_instance;

		public static GameManager Instance {
			get {
				if (m_instance == null) {
					m_instance = FindObjectOfType<GameManager>();
				}
				return m_instance;
			}
		}

		private GameManager() { }
		#endregion

		private Scene m_currentScene;

		private Scene m_nextScene;

		public string CurrentScene {
			get {
				return m_currentScene.m_sceneName;
			}
		}

		public void Initialize() {
			
			m_currentScene = new StartUpScene();
			StartCoroutine(GameLoop());

			DontDestroyOnLoad(this);
		}

		IEnumerator GameLoop() {
			while (true) {

				Debug.Log(CurrentScene + "EnterStart");
				//シーンを開始する
				yield return m_currentScene.OnEnter();
				Debug.Log(CurrentScene + "EnterEnd");

				Debug.Log(CurrentScene + "UpdateStart");
				//シーンを実行する
				yield return m_currentScene.OnUpdate();
				Debug.Log(CurrentScene + "UpdateEnd");

				Debug.Log(CurrentScene + "ExitStart");
				//シーンを終了する
				yield return m_currentScene.OnExit();
				Debug.Log(CurrentScene + "ExitEnd");

				if (Equals(m_nextScene , null)) {
					//ゲーム終了
					Debug.LogError("NextSceneが設定されていません。ゲーム終了します。");
					Application.Quit();
					break;
				}
				else {
					SceneTransition();
				}
			}
		}

		private void SceneTransition() {
			SceneManager.LoadScene(m_nextScene.m_sceneName);
			m_currentScene = m_nextScene;
			m_nextScene = null;
		}

		public void SetNextScene(Scene arg_nextScene) {
			Debug.Log(Equals(arg_nextScene , null));
			m_nextScene = arg_nextScene;
		}
	}
}