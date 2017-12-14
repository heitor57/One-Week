using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour {

	public int darXP(float mult){
		return (int)(Random.Range(8,40) * mult);
	}
}
