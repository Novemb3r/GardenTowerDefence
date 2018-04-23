using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	public AudioClip[] audioClips;
	AudioSource curClip; 

	void Start()
	{
		curClip = this.GetComponent<AudioSource> ();
	}

	void Update () {
		if (!curClip.isPlaying)
		{
			curClip.clip = audioClips [Random.Range (0, audioClips.Length)];
			curClip.Play ();
		}
	}
}
