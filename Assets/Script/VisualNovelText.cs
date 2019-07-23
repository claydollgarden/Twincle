using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TMPro;

public class VisualNovelText : MonoBehaviour {

	//[Range(0, 100)]
	//public int RevealSpeed = 50;
	public List<string[]> charName = new List<string[]>();

	//대사, 화면에뜰 사람수, 포커스중인 사람, 왼쪽사람번호, 왼쪽사람 스프라이트 번호, 오른쪽사람번호, 오른쪽사람 스프라이트 번호, 화면효과
	public List<string[]> scenarioText = new List<string[]>();

	//public TMP_Text m_textMeshPro;
    public Text novelText;
    public Text nameText;

	public int scriptLine = 0;

	public StandingCgManager standingCgManager;

	void Awake()
	{
		ScenarioDataSetting ();

		// Get Reference to TextMeshPro Component
		//m_textMeshPro = GetComponent<TMP_Text>();
		//m_textMeshPro.text = " ";
		//m_textMeshPro.enableWordWrapping = true;

		nameText.text = " ";

		//if (GetComponentInParent(typeof(Canvas)) as Canvas == null)
		//{
		//    GameObject canvas = new GameObject("Canvas", typeof(Canvas));
		//    gameObject.transform.SetParent(canvas.transform);
		//    canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

		//    // Set RectTransform Size
		//    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
		//    m_textMeshPro.fontSize = 48;
		//}


	}


	void Start()
	{
        //m_textMeshPro.text = scenarioText[scriptLine][0];
        novelText.text = scenarioText[scriptLine][0];
        standingCgManager.changeFocus (scenarioText [scriptLine] [2]);
		SetNameText ();

		//StartCoroutine("StartText");
	}

	void Update()
	{
		if (Input.GetKeyUp("s")) {
			scriptLine++;

			SetCharSprites ();
			SetNameText ();

			//m_textMeshPro.text = scenarioText[scriptLine][0];

            SetNovelText();
			//StartCoroutine("StartText");
		}
	}

	//IEnumerator StartText()
	//{

	//	// Force and update of the mesh to get valid information.
	//	m_textMeshPro.ForceMeshUpdate();


	//	int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
	//	int counter = 0;
	//	int visibleCount = 0;

	//	while (counter <= totalVisibleCharacters)
	//	{
	//		visibleCount = counter % (totalVisibleCharacters + 1);

	//		m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

	//		counter += 1;

	//		yield return new WaitForSeconds(0.01f);
	//	}

	//	//Debug.Log("Done revealing the text.");
	//}

    void SetNovelText()
    {
        novelText.text = scenarioText[scriptLine][0];
    }


    void SetCharSprites()
	{
		if (scenarioText [scriptLine] [2] != scenarioText [scriptLine - 1] [2]) 
		{
			standingCgManager.changeFocus (scenarioText [scriptLine] [2]);
		}

		if (scenarioText [scriptLine] [3] != scenarioText [scriptLine - 1] [3] ||
			scenarioText [scriptLine] [4] != scenarioText [scriptLine - 1] [4]) 
		{
			standingCgManager.setCharSprite (scenarioText [scriptLine] [3], int.Parse (scenarioText [scriptLine] [4]), false);
			Debug.Log ("scenarioText [scriptLine] [4] : " + scenarioText [scriptLine] [4]);
		}

		if (scenarioText [scriptLine] [5] != scenarioText [scriptLine - 1] [5] || 
			scenarioText [scriptLine] [6] != scenarioText [scriptLine - 1] [6]) 
		{
			standingCgManager.setCharSprite (scenarioText [scriptLine] [5], int.Parse (scenarioText [scriptLine] [6]), true);
			Debug.Log ("scenarioText [scriptLine] [6] : " + scenarioText [scriptLine] [6]);
		}
	}

	void SetNameText()
	{
		if (scenarioText [scriptLine] [2] == "0") 
		{
			nameText.text = charName [0][int.Parse (scenarioText [scriptLine] [3])];
		} 
		else 
		{
			nameText.text = charName [0][int.Parse (scenarioText [scriptLine] [5])];
		}
	}

	void ScenarioDataSetting()
	{
		string strFile= "scene1.txt";

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

					if (lineCount == 0) 
					{
						charName.Add (values);
					}
					else 
					{
						scenarioText.Add (values);
					}

					lineCount++;
				}
			}               
		}
	}
}
