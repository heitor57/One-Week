// Chau Tran

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {

	public MovieTexture movie;
	public int mainMenu;

	RawImage rawImageComp;
	AudioSource audioS;

	void Start () {
		rawImageComp = GetComponent<RawImage> ();
		audioS = GetComponent<AudioSource> ();

		PlayClip ();
	}
	void PlayClip()
	{
		GetComponent<RawImage>().texture = movie as MovieTexture;
		movie.Play();

		audioS.clip = movie.audioClip;
		audioS.Play ();

		Time.timeScale = 1f;
		Cursor.visible = false;
	}
	void Update()
	{		
		if (!movie.isPlaying)
			SceneManager.LoadScene (mainMenu);
	}
	
}