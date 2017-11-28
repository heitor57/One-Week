using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEffects : MonoBehaviour {

	float timeLeft;
	Color targetColor;

	void Update()
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

		if (timeLeft <= Time.deltaTime)
		{
			// transition complete
			// assign the target color
			GetComponent<MeshRenderer>().material.color = targetColor;

			// start a new transition
			targetColor = new Color(Random.value, Random.value, Random.value);
			timeLeft = 1.0f;
		}
		else
		{
			// transition in progress
			// calculate interpolated color
			GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, targetColor, Time.deltaTime / timeLeft);

			// update the timer
			timeLeft -= Time.deltaTime;
		}
	}
}
