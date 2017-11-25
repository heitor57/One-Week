using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
	bool conversa=false;
	//public GameObject caixa;




	// Use this for initialization
	void Start () {
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
		xml = SelecionarDialogo.selecionar ();

	}
	
	// Update is called once per frame
	void Update () {
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
		if (podeInteragir) {
			if (conversa) {
				GetComponent<NavMeshAgent>().isStopped = true;
				transform.LookAt (GameObject.Find ("Player").transform);
				GetComponent<Animator> ().Play("Idle");

				//caixa.SetActive (true);
				if (primeira) {
					TesteParser.Ler (xml.text);
					a = TesteParser.PegarFilhos();
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
				if (Input.GetKeyDown (KeyCode.Return)&& primeira==false) {

					a = TesteParser.PegarNoSeguinte (opcaoConversa);
					opcaoConversa = 0;
					if (TesteParser.IDmissao () != null) {
						GetComponent<Missoes> ().qual (TesteParser.IDmissao());
					}
				}
				if (a.Length == 0) {
					podeInteragir = false;
					primeira = true;
					conversa = false;
				}
			}
		}else{
			GetComponent<NavMeshAgent>().isStopped = false;
			GetComponent<Animator> ().Play("Walk");
		}
	}
	void OnGUI(){
		posiX = Screen.width / 2;
		posiY = Screen.height / 2 + Screen.height / 5;
		if (Dist.magnitude < 2)
			podeInteragir = true;
		else
			podeInteragir = false;
		if(!podeInteragir)
			conversa = false;
		//AboutAnimal aboutplayer=null;
		//foreach(AboutAnimal animal in GetComponent<RAIN.Core.AIRig> ().AI.WorkingMemory.GetItem<List<AboutAnimal>>("aboutanimal")){
		//	if (animal.Target == GameObject.Find ("Player")) {
		//		aboutplayer = animal;
		//	}
	//	}
		//if(aboutplayer.Target != null && (aboutplayer.isEnemy(GetComponent<SerVivo>()) || aboutplayer.isEnemyWeak(GetComponent<SerVivo>())))
		//	podeInteragir = false;
		if (conversa == false && podeInteragir == true) {
			//mensagem quando o usuario passar perto de um npc
			guiStyle.fontSize=20;
			GUI.Label (new Rect (posiX, posiY+20, 1000, 100), "Interagir- ENTER",guiStyle);
			//se o usuario apertar enter a conversa vai começar
			if (Input.GetKeyDown (KeyCode.Return)) {
				conversa = true;
				primeira = true;
			}
				opcaoConversa = 0;
			//if (Input.GetKeyDown (KeyCode.B)) {
			//	CausarDano (gameObject.GetComponent<Destrutiveis> ().GetDano ());
			//}
		}
	//GUI.Label (new Rect (posiX, posiY, 1000, 100), a[0]);
		//GUI.color = Color.yellow;
		if (conversa) {
			if (primeira) {
				if (!Input.GetKey(KeyCode.Escape)) {
					GUI.color = Color.red;
					//GUI.Label (new Rect (posiX, posiY, 1000, 100), a[0]);
				} else {
					podeInteragir = false;
					primeira = true;
					conversa = false;
				}
			}
			else if (!Input.GetKey (KeyCode.Escape)) {

				for (i = 0; i < (a.Length); i++) {
					GUI.color = Color.black;
					if (opcaoConversa == i) {
						GUI.color = Color.red;
					}
					posiY = posiY + 10;
					GUI.Label (new Rect (posiX, posiY, 1000, 100), a [i]);
				} 

			}else {
				podeInteragir = false;
				primeira = true;
				conversa = false;

			}
		}


	}
}

