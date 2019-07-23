using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleReadyUI : MonoBehaviour {

    public GameObject PlayerBG;
    public GameObject EnemyBG;

    public ScrollContentSet PlayerScrollContentSetting;
    public ScrollContentSet EnemyScrollContentSetting;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickedBattleReadyButton()
    {
        setBattleUI();
    }

    public void setBattleUI()
    {
        PlayerBG.SetActive(true);
        EnemyBG.SetActive(true);

        iTween.MoveFrom(PlayerBG, iTween.Hash("x", -960, "time", 0.3));
        iTween.MoveFrom(EnemyBG, iTween.Hash("x", 960, "time", 0.3));

        PlayerScrollContentSetting.BattlePlayerUIPopulate();
        EnemyScrollContentSetting.Populate(GameManager.Instance.enemyMapName);
    }

    public void ClickedBattleReadyCloseButton()
    {
        PlayerBG.SetActive(false);
        EnemyBG.SetActive(false);

        PlayerScrollContentSetting.deleteAllCharlist();
        EnemyScrollContentSetting.deleteAllCharlist();
    }

    public void StartBattleScene()
    {
        SceneManager.LoadScene("BatteScene2");
    }
}
