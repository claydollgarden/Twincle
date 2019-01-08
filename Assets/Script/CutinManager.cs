    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutinManager : MonoBehaviour {
	public GameObject[] CuinObjects;

	// Use this for initialization
	void Start () {
		setCutinActive (false);
	}

	// Update is called once per frame
	void Update () {
	}

	public void StartCutin()
	{
		for (int i = 0; i < 4; i++) 
		{
			CuinObjects [i].SetActive (true);
		}

		CuinObjects[0].SetActive (true);
		CuinObjects[1].SetActive (true);
		CuinObjects[2].SetActive (true);
		CuinObjects[3].SetActive (true);

		iTween.MoveFrom(CuinObjects[0],iTween.Hash("x",-500,"time",0.6,"delay",1.0));

		iTween.MoveFrom(CuinObjects[1],iTween.Hash("y",380,"time",0.6,"delay",1.2));
		iTween.MoveFrom(CuinObjects[2],iTween.Hash("y",380,"time",0.6,"delay",1.3));
		iTween.MoveFrom(CuinObjects[3],iTween.Hash("y",380,"time",0.6,"delay",1.4,"oncomplete", "EndCutin","oncompletetarget",gameObject));
                        
	}

	public void EndCutin()
	{
		for (int i = 0; i < 4; i++) 
		{
			CuinObjects [i].SetActive (false);
		}

		GamaManager.instance.PlayEffectSequence ();
		Debug.Log("EndCutin");
	}

	public void StartCutin2()
	{
		for (int i = 4; i < 11; i++) 
		{
			CuinObjects [i].SetActive (true);
		}

		iTween.MoveFrom(CuinObjects[4],iTween.Hash("x",955,"time",0.3));

		iTween.MoveFrom(CuinObjects[5],iTween.Hash("x",-860,"y",-405,"time",0.4,"delay",0.5,"easeType",iTween.EaseType.easeInOutCubic));
		iTween.MoveFrom(CuinObjects[6],iTween.Hash("x",-270,"y",570,"time",0.4,"delay",0.5,"easeType",iTween.EaseType.easeInOutCubic));
		iTween.MoveFrom(CuinObjects[7],iTween.Hash("x",-370,"y",400,"time",1.0,"delay",1.2,"easeType",iTween.EaseType.easeInOutCubic));
		iTween.MoveFrom(CuinObjects[8],iTween.Hash("x",492,"y",445,"time",1.0,"delay",1.3,"easeType",iTween.EaseType.easeInOutCubic));
		iTween.MoveFrom(CuinObjects[9],iTween.Hash("x",401,"y",-448,"time",1.0,"delay",1.4,"easeType",iTween.EaseType.easeInOutCubic));
		iTween.MoveFrom(CuinObjects[10],iTween.Hash("x",-442,"y",-378,"time",1.2,"delay",1.5,"easeType",iTween.EaseType.easeInOutCubic, "oncomplete","EndCutin2","oncompletetarget",gameObject));

	}

	public void EndCutin2()
	{
		for (int i = 4; i < 11; i++) 
		{
			CuinObjects [i].SetActive (false);
		}

		GamaManager.instance.PlayEffectSequence ();
	}

	void setCutinActive(bool flg)
	{
		for (int i = 0; i < CuinObjects.Length; i++) 
		{
			CuinObjects [i].SetActive (flg);
		}
	}
}
