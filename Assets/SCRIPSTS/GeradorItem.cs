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
	float[] x;
	float[] z;

	// Use this for initialization
	public void Start () {
		teste.Add (prefab);
		teste.Add (prefab2);

	}

	// Update is called once per frame
	public void Update () {
		if (criar == true) {
			
			int h = Random.Range (0, 5);
			for(int i=0;i<k;i++){
				x[0] = Random.Range (740f, 746f);
				z[0] = Random.Range (-237f, -224f);

				x[1] = Random.Range (620f, 710f);
				z[1] = Random.Range (-320f, -230f);

				x[2] = Random.Range (700f, 760f);
				z[2] = Random.Range (300f, 360f);

				x[3] = Random.Range (715f, 760f);
				z[3] = Random.Range (170f, 250f);

				x[4] = Random.Range (325f, 390f);
				z[4] = Random.Range (340f, 370f);

				x[5] = Random.Range (240f, 315f);
				z[5] = Random.Range (281f, 350f);


				posi.Set(x[h],0f,z[h]);
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