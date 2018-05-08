using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingCgManager : MonoBehaviour {

	public GameObject LeftChar;
	public GameObject RightChar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeFocus(string currentFocus)
	{
		if (currentFocus == "0") 
		{
			RightChar.GetComponent<SpriteRenderer> ().color = Color.grey;
			iTween.MoveTo(RightChar,iTween.Hash("x", 240,"time",0.3,"islocal",true,"movetopath",false));

			LeftChar.GetComponent<SpriteRenderer>().color = Color.white;
			iTween.MoveTo(LeftChar,iTween.Hash("x", -210,"time",0.3,"islocal",true,"movetopath",false));
		}
		else 
		{
			LeftChar.GetComponent<SpriteRenderer>().color = Color.grey;
			iTween.MoveTo(LeftChar,iTween.Hash("x", -240,"time",0.3,"islocal",true,"movetopath",false));

			RightChar.GetComponent<SpriteRenderer>().color = Color.white;
			iTween.MoveTo(RightChar,iTween.Hash("x", 210,"time",0.3,"islocal",true,"movetopath",false));
		}
	}

	public void setCharSprite(string spriteName, int spriteNumber, bool flg)
	{
		Object [] sprites;
		string FileName = "Sprite/" + spriteName;
		sprites = Resources.LoadAll (FileName);

		if (flg) 
		{
			RightChar.GetComponent<SpriteRenderer>().sprite = (Sprite)sprites [spriteNumber];
		}
		else 
		{
			LeftChar.GetComponent<SpriteRenderer>().sprite = (Sprite)sprites [spriteNumber];
		}

		Debug.Log ("FileName: " + FileName);
		Debug.Log ("spriteNumber: " + spriteNumber);
	}
}
