using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {
    public List<BattleCharData> battleCharDataList = new List<BattleCharData>();

    public ScrollContentSet BattlePlayerScrollContentSetting;

    // Use this for initialization
    void Start () {
        BattlePlayerScrollContentSetting.BattleScenePopulate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BattleExit()
    {
        SceneManager.LoadScene("IZONEScene");
    }
}
