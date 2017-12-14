using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {
	public Vector3 attachPointposi;
	public Vector3 attachPointangle;
	public GameObject owner;
	// Use this for initialization
	void Start () {
		
		owner = transform.parent.gameObject;
		if (owner != null)
		{
			//transform.localScale = owner.transform.localScale;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (owner != null) {
			Tronco ();
			transform.position = attachPointposi;
			transform.eulerAngles = attachPointangle;
		} else {
			//Destroy (gameObject);
		}
	}

	public void Tronco(){
		attachPointposi = transform.parent.Find ("mixamorig:Hips").Find ("mixamorig:Spine").Find ("mixamorig:Spine1").Find ("mixamorig:Spine2").Find("mixamorig:Neck").position;
		this.attachPointposi += new Vector3 (0f,0f,0f);
		attachPointangle = transform.parent.Find ("mixamorig:Hips").Find ("mixamorig:Spine").Find ("mixamorig:Spine1").Find ("mixamorig:Spine2").Find("mixamorig:Neck").eulerAngles;
		this.attachPointangle += new Vector3 (0f,0f,0f);
	}
}
