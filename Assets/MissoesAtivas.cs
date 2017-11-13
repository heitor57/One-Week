using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissoesAtivas : MonoBehaviour {
	private PlayerBehaviour pb;
	// Use this for initialization
	void Start () {
		pb = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
	}	
	// Update is called once per frame
	void Update () {
		//if (ma.activeSelf) {
		GameObject.Find ("MissoesAtivas").GetComponent<Text> ().text = setTexto();		
	}
	private string setTexto(){
		string mAtivas = " ";
		foreach (Missoes q in pb.missoes) {
			mAtivas += "\n" + q.getNome () + "\t" + q.cont + "/" + q.missao.quantidade;
		}
		return mAtivas;
	}
}
