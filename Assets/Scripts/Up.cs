using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Up : MonoBehaviour {
	public int ptsPraUpar;
	private PlayerBehaviour player;
	private AudioSource sauce;
	public AudioClip som;
	private GameObject pai,avo;
	private GameObject c;//Congrats
	public int vidaUP,xpUP,stmUP,habilidade;
	private string melhora="";
	private Button bt;
	private bool ativado;

	// Use this for initialization
	/*void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
		pai = gameObject.transform.parent.gameObject;
		avo = pai.gameObject.transform.parent.gameObject;
		sauce = GetComponent<AudioSource>();
		c = GameObject.Find("Congratulations");
		bt = GetComponent<Button> ();
	}
	void Update(){
		if ((player.GetUP () >= ptsPraUpar) && (taNoNivel())) {
			bt.interactable = true;
		}
	}
	bool taNoNivel(){
		int meuNivel=57,nvsAtivos=0;

		for (int i = 0; i < 5; i++) {
			if (avo.transform.GetChild (i).GetChild (1) == this.gameObject) meuNivel = i;
		}
		if (meuNivel == 0) return true;

		for (int j = 0; j < meuNivel; j++) {
			if ( netoAtivo (j) ) nvsAtivos++;
		}
		if (nvsAtivos == (meuNivel - 1)) return true;

		return false;
	}
	bool netoAtivo(int father){
		return avo.transform.GetChild (father).GetChild (1).GetComponent<Up> ().ativado;		
	}
	void Acionar(){
		
		sauce.PlayOneShot (som, 0.7F);
		pai.transform.GetChild (0).GetComponent<Text> ().color = Color.white;
		player.setUP (player.GetUP () - ptsPraUpar);
		if (vidaUP > 0)
			melhora += "Vida Aumentada para " + vidaUP;
		if (xpUP > 0)
			melhora += "Pontos de Experiência valem" + (xpUP + player.xpMultiply) + "x Mais";
		if (stmUP > 0)
			melhora += "Fôlego aumentado em " + stmUP;
		if (habilidade > 0)
			melhora += "Nova Habilidade: " + player.NomeDasHabs;
		c.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = "Aprimoramento Realizado";
		c.transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = pai.ToString();
		c.transform.GetChild (0).GetChild (3).GetComponent<Text> ().text = melhora;
		c.SetActive (true);
		if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {
			c.SetActive (false);
		}
	}*/
}
