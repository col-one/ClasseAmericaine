using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
	private GameObject panelLoading;

	// Use this for initialization
	void Awake () {
		panelLoading = GameObject.Find("PanelLoading");
	}
	public void ShowScreen () {
		panelLoading.SetActive(true);
	}
}
