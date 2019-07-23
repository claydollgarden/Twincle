using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ScrollContentSet : MonoBehaviour {
	
	public GameObject prefab; // This is our prefab object that will be exposed in the inspector
	public List<GameObject> charlistPrefabs = new List<GameObject>();
	public List<string[]> stayingPlayers = new List<string[]>();
	public List<string> charName = new List<string>();

	public int numberToCreate; // number of objects to create. Exposed in inspector

	void Start()
	{
		nameDataSetting ();
	}

	void Update()
	{

	}

	public void Populate(string mapName)
	{
		PlayerDataSetting (mapName);

		GameObject newObj; // Create GameObject instance

		for (int i = 0; i < stayingPlayers.Count; i++)
		{
			newObj = (GameObject)Instantiate(prefab, transform);
			var charManager = newObj.GetComponent<CharDataClass>();
			charManager.Init(stayingPlayers[i], checkName(stayingPlayers[i][0]));
			charlistPrefabs.Add (newObj);
		}

	}

    public void BattlePlayerUIPopulate()
    {
        AllPlayerDataSetting();

        GameObject newObj; // Create GameObject instance

        GameManager.Instance.CurrentBattlePlayers = stayingPlayers;

        for (int i = 0; i < stayingPlayers.Count; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            var charManager = newObj.GetComponent<CharDataClass>();
            charManager.Init(stayingPlayers[i], checkName(stayingPlayers[i][0]));
            charlistPrefabs.Add(newObj);
        }
    }

    public void BattleScenePopulate()
    {
        GameObject newObj; // Create GameObject instance

        for (int i = 0; i < GameManager.Instance.CurrentBattlePlayers.Count; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            var charManager = newObj.GetComponent<CharDataClass>();
            charManager.Init(GameManager.Instance.CurrentBattlePlayers[i], checkName(GameManager.Instance.CurrentBattlePlayers[i][0]));
            charlistPrefabs.Add(newObj);
        }
    }


    public void deleteAllCharlist()
	{
		for (int i = 0; i < charlistPrefabs.Count; i++)
		{
			Destroy (charlistPrefabs [i]);
		}
        stayingPlayers.Clear();
		charlistPrefabs.Clear ();
	}

	void PlayerDataSetting(string mapName)
	{
		string strFile= mapName + ".txt";

		using (FileStream fs = new FileStream(strFile, FileMode.Open))
		{
			using (StreamReader sr = new StreamReader(fs, Encoding.UTF8, false))
			{
				string strLineValue = null;
				string[] values = null;
				int lineCount = 0;

				while ((strLineValue = sr.ReadLine()) != null)
				{
					//Debug.Log (string.Format("values: {0}", strLineValue));
					// Must not be empty.
					if (string.IsNullOrEmpty(strLineValue)) return;

					values = strLineValue.Split(',');

					stayingPlayers.Add (values);

					lineCount++;
				}
			}               
		}
	}

    void AllPlayerDataSetting()
    {
        for(int i = 0; i < GameManager.Instance.MapRegionData.Count; i++)
        {
            if(GameManager.Instance.MapRegionData[i] == "0")
            {
                PlayerDataSetting(GameManager.Instance.GetCurrentMapName(i));
            }
        }
    }


    void nameDataSetting()
	{
		string strFile= "name.txt";

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
						charName.Add (values[i]);
					}
				}
			}               
		}
	}

	int checkName(string name)
	{
		for (int i = 0; i < charName.Count; i++) 
		{
			if (name == charName [i]) 
			{
				return i;
			}
		}
		return 0;
	}
}
