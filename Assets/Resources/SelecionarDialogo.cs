using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SelecionarDialogo  {
	public static TextAsset selecionar(){
		int i;
		TextAsset tex;
		string[] fileArray = Directory.GetFiles(Application.dataPath+"\\Resources","*.xml");
      
		if (fileArray.Length == 1) {
			i = 0;
			tex = (TextAsset)Resources.Load (fileArray [i].Split ('\\') [fileArray [i].Split ('\\').Length - 1].Split ('.') [0]);
		} else {
			i = Random.Range (0, fileArray.Length-1);
			tex = (TextAsset)Resources.Load(fileArray[i].Split('\\')[fileArray[i].Split('\\').Length - 1].Split('.')[0]);
		}
        
        return tex;
	}

}
	