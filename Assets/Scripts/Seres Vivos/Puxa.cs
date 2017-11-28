using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puxa {
	static int a;
	static string b;
	static GameObject c;
	public static string teste(){
		while (c == null) {
			a = Random.Range (1, 57);
			b = "Aldeao (" + a + ")";
			c = GameObject.Find (b);
			Debug.Log (c);

		}
		c.AddComponent<Marcacao> ();
		c = null;
		return b;

	}

}
