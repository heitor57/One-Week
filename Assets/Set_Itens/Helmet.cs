using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour {

	public Vector3 attachPointposi;
	public Vector3 attachPointangle;
	public GameObject owner;
	// Use this for initialization
	void Start () {

		owner = transform.parent.gameObject;

	}

	// Update is called once per frame
	void Update () {
		if (owner != null) {
			Tronco ();
			transform.position = attachPointposi;
			transform.eulerAngles = attachPointangle;
		} else {
			Destroy (gameObject);
		}
	}

	public void Tronco(){
		attachPointposi = transform.parent.Find ("mixamorig:Hips").Find ("mixamorig:Spine").Find ("mixamorig:Spine1").Find ("mixamorig:Spine2").Find("mixamorig:Neck").Find("mixamorig:Head").position;
		this.attachPointposi += new Vector3 (0,0,-0.05f);
		attachPointangle = transform.parent.Find ("mixamorig:Hips").Find ("mixamorig:Spine").Find ("mixamorig:Spine1").Find ("mixamorig:Spine2").Find("mixamorig:Neck").Find("mixamorig:Head").eulerAngles;
		this.attachPointangle += new Vector3 (0,0,0);
	}
}

