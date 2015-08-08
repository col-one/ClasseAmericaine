using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountPoints : MonoBehaviour {

	public int count = 0;
	public Text compteur;

	//property membre varaible
	public static CountPoints instance = null;
	
	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			Destroy(gameObject);    
		
		DontDestroyOnLoad(gameObject);
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
