using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setFim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = GameObject.Find ("Final").GetComponent<Final> ().getFim ();
	}

}
