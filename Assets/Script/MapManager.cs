using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class MapManager : MonoBehaviour {

    public List<MapObjectClass> mapObject = new List<MapObjectClass>();
    public CharListUI mapCharListUI;

	// Use this for initialization
	void Start () {
        GameManager.Instance.mapObjectClass = mapObject;
        GameManager.Instance.charListUI = mapCharListUI;

        GameManager.Instance.playerTurn = true;
        GameManager.Instance.activeCharListFlg = false;
        GameManager.Instance.regionSetting();

        Debug.Log("asdasdasd");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
