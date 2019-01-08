using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharListUI : MonoBehaviour {

	public ScrollContentSet scrollContentSetting;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setUI(string mapName)
	{
        GameManager.Instance.activeCharListFlg = true;
        gameObject.SetActive (true);
        scrollContentSetting.Populate (mapName);
        iTween.MoveFrom(gameObject,iTween.Hash("x", 100,"time",0.3));

	}

	public void closeUI()
	{
        GameManager.Instance.activeCharListFlg = false;
		gameObject.SetActive (false);
		scrollContentSetting.deleteAllCharlist ();
	}
}
