using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectClass : MonoBehaviour {
	public string mapName;
    public string playerTeam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseOver()
	{

	}

	void OnMouseUp()
	{
		Debug.Log ("Clicked Object");
		MapManager.instance.charListUI.setUI (true,mapName);
	}
}
