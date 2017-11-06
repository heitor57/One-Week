using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Missao {
	public int id;
	public string texto;
	public string quemfala;
	public string nome;
	public int xp,quantidade;
	public int recompensaID,pedidoID;
	private string tipo;// tipo de missao
}
