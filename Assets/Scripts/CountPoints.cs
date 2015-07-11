using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountPoints : MonoBehaviour {

	public int count = 0;
	public Text compteur;

	// Use this for initialization
	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	void Start()
	{
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
