using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missoes : MonoBehaviour {

	private string nome;//Nome que descreve a missão.Ex: Coleta de rochas
	public bool concluida=false;//Variável para verificação se a missão foi ou não concluida
	private int xp,quantidade;
	private CharacterBase cb;
	private int recompensaID,pedidoID;
	private string tipo;
	public int cont=0;
	private PlayerInventory inventario;
	private List<Item> itensNoInventario;
	private bool feito;

	public Missao missao;
	public TextAsset xml;
	static ItemDataBaseList inventoryItemList;
	public bool primeira = false;

	public void Start(){
		cb = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
		inventario = GameObject.Find("Player").GetComponent<PlayerInventory>();


		inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");
	}

	public void qual(string i){
		Missao[] aux=XMLParser.Dialogo (xml.text);
		foreach(Missao x in aux){
			if (x.id.Equals(i)) {
				missao = x;
				criador ();
			}
		}
	}

	public void criador(){
		nome = missao.nome;
		xp = missao.xp;
		recompensaID = missao.recompensaID;
		tipo = missao.tipo;
		if (tipo == "coleta") {
			pedidoID = missao.pedidoID;
			quantidade = missao.quantidade;
		}
		Missoes m = this;
		GameObject.Find ("Player").GetComponent<PlayerBehaviour> ().AdicionarMissao (m);
		concluida = false;


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
	//Metodos Construtores
	public Missoes(string nome,int xp,string tipo){
		this.nome = nome;
		this.xp = xp;
		this.tipo = tipo;
	}
	public Missoes(string nome,int xp,string tipo,int recompensaID){
		this.nome = nome;
		this.xp = xp;
		this.tipo = tipo;
		this.recompensaID = recompensaID;
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
		if(concluida==true && primeira==false){
			cb.Aumentarxp (xp);
			//GameObject c  =GameObject.Find("Congratulations");
			//c.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ("\n" + this.getNome () + "\t" + this.cont + "/" + this.missao.quantidade);
			//string rew = (this.xp+" Pontos de Experiência");
			if(recompensaID!=null){//da a recompensa				
				inventario.principal().addItemToInventory(recompensaID);
				//rew += (" e\n"+inventoryItemList.getItemByID (missao.recompensaID).itemName);
			}
			//c.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = rew;
			//c.SetActive (true);
			primeira = true;
		}
		if(tipo=="coleta"){
			if(!feito){
				GetComponent<GeradorItem>().Criando (quantidade, (inventoryItemList.getItemByID (missao.pedidoID)).itemModel);
				feito = true;
			}
			if (cont < quantidade && concluida==false) {
				 cont = 0;
				//itensNoInventario = inventario.GetComponent<Inventory>().ItemsInInventory;
				itensNoInventario = inventario.principal().ItemsInInventory;
				foreach(Item x in itensNoInventario){
					//Debug.Log(x.itemID);
					if (x.itemID == pedidoID) {
						cont++;
					}
				}
			}else{
				concluida=true;
			}
			

			//concluida = true;
		}

	}
	public int qntsTem(){
		int c = 0;
		itensNoInventario = inventario.GetComponent<Inventory>().ItemsInInventory;
		foreach(Item x in itensNoInventario){
			Debug.Log(x.itemID);
			if (x.itemID == pedidoID) {
				
				c++;
			}
		}
		return c;
	}
}