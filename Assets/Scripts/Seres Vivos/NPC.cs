using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
	public TextAsset xml;
	MUsuario AuxMissao;
	Vector3 Dist;
	float posiX;
	float posiY;
	public int opcaoConversa=0;
	public string[] a;
	public string b;
	int i;
	public bool podeInteragir=false;
	public bool primeira=false;
	string tipo;
	GUIStyle guiStyle = new GUIStyle();
	bool conversa = false;
	int diplomata;
	//public Texture2D img;



	// Use this for initialization
	void Start () {
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
		xml = SelecionarDialogo.selecionar ();


		//img = Resources.Load<Texture2D> ("Panel5");
	}
	
	// Update is called once per frame
	void Update () {
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
		diplomata = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ().diplomata;
		if (podeInteragir) {
			if (conversa) {
				IAIntegration.TalkNPC (GameObject.Find ("Player"), gameObject, true);
				if (primeira) {
					TesteParser.Ler (xml.text);
					a = TesteParser.PegarFilhos ();
					if (Input.GetKeyDown (KeyCode.Return))
						primeira = false;
				}
				if (Input.GetKeyDown (KeyCode.L))
					opcaoConversa++;
				if (Input.GetKeyDown (KeyCode.O))
					opcaoConversa--;
				if (opcaoConversa >= a.Length) {
					opcaoConversa = 0;
				} else if (opcaoConversa < 0) {
					opcaoConversa = a.Length - 1;
				}
				if (Input.GetKeyDown (KeyCode.Return) && primeira == false) {

					a = TesteParser.PegarNoSeguinte (opcaoConversa);
					opcaoConversa = 0;
					if (TesteParser.IDmissao () != null) {
						GetComponent<Missoes> ().qual (TesteParser.IDmissao ());
					}
					if (TesteParser.Personalidade () != null) {
						int k = TesteParser.Valorpers ();
						switch (TesteParser.Personalidade ()) {
						case "bondade":
							GetComponent<SerVivo> ().SetBondade (GetComponent<SerVivo> ().GetBondade () + k-diplomata);
							break;
						case "carisma":
							GetComponent<SerVivo> ().SetCarisma (GetComponent<SerVivo> ().GetCarisma () + k-diplomata);
							break;
						case "coragem":
							GetComponent<SerVivo> ().SetCoragem (GetComponent<SerVivo> ().GetCoragem () + k-diplomata);
							break;
						case "influencia":
							GetComponent<SerVivo> ().SetInfluencia (GetComponent<SerVivo> ().GetInfluencia () + k-diplomata);
							break;
						case "lealdade":
							GetComponent<SerVivo> ().SetLealdade (GetComponent<SerVivo> ().GetLealdade () + k-diplomata);
							break;
						case "ameaca":
							GetComponent<SerVivo> ().SetAmeaca (GetComponent<SerVivo> ().GetAmeaca () + k-diplomata);
							break;
						case "lideranca":
							GetComponent<SerVivo> ().SetLideranca (GetComponent<SerVivo> ().GetLideranca () + k-diplomata);
							break;
						case "inteligencia":
							GetComponent<SerVivo> ().SetLealdade (GetComponent<SerVivo> ().GetLealdade () + k-diplomata);
							break;
						}
					}
				}
				if (a.Length == 0) {
					podeInteragir = false;
					primeira = true;
					conversa = false;
				}
			} else {
				IAIntegration.TalkNPC (GameObject.Find ("Player"), gameObject, false);			
			}
		} else {
			IAIntegration.TalkNPC (GameObject.Find ("Player"), gameObject, false);			
		}
	}
	void OnGUI(){
		posiX = 0;
		posiY = (Screen.height * 0.7f);
		guiStyle.alignment = TextAnchor.MiddleCenter;
		Rect pos = new Rect (0f, posiY , 1000, 100);
		if (Dist.magnitude < 2)
			podeInteragir = true;
		else {
			podeInteragir = false;
		}
		if(podeInteragir){
			//Parte IA - Começo
			AboutAnimal aboutplayer=null;
			foreach(AboutAnimal animal in GetComponent<RAIN.Core.AIRig> ().AI.WorkingMemory.GetItem<List<AboutAnimal>>("aboutanimal")){
				if (animal.Target == GameObject.Find ("Player")) {
					aboutplayer = animal;
				}
			}
			if(aboutplayer.Target != null && (aboutplayer.isEnemy(GetComponent<SerVivo>()) || aboutplayer.isEnemyWeak(GetComponent<SerVivo>())))
				podeInteragir = false;
			//Parte IA - Fim
		}
		if(!podeInteragir)
			conversa = false;
		
		if (conversa == false && podeInteragir == true) {
			//mensagem quando o usuario passar perto de um npc
			guiStyle.fontSize=20;
			GUI.Box (pos, "Interagir- ENTER",guiStyle);
			//se o usuario apertar enter a conversa vai começar
			if (Input.GetKeyDown (KeyCode.Return)) {
				conversa = true;
				primeira = true;
			}
				opcaoConversa = 0;
		}
		if (conversa) {
			
			if (primeira) {
				if (!Input.GetKey (KeyCode.Escape)) {
					//GUI.color = Color.red;
				} else {
					podeInteragir = false;
					primeira = true;
					conversa = false;
				}
			} else if (!Input.GetKey (KeyCode.Escape)) {
				for (i = 0; i < (a.Length); i++) {
					//GUI.color = Color.black;
					guiStyle.normal.textColor = Color.black;
					if (opcaoConversa == i) {
						//GUI.color = Color.red;
						guiStyle.normal.textColor = Color.red;
					}
					posiY = posiY + 10;
					pos = new Rect (0, posiY, 1000, 100);
					GUI.Box (pos,a[i],guiStyle);
				} 

			} else {
				podeInteragir = false;
				primeira = true;
				conversa = false;
			}
		}


	}
}

