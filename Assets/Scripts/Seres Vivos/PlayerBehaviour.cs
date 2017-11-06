using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RAIN;
using RAIN.Entities.Aspects;
using RAIN.Entities;

public enum PlayerStates{
	Movement,
	Interact,
	Attack
}
public class PlayerBehaviour : SerHumano {
	// *******Parte IA
	public RAIN.Entities.EntityRig entityrig;
	//variaveis de ajuda
	float time_init=0.5f, time_final = 1f;//Tempo de demora de um ataque em inteiro, de acordo com o clock da plataforma.
	// *******Parte IA
	private TypeCharacter type;
	public AnimationController animationController;
	private PlayerStates currentState = PlayerStates.Movement;
	private int firstStrike=0; //Gambiarra para setar o primeiro ataque
	private int combo=0;
	public float speedWalk;
	private float speed = 3.0f;
	public float speedRun;
	public float rangeAttack;
	public float rangeInteraction;
	private float stamina;
	public Ray rayInteract;
	public float rotateSpeed =10.0f;
	public CharacterController controller;
	RaycastHit hitInfo;
	public Interacao a;
	private Transform playerPos;
	public bool podeAndar = true;
	public bool morri,shielded;
	public bool recuperando;
	private PlayerInventory equips;
	private GameObject armaAtual;
	private float moveX, moveY;
	// Use this for initialization
	protected void Start () {
		equips = GameObject.Find("Player").GetComponent<PlayerInventory>();
		armaAtual = equips.EquipedWeapon;
		entityrig = GetComponent<EntityRig> ();//Guarda EnitityRig do GameObject respectivo
		//currentLevel = PlayerStatsController.GetCurrentLevel ();
		//PlayerStatsController.SetTypeCharacter (TypeCharacter.Guerreiro);
		//type = PlayerStatsController.GetTypeCharacter ();
		stamina = basicStats.startStm;
		//basicStats = PlayerStatsController.instance.GetBasicStats (type);
		currentLevel=GetCurrentLevel();
		SetTypeCharacter (TypeCharacter.Guerreiro);
		type = GetTypeCharacter();
		basicStats = GetBasicStats (type);
		animationController = GetComponent<AnimationController> ();
		speed = speedWalk;
		controller = GetComponent<CharacterController>();
		rangeInteraction = 5;
		//base.Start();
		playerPos = GetComponent<Transform> ();
		podeAndar = true;
		Debug.Log (podeAndar);
		SetNome ("Orion");
		morri = false;
	}


	// Update is called once per frame
	void Update () {
		//base.Update();
		if (currentXP >= xpThisLevel) {
			currentXP -= xpThisLevel;
			AddLevel ();
			xpThisLevel = GameLogic.ExperienceForNextLevel (currentLevel);
		}
		if(!morri)
			switch (currentState) {
		case PlayerStates.Movement:
			{
				moveX = Input.GetAxis ("Horizontal");
				moveY = Input.GetAxis ("Vertical");

				speed = speedWalk;
				if (((moveX!=0) || (moveY!=0)) && podeAndar) {				
					if (Input.GetKey (KeyCode.LeftShift)&&!(recuperando)) {
						if (stamina <= 10) recuperando = true;	
						if (speed < speedRun) {
							speed = speed + (speed / 60);
						} else if (speed > speedRun) {
							speed = speedRun;
						}
						cansar ();
							//if (moveY > 0) {
								animationController.PlayAnimation (AnimationStates.run);
							//} else {animationController.PlayAnimation (AnimationStates.RunBack);}
						//if (Input.GetKeyDown (KeyCode.P)) animationController.PlayAnimation (AnimationStates.runJump);
					} else {
						//if (moveY > 0) {
							animationController.PlayAnimation (AnimationStates.walk);
						//} else {animationController.PlayAnimation (AnimationStates.WalkBack);}
						//if (Input.GetKeyDown (KeyCode.P)) animationController.PlayAnimation (AnimationStates.soloJump);//provavelmente conflita as com espada 
						if(stamina<basicStats.startStm)
							stamina += (basicStats.startStm / 3000);
						if (recuperando && stamina >= 60) recuperando = false;
					}

					transform.Rotate (0, moveX * rotateSpeed, 0);
					float curSpeed = speed * moveY;
					Vector3 forward = transform.TransformDirection (Vector3.forward);
					controller.SimpleMove (forward * curSpeed);

				} if((moveX==0) && (moveY==0)) {
					animationController.PlayAnimation (AnimationStates.idle);
					if(stamina<basicStats.startStm)
						stamina += (basicStats.startStm / 2300);
					//if (Input.GetKeyDown (KeyCode.P)) animationController.PlayAnimation (AnimationStates.soloJump);
					if (Input.GetKeyDown (KeyCode.Space)) {

						animationController.PlayAnimation (AnimationStates.swOnOff);
						StartCoroutine(wait());
						StartCoroutine(Attack());
					}
				}


				//Attack change state
				if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) {
					firstStrike = 2;
					currentState = PlayerStates.Attack;
				}
				if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) {
					firstStrike = 1;
					currentState = PlayerStates.Attack;
				}
				if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)){
					rayInteract = new Ray (transform.position, transform.forward);
					currentState = PlayerStates.Interact;
				}
			}
			break;
		case PlayerStates.Attack: //Cansar depois de varios ataques seguidos
			{	
				if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2) || firstStrike == 2)  {
					if (firstStrike!=0) {
						firstStrike = 0;
					}
					animationController.PlayAnimation (AnimationStates.jmpAttack);
					StartCoroutine (wait ());
					StartCoroutine(Attack());
					//Vector3 direct = transform.TransformDirection (Vector3.forward);
					//if(animationController.animator.GetComponent<Animation>().IsPlaying("jmpAttack"))
					//	controller.SimpleMove (direct * speed);

					combo++;

				}else
					if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1) || firstStrike == 1) {
						if (firstStrike!=0) {
							firstStrike = 0;
						}
						Debug.Log ("dsasdsda");
						animationController.PlayAnimation (AnimationStates.attack1);
						StartCoroutine (wait ());
						StartCoroutine(Attack());
						combo++;

					}else 
						if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))  {
							if (combo > 0) {
								animationController.PlayAnimation (AnimationStates.attackCombo);
								combo++;
								StartCoroutine (wait ());
								StartCoroutine(Attack());
							}
						} 						
						else {
							combo = 0;

							currentState = PlayerStates.Movement;

						}
			}
			break;
		case PlayerStates.Interact:
			{

				if (Physics.Raycast (rayInteract, out hitInfo, rangeInteraction)) {
					if (hitInfo.transform.gameObject.CompareTag("Entrance")) {
						(hitInfo.transform.gameObject.GetComponent <goIn> ()).changeScene ();
					}
				}
				currentState = PlayerStates.Movement;
			}
			break;
		}

		a.ReconherAlvo ();
		if (a.podeInteragir) {
			//era para verificar se o objeto é um ser humano ou nao, so que eu ainda não consegui fazer essa verificão funcionar
			//if (a.hit.transform.gameObject.GetComponent<SerHumano>()) {


			//chama a funçao de conversa.
			a.OnGUI ();


			//	}
		}
	}
	public int getCombo(){
		return combo;
	}
	private void cansar(){
		speed = ((basicStats.agility * stamina) / (basicStats.startStm * 40)) * speedRun;
		if (stamina >= 0) {
			stamina -= (basicStats.startStm / 9001);//It's Over Nine Thousands !!!!
		} else if (stamina < 0) {
			stamina = 0;
		}if (stamina >= basicStats.startStm)
			stamina = basicStats.startStm;

	}
	IEnumerator wait(){
		podeAndar = false;
		yield return new WaitForSeconds (3.0f);
		podeAndar = true;
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
	public override void perdeVida (float dano, CharacterBase cb)
	{	
		float dShield = armaAtual.GetComponentInParent<Destrutiveis> ().GetDano ();
		if (dShield == null || dShield < 0)
			dShield = 10;
		if (shielded) {
			dano -= dShield;
			if (dano < 0) {
				dano = 0;
			}
		}
		this.vida -= dano;
		if (vida <= 0)
		{
			animator.Play ("morte1");
			morri = true;
			this.GetComponent<CapsuleCollider> ().direction = 2;
			this.GetComponent<CapsuleCollider> ().center = new Vector3 (0f, 0f, 1.2f);
			StartCoroutine (pare ());


		}
	}

	public IEnumerator pare(){
		yield return new WaitForSeconds (3.0f);
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MenuMorte> ().morto = true;
	}

	public void SetStm(float a){
		stamina = a;
	}
	public float GetSTM(){
		return stamina;
	}
}
