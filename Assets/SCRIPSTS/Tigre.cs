using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigre : Animal {
	private CharacterBase cb;

	void Start () {
		cb = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
	}

	public virtual void perdeVida (float dano, CharacterBase cb)
	{
		this.vida -= dano;
		if (vida <= 0)
		{
			cb.Aumentarxp (25);
			Destroy (gameObject);
		}
	}
}
