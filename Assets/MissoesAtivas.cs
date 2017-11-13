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
	public void Seta () {
		string mAtivas = " ";
		foreach (Missoes q in pb.missoes) {
			mAtivas += "\n" + q.getNome () + "\t" + q.cont + "/" + q.missao.quantidade;
		}
		GameObject.Find ("MissoesAtivas").GetComponent<Text> ().text = mAtivas;		
	}
}
