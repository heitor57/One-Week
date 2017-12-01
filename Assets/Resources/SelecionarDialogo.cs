using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SelecionarDialogo  {
	public static TextAsset selecionar(){
		
		string[] fileArray = Directory.GetFiles(Application.dataPath+"\\Resources","*.xml");
        System.Random rnd = new System.Random();
        int i = rnd.Next(0, fileArray.Length);
        TextAsset tex = (TextAsset)Resources.Load(fileArray[i].Split('\\')[fileArray[i].Split('\\').Length - 1].Split('.')[0]);
        return tex;
	}

}
	