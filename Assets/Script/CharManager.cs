using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour {
	public string NameText;

	public float CharMoveSpeed;

	public int Attack;
	public int Deffence;
	public int FirstPosition;

	public int AttackDelay;

	public int SkillLevel;
	public int Attribue;

	public string SkillText;
	public string CommentText;

	public bool ThisCharMoveFlg;

	// Use this for initialization
	public void Init(string[] values)
	{
		NameText = values[0];
		CharMoveSpeed = float.Parse(values[1]);
		Attack = int.Parse(values[2]);
		Deffence = int.Parse(values[3]);
		FirstPosition = int.Parse(values[4]);
		AttackDelay = int.Parse(values[5]);
		SkillLevel = int.Parse(values[6]);
		Attribue = int.Parse(values[7]);
		SkillText = values[8];
		CommentText = values[9];
	}

	void Start () {
		setAttribueColor ();
		ThisCharMoveFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
		if ( GamaManager.instance.movigFlg && 
			ThisCharMoveFlg && 
			GamaManager.instance.effectManager.isEffectPlaying == false &&
			GamaManager.instance.atkSequenceFlg == false)
		{
			transform.position = new Vector3 (transform.position.x - CharMoveSpeed, transform.position.y, transform.position.z);
		}

		if (this.transform.position.x <= -15) 
		{
			GamaManager.instance.currentChar = this;
			GamaManager.instance.movigFlg = false;
		}
	}

	void OnMouseOver()
	{
		GetComponent<SpriteRenderer>().color = Color.green;

		if (GamaManager.instance.atkSequenceFlg == false) 
		{
			GamaManager.instance.targetChar = this;
		}

		if (GamaManager.instance.targetChar == GamaManager.instance.currentChar) 
		{
			GamaManager.instance.UiManager.setTargetUI (false);
		}

		GamaManager.instance.UiManager.setTargetUI (true);
	}

	void OnMouseExit()
	{
		setAttribueColor ();
		GamaManager.instance.UiManager.setTargetUI (false);
	}

    void setAttribueColor()
	{
		if (Attribue == 0)
		{
			GetComponent<SpriteRenderer>().color = Color.red;
		}
		else if(Attribue == 1)
		{
			GetComponent<SpriteRenderer>().color = Color.blue;
		}
		else if(Attribue == 2)
		{
			GetComponent<SpriteRenderer>().color = Color.yellow;
		}
		else if(Attribue == 3)
		{
			GetComponent<SpriteRenderer>().color = Color.white;
		}
		else if(Attribue == 4)
		{
			GetComponent<SpriteRenderer>().color = new Color(127,0,255);
		}
	}
}
