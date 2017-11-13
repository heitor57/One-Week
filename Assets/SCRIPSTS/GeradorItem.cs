using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorItem : MonoBehaviour {

	public Vector3 rotacao,posi;
	public GameObject prefab;
	public GameObject prefab2;
	public bool criar=false;
	public ArrayList teste = new ArrayList();
	public int j;
	public int k;

	// Use this for initialization
	public void Start () {
		teste.Add (prefab);
		teste.Add (prefab2);

	}
	
	// Update is called once per frame
	public void Update () {
		if (criar == true) {
			
			for(int i=0;i<k;i++){
				float x = Random.Range (740f, 746f);
				float z = Random.Range (-237f, -224f);

				posi.Set(x,0f,z);
				Instantiate ((GameObject) prefab, posi, Quaternion.Euler (rotacao));//mudar pra funcionar com itens da database

			}
			criar = false;
		}


	}

	public void Criando(int k,GameObject prefa){
		criar = true;
		this.k = k;
		this.prefab = prefa;
	}
}
//