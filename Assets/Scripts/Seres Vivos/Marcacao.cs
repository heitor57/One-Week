using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcacao : MonoBehaviour {
	GameObject a;
	GameObject b;
	void Start(){
		a = this.gameObject;
		b = Instantiate ((GameObject)Resources.Load("CUB3"));
		b.transform.parent = a.transform;
		b.transform.position = a.transform.position;
		b.transform.position += new Vector3 (0,2f,0);
	}
	void Update(){
		if (a.GetComponent<SerHumano> ().GetVida() == 0) {
			GameObject.Find ("Player").GetComponent<PlayerBehaviour> ().currentXP += 200;
		}
	}
	public void Destroi(){
		Destroy (b);
	}

}
