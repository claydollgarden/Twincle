using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //Debug.Log("clicked :");
        //if (GameManager.Instance.activeCharListFlg == false)
        //{
        //    GameManager.Instance.charListUI.setUI (mapName);
        //}
	}

    public void ClickedSetUI()
    {
        Debug.Log("clicked :");
        if (GameManager.Instance.activeCharListFlg == false)
        {
            GameManager.Instance.charListUI.setUI(mapName);
            GameManager.Instance.leftSideUI.setUI(playerTeam);

            if(playerTeam == "1")
            {
                GameManager.Instance.enemyMapName = mapName;
            }
        }
    }

    public void setRegionColor()
    {
        if (playerTeam == "0")
        {
            this.GetComponent<Image>().color = new Color(0.0f, 0.0f, 1.0f, 0.5f);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        }
    }
}
