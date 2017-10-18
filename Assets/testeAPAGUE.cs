using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class testeAPAGUE : MonoBehaviour {
	public NavMeshAgent agent;
	public GameObject x;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (x.transform.position);
	}
}
