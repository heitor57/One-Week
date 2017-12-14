//Script referente a ultima missao do jogo -> player chegar até o castelo em Verus

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castelo_Final : MonoBehaviour {
	Vector3 Dist;
	float posiX,posiY;
	public bool podeInteragir=false;
	GUIStyle guiStyle = new GUIStyle();
	bool conversa=false;
	string fim;
	private CharacterBase cb;
	public bool finaly = false;
	//private GameObject c;//Completou Missao
	// Use this for initialization
	void Start () {
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
		guiStyle.alignment = TextAnchor.MiddleCenter;
		cb = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
	}

	void Update(){
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
	}
	// Update is called once per frame
	void OnGUI(){//Menssagem de permissao parao player interagir com o castelo
		posiX = 0;
		posiY = Screen.height / 2 + Screen.height / 5;
		if (Dist.magnitude < 2)
			podeInteragir = true;
		else 
			podeInteragir = false;
		if (conversa == false && podeInteragir == true) {
			//Menssagem de interagir ao chegar no castelo ao sétimo dia
			guiStyle.fontSize = 20;
			GUI.Box (new Rect (0, posiY + 20, 1000, 100), "Entrar - ENTER", guiStyle);
			//Chamada para gerar a tela de fim de jogo qye consequentemente levará aos créditos
			if (Input.GetKeyDown (KeyCode.Return)) {
				finaly=true;
				GameObject.Find("Final").GetComponent<Final>().geraFim ();
				conversa = true;
			}
		}
	}
}
