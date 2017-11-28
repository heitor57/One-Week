using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour {

	public int xp;

	public int darXP(float mult){
		return (int)(xp * mult);
	}
}
