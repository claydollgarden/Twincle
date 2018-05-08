using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

	public GameObject[] AllEffect;
	GameObject PlayingEffectObj;


	public bool isEffectPlaying;

	// Use this for initialization
	void Start () {
		isEffectPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startEffect(float timeScale, CharManager charManager, int effectNumber)
	{
		//PlayingEffectObj = Instantiate (AllEffect [effectNumber], new Vector3 (charManager.transform.position.x, charManager.transform.position.y, charManager.transform.position.z), Quaternion.Euler (new Vector3 ()));
		PlayingEffectObj = Instantiate (AllEffect [effectNumber], new Vector3 (0,0,-1), Quaternion.Euler (new Vector3 ()));
		isEffectPlaying = true;
		Invoke ("setEffectPlayingFlg", timeScale);
	}

	void setEffectPlayingFlg()
	{
		isEffectPlaying = false;
		GamaManager.instance.AttackSequence ();
		Destroy (PlayingEffectObj);
	}

}
