using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountPoints : MonoBehaviour {

	public int count = 0;
	private Text compteur;

	// Use this for initialization
	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	void Start()
	{
		compteur = GameObject.Find("Compteur").GetComponent<Text>();
	}
	void Update()
	{
		if(count < 0)
		{
			count = 0;
		}
		compteur.text = (string)count.ToString();
	}
}
