using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Up : MonoBehaviour {
	public int ptsPraUpar;
	public GameObject player;
	public AudioSource sauce;
	public AudioClip som;
	public GameObject pai,avo;
	public GameObject c;//Congrats
	public int vidaUP,xpUP,stmUP,habilidade;
	public string melhora="";
	public Button bt;
	public bool ativado;
	public int pUps;
	public int nvsAtivos;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player");
		pai = transform.parent.gameObject;
		avo = pai.transform.parent.gameObject;
		sauce = GetComponent<AudioSource>();
		c = GameObject.Find("Congratulations");
		bt = GetComponent<Button> ();
	}
	void Update(){
		pUps = player.GetComponent<PlayerBehaviour> ().GetUP ();
		if (taNoNivel()) {
			if (pUps >= ptsPraUpar) {
				bt.interactable = true;
			}
		}
	}
	bool taNoNivel(){
		int meuNivel = 4;
		nvsAtivos=0;
		for (int i = 0; i < 5; i++) {
			if (avo.transform.GetChild (i).GetChild (1).gameObject == this.gameObject) meuNivel = i;
		}
		if (meuNivel == 0) return true;

		for (int j = 0; j <= meuNivel; j++) {
			if ( avo.transform.GetChild (j).GetChild (1).GetComponent<Up> ().ativado ) nvsAtivos++;
		}
		if (nvsAtivos == meuNivel) return true;

		return false;
	}
	public void Acionar(){
		
			sauce.PlayOneShot (som, 0.7F);
			pai.transform.GetChild (0).GetComponent<Text> ().color = Color.white;
			player.GetComponent<PlayerBehaviour> ().setUP (player.GetComponent<PlayerBehaviour> ().GetUP () - ptsPraUpar);
			if (vidaUP > 0)
				melhora += "Vida Aumentada para " + vidaUP;
			if (xpUP > 0)
				melhora += "Pontos de Experiência valem" + (xpUP + player.GetComponent<PlayerBehaviour> ().xpMultiply) + "x Mais";
			if (stmUP > 0)
				melhora += "Fôlego aumentado em " + stmUP;
			if (habilidade > 0)
				melhora += "Nova Habilidade: " + player.GetComponent<PlayerBehaviour> ().NomeDasHabs;
			c.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = "Aprimoramento Realizado";
			c.transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = pai.name;
			c.transform.GetChild (0).GetChild (3).GetComponent<Text> ().text = melhora;
			ativado = true;
			c.SetActive (true);
			player.GetComponent<PlayerBehaviour> ().melhorar (vidaUP, stmUP, xpUP, habilidade);
		 /*else {

		}*/
	}
}
