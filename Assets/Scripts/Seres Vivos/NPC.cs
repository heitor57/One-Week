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
	bool conversa=false;
	private GameObject caixa;
	//public Texture2D img;



	// Use this for initialization
	void Start () {
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
		xml = SelecionarDialogo.selecionar ();
		guiStyle.alignment = TextAnchor.MiddleCenter;
		caixa = GameObject.Find ("Dialogs");
		caixa.GetComponent<Canvas> ().enabled = false;
		//img = Resources.Load<Texture2D> ("Panel5");
	}
	
	// Update is called once per frame
	void Update () {
		Dist = GameObject.Find ("Player").transform.position;
		Dist = Dist - transform.position;
		if (podeInteragir) {
			if (conversa) {
				//caixa.SetActive (true);
				IAIntegration.TalkNPC (GameObject.Find ("Player"), gameObject, true);
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
					if (TesteParser.Personalidade() != null) {
						int k = TesteParser.Valorpers();
						switch (TesteParser.Personalidade()) {
						case "bondade":
							GetComponent<SerVivo> ().SetBondade (GetComponent<SerVivo> ().GetBondade () + k);
							break;
						case "carisma":
							GetComponent<SerVivo> ().SetCarisma (GetComponent<SerVivo> ().GetCarisma () + k);
							break;
						case "coragem":
							GetComponent<SerVivo> ().SetCoragem (GetComponent<SerVivo> ().GetCoragem () + k);
							break;
						case "influencia":
							GetComponent<SerVivo> ().SetInfluencia (GetComponent<SerVivo> ().GetInfluencia () + k);
							break;
						case "lealdade":
							GetComponent<SerVivo> ().SetLealdade (GetComponent<SerVivo> ().GetLealdade () + k);
							break;
						case "ameaca":
							GetComponent<SerVivo> ().SetAmeaca (GetComponent<SerVivo> ().GetAmeaca () + k);
							break;
						case "lideranca":
							GetComponent<SerVivo> ().SetLideranca (GetComponent<SerVivo> ().GetLideranca () + k);
							break;
						case "inteligencia":
							GetComponent<SerVivo> ().SetLealdade (GetComponent<SerVivo> ().GetLealdade () + k);
							break;
						}
					}
				}
				if (a.Length == 0) {
					podeInteragir = false;
					primeira = true;
					conversa = false;
					//caixa.GetComponent<Canvas> ().enabled = false;
				}
			}else{
				IAIntegration.TalkNPC (GameObject.Find ("Player"), gameObject, false);			
			}
		}
	}
	void OnGUI(){
		Rect pos = new Rect (0, (Screen.height * 0.7f) , 1000, 100);
		if (Dist.magnitude < 2)
			podeInteragir = true;
		else {
			podeInteragir = false;
			//caixa.GetComponent<Canvas> ().enabled = false;
			//caixa.transform.GetChild(2).GetComponent<Text>().text=null;
		}
		if(!podeInteragir)
			conversa = false;
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
			//if (Input.GetKeyDown (KeyCode.B)) {
			//	CausarDano (gameObject.GetComponent<Destrutiveis> ().GetDano ());
			//}
		}
	//GUI.Label (new Rect (posiX, posiY, 1000, 100), a[0]);
		//GUI.color = Color.yellow;
		if (conversa) {
			
			if (primeira) {
				if (!Input.GetKey (KeyCode.Escape)) {
					//GUI.color = Color.red; //Moyses comentou isto pra usar o codigo abaixo no lugar
					//caixa.transform.GetChild (2).GetComponent<Text> ().color = Color.red;
					//GUI.Label (new Rect (posiX, posiY, 1000, 100), a[0]); //Juan que comentou isto, n sei pq
				} else {
					podeInteragir = false;
					primeira = true;
					conversa = false;
					//caixa.GetComponent<Canvas> ().enabled = false;
				}
				//caixa.GetComponent<Canvas> ().enabled = false;
			} else if (!Input.GetKey (KeyCode.Escape)) {
				//caixa.GetComponent<Canvas> ().enabled = true;
				for (i = 0; i < (a.Length); i++) {
					GUI.color = Color.black;
					//GUI.skin.box.normal.background = img;
					caixa.transform.GetChild(2).GetComponent<Text>().color = Color.black;
					if (opcaoConversa == i) {
						GUI.color = Color.red;
						//caixa.transform.GetChild(2).GetComponent<Text>().color = Color.red;
					}
					posiY = posiY + 10;
					GUI.Box (pos,a[i],guiStyle);
					//StartCoroutine ( type (a[i]) );
					//caixa.transform.GetChild(2).GetComponent<Text>().text=a [i];
				} 

			} else {
				podeInteragir = false;
				primeira = true;
				conversa = false;
				//caixa.GetComponent<Canvas> ().enabled = false;
			}
		}


	}
	/*IEnumerator type(string myText){
		
		foreach (var x in myText.ToCharArray()) {
			caixa.transform.GetChild(2).GetComponent<Text>().text += x;
			yield return new WaitForSecondsRealtime (0.2f);
		}
	}*/
}

