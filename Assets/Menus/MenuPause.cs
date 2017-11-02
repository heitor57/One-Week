using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {
	[SerializeField] GameObject Tela;
	[SerializeField]  bool Pausado;
	private PlayerInventory inventario;
	//public GameObject inventory,characterSystem;

	// Use this for initialization
	void Start () {
		Tela.SetActive(false);
		inventario = GameObject.Find ("Player").GetComponent<PlayerInventory>();
		MonoBehaviour[] components;
		Pausado=false;
		Time.timeScale=1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape)){
			if(Pausado){
				Retomar();
			}
			else{
				Pause();
			}

		}
	}
	private void paraTudo(bool m){
		MonoBehaviour[] components = GameObject.FindObjectsOfType<MonoBehaviour>();
		foreach(MonoBehaviour component in components){
			if( (MenuPause)component != null )
				component.enabled= m;
		}
	}
	public void Pause(){		
		Tela.SetActive(true);
		//paraTudo (false);		
		//Cursor.visible = true; -Moysés
		//inventario.enabled=false;
		Screen.lockCursor=false;
		Pausado=true;
		Time.timeScale=0;
	}

	public void Retomar(){
		Tela.SetActive(false);
		//paraTudo (true);
		//Cursor.visible = false;  -Moysés
		//inventario.enabled=true;
		Screen.lockCursor = true;
		Pausado=false;
		Time.timeScale=1;
	}
	public void Sair(){
		SceneManager.LoadScene("Loader");
	}
	public bool paro(){
		return Pausado;
	}
}
