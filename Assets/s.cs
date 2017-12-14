//Menssagem referente a missão de rastreamento de 2 seres pelo mapa
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s : MonoBehaviour {
	public Vector3 Dist;
	public bool final1 = false;
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
		//c.GetComponent<Animation>().enabled=false;
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
			//mensagem quando o usuario passar perto de um rastro de sangue
			guiStyle.fontSize = 20;
			GUI.Box (new Rect (0, posiY + 20, 1000, 100), "Interagir- ENTER", guiStyle);
			//se o usuario apertar enter a conversa vai começar
			if (Input.GetKeyDown (KeyCode.Return)) {
				conversa = true;
			}
		}

		if (conversa) {//Texto apresentado no fim da missão ao se localizar o rastro de sangue
			conversa = false;
			cb.Aumentarxp (250);
			c.SetActive(true);
			c.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ("Algo ou alguém padeceu aqui.\n Devido as marcas de garras e aos pelos jogados na terra, acho algum cão foi morto aqui.");
			c.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = ("250 Pontos de Experiência");

			c.GetComponent<Animation>().enabled=true;
			if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {
				c.GetComponent<Animation>().enabled=false;
				c.SetActive(false);
				enabled = false;
			}
			final1 = true;
		}

	}
}
