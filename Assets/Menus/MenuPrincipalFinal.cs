using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipalFinal : MonoBehaviour {

	public GameObject loadingScreen;
	public Image loadingBar;
	public Text percent;

	void Start () {
		
	}
	public void Iniciar(int sceneIndex){
		Screen.lockCursor=true;
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}
	IEnumerator LoadAsynchronously(int sceneIndex){
		loadingBar.fillAmount = 0;
		loadingScreen.SetActive (true);
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			if (progress > 99)
				progress = 99;
			loadingBar.fillAmount = progress;
			percent.text = (loadingBar.fillAmount * 100).ToString ("f0");
			yield return null;
		}
		GameObject.Find ("MenuInicial").GetComponent<Canvas> ().enabled = false;
		enabled = false;

	}
	public void Sair(){
		Application.Quit();
	}

}
