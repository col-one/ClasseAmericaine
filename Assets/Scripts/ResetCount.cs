using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetCount : MonoBehaviour {

	private CountPoints countScript;

	void Start()
	{
		countScript.count = 0;
		countScript.compteur = GameObject.Find("Compteur").GetComponent<Text>();
	}
	public void Awake()
	{
		countScript = GameObject.Find("CountObject").GetComponent<CountPoints>();
	}

}
