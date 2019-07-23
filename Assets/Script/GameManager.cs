using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GameManager : SingletonBase<GameManager> {

    public LeftSideUI leftSideUI;
    public CharListUI charListUI;
    public List<MapObjectClass> mapObjectClass = new List<MapObjectClass>();

    public bool FirstInitFlg = false;

    public bool activeCharListFlg;

    public bool playerTurn;

    public List<CharDataClass> PlayerCharList = new List<CharDataClass>();
    public List<CharDataClass> EnemyCharList = new List<CharDataClass>();

    public string playerMapName;
    public string enemyMapName;

    public List<string> MapRegionData = new List<string>();

    public List<string[]> CurrentBattlePlayers = new List<string[]>();

    // Use this for initialization
    void Start () {
        playerTurn = true;
        activeCharListFlg = false;
    }

    // Update is called once per frame
    void Update () {

    }

    public void regionSetting()
    {
        string strFile= "region.txt";

        using (FileStream fs = new FileStream(strFile, FileMode.Open))
        {
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8, false))
            {
                string strLineValue = null;
                string[] values = null;

                while ((strLineValue = sr.ReadLine()) != null)
                {
                    //Debug.Log (string.Format("values: {0}", strLineValue));
                    // Must not be empty.
                    if (string.IsNullOrEmpty(strLineValue)) return;

                    values = strLineValue.Split(',');

                    for (int i = 0; i < values.Length; i++) 
                    {
                        mapObjectClass[i].playerTeam = values[i];
                        MapRegionData.Add(values[i]);
                        mapObjectClass[i].setRegionColor();
                    }
                }
            }               
        }
    }

    public string GetCurrentMapName(int MapNumber)
    {
        string MapName = "";

        if(MapNumber == 0)
        {
            MapName = "ground";
        }
        else if(MapNumber == 1)
        {
            MapName = "forest";
        }
        else if (MapNumber == 2)
        {
            MapName = "class1";
        }
        else if (MapNumber == 3)
        {
            MapName = "gym";
        }
        else if (MapNumber == 4)
        {
            MapName = "class2";
        }
        else if (MapNumber == 5)
        {
            MapName = "smallground1";
        }
        else if (MapNumber == 6)
        {
            MapName = "lobby";
        }
        else if (MapNumber == 7)
        {
            MapName = "smallground2";
        }

        return MapName;
    }
}
