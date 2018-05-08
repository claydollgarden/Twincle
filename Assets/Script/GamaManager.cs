using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GamaManager : MonoBehaviour {
	public static GamaManager instance;

	public GameObject UserPlayerPrefab;

	public UIManager UiManager;

	public int[] PlayablePlayers = new int[] {0,2,3,1,7,4,8,6,5,9};

	public List<CharManager> players = new List<CharManager>();
	public List<string[]> allPlayers = new List<string[]>();

	public CharManager targetChar;
	public CharManager currentChar;

	public EffectManager effectManager;

	public CutinManager cutinManager;

	public bool movigFlg;
	public bool atkSequenceFlg;

	private Touch tempTouchs;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		atkSequenceFlg = false;
		movigFlg = true;
		PlayerDataSetting ();
		PlayerSetting ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!movigFlg && UiManager.mainUI.isActiveAndEnabled == false && atkSequenceFlg ==false) 
		{
			UiManager.setMainUI (true);
		}

		if (Input.GetMouseButtonDown (0)) 
		{
			if (UiManager.targetUI.isActiveAndEnabled && !movigFlg && UiManager.mainUI.atkFlg) 
			{
				atkSequenceFlg = true;
				UiManager.MainUIReset();
				UiManager.setMainUI (false);
				UiManager.setTargetUI (false);
				cutinManager.StartCutin2 ();
			}
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
//			if (targetChar != null && !movigFlg && mainUI.atkFlg) 
//			{
//				mainUI.ResetFlg();
//				mainUI.setUI (false);
//				AttackSequence ();
//			}
		}
	}

	void PlayerSetting()
	{
		for (int i = 0; i < PlayablePlayers.Length; i++) 
		{
			GameObject charObj = GameObject.Instantiate(UserPlayerPrefab,new Vector3(5 + Random.Range(-6, 7), -9.0f + (i * 2), 0), Quaternion.Euler(new Vector3())) as GameObject;
			var charManager = charObj.GetComponent<CharManager>();
			charManager.Init(allPlayers[PlayablePlayers[i]]);
		}
	}

	public void PlayEffectSequence()
	{
		effectManager.startEffect (2, targetChar, 0);
	}

	public void AttackSequence()
	{
		targetChar.transform.position = new Vector3 (targetChar.transform.position.x + currentChar.Attack, targetChar.transform.position.y, targetChar.transform.position.z);
		currentChar.transform.position = new Vector3 (currentChar.transform.position.x + 5, currentChar.transform.position.y, currentChar.transform.position.z);
		movigFlg = true;
		atkSequenceFlg = false;
	}

	void PlayerDataSetting()
	{
		string strFile= "CharData.txt";

		using (FileStream fs = new FileStream(strFile, FileMode.Open))
		{
			using (StreamReader sr = new StreamReader(fs, Encoding.UTF8, false))
			{
				string strLineValue = null;
				string[] keys = null;
				string[] values = null;
				int lineCount = 0;

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

					allPlayers.Add (values);

					lineCount++;
				}
			}               
		}
	}
}