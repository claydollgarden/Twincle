using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public MainUI mainUI;
	public TargetUI targetUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setMainUI(bool flg)
	{
		mainUI.setUI (flg);
	}

	public void MainUIReset()
	{
		mainUI.ResetFlg();
	}

	public void setTargetUI(bool flg)
	{
		targetUI.setUI (flg);
	}
}
