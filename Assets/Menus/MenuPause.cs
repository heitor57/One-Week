using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {
	[SerializeField] GameObject Tela;
	[SerializeField]  bool Pausado;


	// Use this for initialization
	void Start () {
		Tela.SetActive(false);
		Pausado=false;
		Time.timeScale=1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Escape)){
			if(Pausado){
				Retomar();
			}
			else{
				Pause();
			}

		}
	}

	public void Pause(){
		Tela.SetActive(true);
		//Cursor.visible = true; -Moysés
		Screen.lockCursor=false;
		Time.timeScale=0;

	}

	public void Retomar(){
		Tela.SetActive(false);
		//Cursor.visible = false;  -Moysés
		Screen.lockCursor=true;
		Time.timeScale=1;

	}
	public void Sair(){
		SceneManager.LoadScene("Loader");
	}
}
