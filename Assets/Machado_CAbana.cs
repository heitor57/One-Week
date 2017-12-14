//Script referente a uma missão de coleta do jogo -> player localizar e coletar um machado que está em um dos acampamentos de bandidos no mapa

using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machado_CAbana : MonoBehaviour {
	Vector3 Dist;
	public bool final4 = false;
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
		c.GetComponent<Canvas> ().enabled = false;
		c.GetComponent<Animation>().enabled=false;
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
		//Menssagem de interagir ao chegar no machado
		if (conversa == false && podeInteragir == true) {
			guiStyle.fontSize = 20;
			GUI.Box (new Rect (0, posiY + 20, 1000, 100), "Interagir - E", guiStyle);
			if (Input.GetKeyDown (KeyCode.E)) {
				conversa = true;
			}
		}

		if (conversa) {//Texto apresentado no fim da missão ao se encontrar e coletar o machado
			conversa = false;
			cb.Aumentarxp (250);
			c.GetComponent<Canvas> ().enabled = true;
			c.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ("Sthiler, agradeceu pelo esforço e disse que posso ficar com ele...");
			c.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = "O Machado e 250 pontos de experiência";
			c.GetComponent<Animation>().enabled=true;
			if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {
				c.GetComponent<Animation>().enabled=false;
				c.GetComponent<Canvas> ().enabled = false;
				enabled = false;
			}
			final4 = true;
		}

	}
}
