using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {

	public bool realeaseFlg;
	public bool atkFlg;
	public bool unisonFlg;
	public bool chargeFlg;

	public Text currentCharName;
	// Use this for initialization
	void Start () {
		realeaseFlg = false;

		ResetFlg();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetFlg()
	{	
		atkFlg = false;
		unisonFlg = false;
		chargeFlg = false;
	}

	public void setUI(bool Flg)
	{
		if (Flg) 
		{
			gameObject.SetActive (true);
			currentCharName.text = GamaManager.instance.currentChar.NameText;
			iTween.MoveFrom(gameObject,iTween.Hash("x", 100,"time",0.6));
		}
		else 
		{
			gameObject.SetActive (false);
		}
	}

	public void AttackButton()
	{
		ResetFlg();
		atkFlg = true;
	}

	public void UnisonButton()
	{
		ResetFlg();
	}

	public void ChargeButton()
	{
		ResetFlg();
	}

}
