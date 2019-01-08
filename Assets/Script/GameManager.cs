using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GameManager : SingletonBase<GameManager> {
    
    public CharListUI charListUI;
    public List<MapObjectClass> mapObjectClass = new List<MapObjectClass>();

    public bool activeCharListFlg;

    public bool playerTurn;

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
                string[] keys = null;
                string[] values = null;

                while ((strLineValue = sr.ReadLine()) != null)
                {
                    //Debug.Log (string.Format("values: {0}", strLineValue));
                    // Must not be empty.
                    if (string.IsNullOrEmpty(strLineValue)) return;

                    if (strLineValue.Substring(0, 1).Equals("#"))
                    {
                        keys = strLineValue.Split(',');

                        keys[0] = keys[0].Replace("#", "");

                        continue;
                    }

                    values = strLineValue.Split(',');

                    for (int i = 0; i < values.Length; i++) 
                    {
                        mapObjectClass[i].playerTeam = values[i];
                        mapObjectClass[i].setRegionColor();
                    }
                }
            }               
        }
    }
}
