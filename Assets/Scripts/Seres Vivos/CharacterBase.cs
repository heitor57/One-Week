using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BasicStats  {

	public float startLife; //vida inicial
	public float startStm; //stamina/ fôlego inicial
	public int strenght; //força //bem provavel a nao implementação
	public int agility; //não implementado
	public float baseAttack;//força de ataque inicial
	public float baseDefense;//defesa inicial
	//Getters & Setters
	public void SetSTM(float a){
		this.startStm =a ;
	}
	public float GetStm(){
		return startStm;
	}
	public void SetLife(float a){
		this.startLife = a;
	}
	public float GetLife(){
		return startLife;
	}
	public void SetStr(int a){
		this.strenght = a;
	}
	public int GetStr(){
		return strenght;
	}
	public void SetAgi(int a){
		this.agility = a;
	}
	public int GetAgi(){
		return agility;
	}
	public void SetAtta(float a){
		this.baseAttack = a;
	}
	public float GetAtta(){
		return baseAttack;
	}
	public void SetDef(float a){
		this.baseDefense = a;
	}
	public float GetDef(){
		return baseDefense;
	}
}


public abstract class CharacterBase : PlayerStatsController {

	public Animator animator;
	//Basic attributes
	public int currentLevel;//nivel atual
	public int currentXP;//xp atual
	public BasicStats basicStats;
	public int covX,picX;

	// Use this for initialization
	protected void Awake () {		
		SetVida (basicStats.startLife);//pega da classe literalmente acima
		SetDano (basicStats.baseAttack);// ~//~
		this.currentXP = GetCurrentXP ();//pega de PlayerStatsController
		this.currentLevel = GetCurrentLevel ();// ~//~
		covX=0;
		picX = 0;
	}
	//funções autoexplicativas
	public CharacterBase b(){
		return this;
	}

	public void Aumentarxp(int i){
		currentXP = GetCurrentXP () + i;
		SetCurrentXp (currentXp);
	}

	public void Aumentarlevel(int i){
		currentLevel = GetCurrentLevel()+i;
		SetCurrentLevel (this.currentLevel);
	}
}
