using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	private SceneManager scnMana;

	void Start()
	{
		scnMana = GameObject.Find("SceneManager").GetComponent<SceneManager>();

	}
	public void NextScn()
	{
		scnMana.GoNextLevel();
	}
	public void GoToScn(string scn)
	{
		scnMana.LoadLevelByName(scn);
	}
}
