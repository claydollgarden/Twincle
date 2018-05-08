using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour {

	public Text targetCharName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setUI(bool Flg)
	{
		if (Flg) 
		{
			if (GamaManager.instance.atkSequenceFlg == false) 
			{
				gameObject.SetActive (true);
			}
			targetCharName.text = GamaManager.instance.targetChar.NameText;
		}
		else 
		{
			gameObject.SetActive (false);
		}
	}
}
