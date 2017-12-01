using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sangue : MonoBehaviour {
	Vector3 Dist;
	public bool finall = false;
	float posiX,posiY;
	public bool podeInteragir=false;
	GUIStyle guiStyle = new GUIStyle();
	bool conversa=false;
	private CharacterBase cb;
	private GameObject c;//Completou Missao
	// Use this for initialization
	void Start () {
		Dist = GameObject.Find ("Player").transform.position;
		guiStyle.alignment = TextAnchor.MiddleCenter;
		cb = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
		c = GameObject.Find("Congratulations");
		StartCoroutine (wait ());

	}

	void Update(){
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
	}
	// Update is called once per frame
	void OnGUI(){
		posiX = 0;
		posiY = Screen.height / 2 + Screen.height / 5;
		float distance = Vector3.Distance(this.gameObject.transform.position, Dist);
		if (distance < 2)
			podeInteragir = true;
		else 
			podeInteragir = false;
		if (conversa == false && podeInteragir == true) {
			//mensagem quando o usuario passar perto de um npc
			guiStyle.fontSize = 20;
			GUI.Box (new Rect (0, posiY + 20, 1000, 100), "Interagir- ENTER", guiStyle);
			//se o usuario apertar enter a conversa vai começar
			if (Input.GetKeyDown (KeyCode.Return)) {
				conversa = true;
			}
		}

		if (conversa) {
			conversa = false;
			cb.Aumentarxp (250);
			c.SetActive(true);
			c.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ("Isso é sangue... mas não me parece fresco, presumo que algo terrível ocorreu aqui.\n Pelas marcas no terreno, creio quedescobri o que aconteceu com aquele \n rapaz desaparecido a dias.");
			c.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = ("250 Pontos de Experiência");
			c.GetComponent<Animation>().enabled=true;
			if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {
				c.GetComponent<Animation>().enabled=false;
				c.SetActive(false);
				enabled = false;
			}
			finall = true;
		}

	}
	public IEnumerator wait(){
		yield return new WaitForSecondsRealtime (2f);


	}
}
