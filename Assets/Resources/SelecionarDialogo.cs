using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

public class SelecionarDialogo {
	public static TextAsset selecionar(){
		string[] aux = Directory.GetFiles (Application.dataPath, "*.xml");
		for (int i = 0; i < aux.Length; i++) {
			aux [i] = Path.GetFileName (aux [i]);
		}

		int a = Random.Range (0, aux.Length);

		TextAsset k = Resources.Load (aux [a]) as TextAsset;

		return k;
	}

}
