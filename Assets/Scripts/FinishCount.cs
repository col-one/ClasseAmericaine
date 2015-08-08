using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishCount : MonoBehaviour {

	private CountPoints countScript;
	void Start()
	{
		countScript.compteur = GameObject.Find("Compteur").GetComponent<Text>();
	}
	public void Awake()
	{
		countScript = GameObject.Find("CountObject").GetComponent<CountPoints>();
	}

}
