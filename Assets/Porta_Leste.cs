//Missão referente ao terceiro dia de jogo -> player ir até a cidade do leste, na casa do capitão e interagrir com ela

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porta_Leste : MonoBehaviour {
	Vector3 Dist;
	public bool final3 = false;
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
		StartCoroutine (Wait());
	}
	IEnumerator Wait(){
		yield return new WaitForSecondsRealtime (3);
		//c.SetActive (false);
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
			//Menssagem de interagir ao chegar na casa no terceiro dia
			guiStyle.fontSize = 20;
			GUI.Box (new Rect (0, posiY + 20, 1000, 100), "Interagir- ENTER", guiStyle);
			//se o usuario apertar enter a conversa vai começar
			if (Input.GetKeyDown (KeyCode.Return)) {
				conversa = true;
			}
		}

		if (conversa) {//Texto apresentado no fim da missão ao se encontrar e coletar o machado
			conversa = false;
			cb.Aumentarxp (250);
			c.SetActive(true);
			c.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ("A casa parece fechada a dias. \n Suspeito que Petr tenha sido enviado a alguma missão. \n Acho que devo ir a Verus conversar com os soldados.");
			c.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = ("250 Pontos de Experiência");
			c.GetComponent<Animation>().enabled=true;
			if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {
				c.GetComponent<Animation>().enabled=false;
				c.SetActive(false);
				enabled = false;
			}
			final3 = true;
		}

	}
}
