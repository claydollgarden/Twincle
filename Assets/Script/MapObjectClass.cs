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
        Debug.Log("clicked :");
        if (GameManager.Instance.activeCharListFlg == false)
        {
            GameManager.Instance.charListUI.setUI (mapName);
        }
	}

    public void setRegionColor()
    {
        if (playerTeam == "0")
        {
            
            GetComponent<SpriteRenderer>().color = new Color32(145, 39, 143, 200);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        }
    }
}
