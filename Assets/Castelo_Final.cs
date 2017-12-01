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
	private CharacterBase cb;
	private GameObject c;//Completou Missao
	// Use this for initialization
	void Start () {
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
		guiStyle.alignment = TextAnchor.MiddleCenter;
		cb = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
		c = GameObject.Find("Congratulations");
		c.GetComponent<Animation>().enabled=false;
		c.SetActive(false);
	}

	void Update(){
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
	}
	// Update is called once per frame
	void OnGUI(){
		posiX = 0;
		posiY = Screen.height / 2 + Screen.height / 5;
		if (Dist.magnitude < 2)
			podeInteragir = true;
		else 
			podeInteragir = false;
		if (conversa == false && podeInteragir == true) {
			//mensagem quando o usuario passar perto de um npc
			guiStyle.fontSize = 20;
			GUI.Box (new Rect (0, posiY + 20, 1000, 100), "Entrar - ENTER", guiStyle);
			//se o usuario apertar enter a conversa vai começar
			if (Input.GetKeyDown (KeyCode.Return)) {
				conversa = true;
			}
		}

		if (conversa) {
			/*if (finall) {
				fim += "BLABLABLA";
			}
			if (final2) {
				fim += "HUEHUEHUE";
			}
			if (finall == true)&&(final2) {
				fim += "AUHSHASUHASUHASUSHUASH";
			}
			if(frugal){
				fim+= "hfuygwefygwqefuywqef";
			}*/
		}

	}
}
