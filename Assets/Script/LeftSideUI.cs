using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftSideUI : MonoBehaviour {

    public List<Button> PlayerMapButton = new List<Button>();
    public List<Button> EnemyMapButton = new List<Button>();

    public GameObject PlayerMapObject;
    public GameObject EnemyMapObject;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setUI(string teamStatus)
    {
        if (teamStatus == "0")
        {
            PlayerMapObject.SetActive(true);
            EnemyMapObject.SetActive(false);
        }
        else
        {
            PlayerMapObject.SetActive(false);
            EnemyMapObject.SetActive(true);
        }

        gameObject.SetActive(true);
        iTween.MoveFrom(gameObject, iTween.Hash("x", -1000, "time", 0.3));

    }

    public void closeUI()
    {
        gameObject.SetActive(false);
    }
}
