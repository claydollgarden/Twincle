using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public List<MapObjectClass> mapObject = new List<MapObjectClass>();
    public CharListUI mapCharListUI;
    public LeftSideUI leftSideUI;

    // Use this for initialization
    void Start () {

        GameManager.Instance.mapObjectClass = mapObject;
        GameManager.Instance.charListUI = mapCharListUI;
        GameManager.Instance.leftSideUI = leftSideUI;

        GameManager.Instance.playerTurn = true;
        GameManager.Instance.activeCharListFlg = false;
        GameManager.Instance.regionSetting();

        Debug.Log("asdasdasd");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
