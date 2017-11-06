using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missoes : MonoBehaviour {

	private string nome;//Nome que descreve a missão.Ex: Coleta de rochas
	private bool concluida=false;//Variável para verificação se a missão foi ou não concluida
	private int xp,quantidade;
	private CharacterBase cb;
	private Item recompensa,pedido;
	private string tipo;
	private int cont;
	private PlayerInventory inventario;
	private List<Item> itensNoInventario;
	private GeradorItem geradoritem;

	public void Start(){
		cb = GameObject.Find ("Player").GetComponent<CharacterBase> ();
		cont = 0;
		inventario = GameObject.Find("Player").GetComponent<PlayerInventory>();
		itensNoInventario = inventario.getMainInventory().ItemsInInventory;
		geradoritem = new GeradorItem ();
	}

	//Métodos de acesso e modificação dos dois atributos da classe Missoes
	public string getNome(){
		return nome;
	} 

	public bool getConcluida(){
		return concluida;
	} 

	public void setNome(string nome){
		this.nome = nome;
	} 

	public void setConcluida(bool concluida){
		this.concluida = concluida;
	} 
	public int XP(){
		return xp;
	}

	public Missoes(string nome,int xp,string tipo){
		this.nome = nome;
		this.xp = xp;
		this.tipo = tipo;
	}
	public Missoes(string nome,int xp,string tipo,Item recompensa){
		this.nome = nome;
		this.xp = xp;
		this.tipo = tipo;
		this.recompensa = recompensa;
	}
	public void setMissaoColeta(int quantidade,Item pedido){
		this.quantidade = quantidade;
		this.pedido = pedido;
		
	}
	/*Método que realiza a verificação se a missão foi ou não concluida a partir da variável retorno
	protected bool missaoConcluida(){
		if(getConcluida() == true){
			concluida = true;
			return concluida;
		}
		concluida = false;
		return concluida;
	}*/
	public void Update () {
		if(concluida){
			cb.currentXP += xp;
			if(recompensa!=null){
				//da a recompensa
			}
		}
		if(tipo=="coleta"){
			geradoritem.Criando (quantidade,pedido.itemModel);
			foreach(Item x in itensNoInventario){
				if( x.itemName == pedido.itemName)
					cont++;
			}
			if(cont==quantidade)
				concluida=true;
		}

	}
}