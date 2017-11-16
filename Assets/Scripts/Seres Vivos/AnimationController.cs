using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RAIN;
using RAIN.Entities.Aspects;
using RAIN.Entities;

public enum AnimationStates{
	walk,
	run,
	idle,
	swOnOff, // Sword On or OFF
	soloJump,
	runJump,
	attackCombo,//só pode ser ativo depois de um ataque já ser iniciado, deveria ser como um ataque especial
	attack1, // Menos dano porem mais rapido
	death,
	jmpAttack, // Mais dano e/ou chance de critico, porem mais lento e mais chance de levar danos enquanto isto
	blockSw,
	impactSw,
	jumpIdle,
	jump,
	walkSw
}

public class AnimationController : MonoBehaviour {
	// *******Parte IA
	public RAIN.Entities.EntityRig entityrig;
	//variaveis de ajuda
	float time_init=0.5f, time_final = 1f;//Tempo de demora de um ataque em inteiro, de acordo com o clock da plataforma.
	// *******Parte IA
	public Animator animator;
	public bool temEspada;
	private PlayerBehaviour pb;
	//private string TheBug="";

	public void Start(){
		entityrig = GetComponent<EntityRig> ();//Guarda EnitityRig do GameObject respectivo
		temEspada = false;
		pb=GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
	}
	public void Update(){
		animator.SetBool ("temEspada", temEspada);
		//Debug.Log (TheBug.ToString());

	}
	public void PlayAnimation(AnimationStates stateAnimation){

		switch (stateAnimation) {
		case AnimationStates.idle:
			{
				StopAnimations ();
				if (temEspada) {
					animator.SetBool ("idleSw", true);
					//animator.Play("idleSw",-2,0f);
					//TheBug = ("idleSw");
				} else {
					animator.SetBool ("inIdle", true);
					//animator.Play ("inIdle",3,0f);
					//TheBug = ("inIdle");

				}
			}
			break;
		case AnimationStates.run:
			{
				StopAnimations ();
				if (temEspada) {
					animator.SetBool ("runSw", true);
					//animator.Play ("runSw",1,0f);
					//TheBug = ("runSw");
				} else {
					animator.SetBool ("inRun", true);
					//animator.Play("inRun",1,0f);
					//TheBug = ("inRun");
				}
			}
			break;
		case AnimationStates.walk:
			{
				StopAnimations ();
				if (temEspada) {
					//animator.SetBool ("walkSw", true);
					animator.Play ("walkSw");

					//TheBug = ("walkSw");
				} else {
					animator.SetBool ("inWalk", true);
					//animator.Play ("inWalk",2,0f);
					//TheBug = ("inWalk");
				}
			}
			break;
		case AnimationStates.swOnOff:
			{
				StopAnimations ();
				if (!temEspada) {

					//animator.SetBool ("getSw", true);
					temEspada=true;
				
					animator.Play ("getSw",-1,0f);
					//yield  WaitForSeconds (animator.GetCurrentAnimatorStateInfo (0).length);
					StartCoroutine(pb.wait("getSw"));
					((GameObject.FindWithTag ("Weapon")).GetComponent<Sword>()).naperna=false;

					//TheBug = ("getSw");

				} else {

					//animator.SetBool ("putSw", true);
					temEspada=false;
					animator.Play ("putSw",-1);
					//yield WaitForSeconds(animator["putSw"]);
					//wait(animator("putSw"));
					StartCoroutine(pb.wait("putSw"));//Chama o do player
					((GameObject.FindWithTag ("Weapon")).GetComponent<Sword>()).naperna=true;

					//TheBug = ("putSw");


				}

			}
			break;/*
		case AnimationStates.soloJump:
			{
				StopAnimations ();
				if (!temEspada) {
					animator.SetBool ("jumpIdle", true);
					StartCoroutine(wait("jumpIdle"));
				} else {
					animator.SetBool ("idleJumpSw", true);
					StartCoroutine(wait("idleJumpSw"));
				}

			}
			break;
		case AnimationStates.runJump:
			{
				StopAnimations ();
				if (!temEspada) {
					animator.SetBool ("jump", true);
					StartCoroutine(wait("jump"));
				} else {
					animator.SetBool ("jumpSw", true);
					StartCoroutine(wait("jumpSw"));
				}

			}
			break;*/
		case AnimationStates.attack1:
			{
				StopAnimations ();
				if (temEspada) {
					animator.SetBool ("attack1", true);
					//animator.Play ("attack1",-1,0f);
					//StartCoroutine(wait("attack1"));
					StartCoroutine((GameObject.FindWithTag("Weapon").GetComponent<Sword>()).wait());
					StartCoroutine(Attack());
					//TheBug = ("attack1");
				} else {
					//PlayAnimation (AnimationStates.swOnOff);
					//PlayAnimation (AnimationStates.attack1);
				}
			}
			break;
		case AnimationStates.jmpAttack:
			{
				StopAnimations ();
				if (temEspada) {
					animator.SetBool ("jmpAttack", true);
					//StartCoroutine(wait("jmpAttack"));
					//animator.Play ("jmpAttack",-1,0f);
					StartCoroutine((GameObject.FindWithTag("Weapon").GetComponent<Sword>()).wait());
					StartCoroutine(Attack());
					//TheBug = ("jmpAttack");
				} else {
					//PlayAnimation (AnimationStates.swOnOff);
					//PlayAnimation (AnimationStates.jmpAttack);

				}
			}
			break;
		case AnimationStates.blockSw:
			{
				StopAnimations ();
				if (temEspada) {
					animator.SetBool ("blockSw", true);
				} else {
					PlayAnimation (AnimationStates.swOnOff);
					PlayAnimation (AnimationStates.blockSw);

				}
			}
			break;
		case AnimationStates.attackCombo:
			{
				StopAnimations ();
				animator.SetBool ("attackCombo", true);
				StartCoroutine(Attack());
					//animator.Play ("attackCombo");
				//TheBug = ("attackCombo");
			}
			break;
		}
	}

	//CRIAR VOID PARA COMBO DE ATAQUES, ALTERNANDO ANIMAÇÕES DE ACORDO COM OS ATAQUES
	/*void OnGUI(){
		string thebug2 = "Fazendo " + TheBug;
		GUI.Box (new Rect (50, 0, 200, 50), thebug2);
	}*/
	void StopAnimations(){
		animator.SetBool("inIdle",false);
		animator.SetBool("inWalk",false);
		animator.SetBool("inRun",false);
		animator.SetBool("getSw",false);
		animator.SetBool("death",false);
		animator.SetBool("walkSw",false);
		animator.SetBool("putSw",false);
		animator.SetBool("idleJumpSw",false);
		animator.SetBool("idleSw",false);
		animator.SetBool("runSw",false);
		animator.SetBool("jumpSw",false);
		animator.SetBool("jmpAttack",false);
		animator.SetBool("attack1",false);
		animator.SetBool("attackCombo",false);
		animator.SetBool("blockSw",false);
		animator.SetBool("impactSw",false);
		animator.SetBool("jumpIdle",false);
		animator.SetBool ("jump", false);
	}
	IEnumerator Attack(){
		yield return new WaitForSeconds (time_init);
		VisualAspect tempAspect = new VisualAspect ("Attack");
		tempAspect.PositionOffset = new Vector3 (0f, 1.1f, 1.7f);
		tempAspect.VisualSize = 1;
		entityrig.Entity.AddAspect (tempAspect);
		yield return new WaitForSeconds (time_final);
		entityrig.Entity.RemoveAspect(entityrig.Entity.GetAspect("Attack"));
	}
}
