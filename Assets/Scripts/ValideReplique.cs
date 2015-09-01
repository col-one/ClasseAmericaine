/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */ 
 



using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using UnityEngine.EventSystems;

public class ValideReplique : MonoBehaviour {

	public bool isPropo;
	private CountPoints countScript;
	private GameObject audioSource;
	public string bonneReponse;
	private string reponse;
	private GameObject panelAnswer;
	private GameObject panelLoading;
	private GameObject reponseText;
	private GameObject imageSon;
	private GameObject votreReponse;
	private bool isPlay = false;
	private bool isAnswer = false;
	private string repToDisplay;
	private int pointToAdd;
	private Color colorToPut;
	private GameObject eventSystemText;
	private GameObject buttonSuivant;
	private GameObject check;
	private GameObject uncheck;
	private bool asGood;

	public void Update()
	{
		DisplayAnswer(repToDisplay, pointToAdd, colorToPut);
	}

	void Start()
	{
		countScript.compteur = GameObject.Find("Compteur").GetComponent<Text>();
	}

	public void Awake()
	{
		countScript = GameObject.Find("CountObject").GetComponent<CountPoints>();
		audioSource = GameObject.Find("Audio Source");
		panelAnswer = GameObject.Find("PanelReponse");
		panelLoading = GameObject.Find("PanelLoading");
		//reponseText = GameObject.Find("Reponse");
		imageSon = GameObject.Find("ImageSon");
		votreReponse = GameObject.Find("VotreReponse");
		buttonSuivant = GameObject.Find("Suivante");
		check = GameObject.Find("Check");
		uncheck = GameObject.Find ("Uncheck");
		check.SetActive(false);
		uncheck.SetActive(false);
		panelAnswer.SetActive(false);
		panelLoading.SetActive(false);
	}

	public void ValidateRep () 
	{
		buttonSuivant.GetComponent<Button>().interactable = false;
		if(isPropo)
		{
			reponse = GameObject.Find("EventSystem").GetComponent<EventSystem>().currentSelectedGameObject.transform.FindChild("Text").GetComponent<Text>().text;
		}
		else
		{
			reponse = GameObject.Find("ReponseChamps").transform.FindChild("Text").GetComponent<Text>().text;
		}
		reponse = RemoveDiacriticsAndCap(reponse);
		if (reponse == bonneReponse)
		{
			votreReponse.GetComponent<Text>().text = reponse;
			panelAnswer.SetActive(true);
			imageSon.SetActive(true);
			audioSource.GetComponent<AudioSource>().PlayDelayed(2);
			repToDisplay = bonneReponse;
			asGood = true;
			if(isPropo)
			{
				pointToAdd = 2;
			}
			else
			{
				pointToAdd = 3;
			}
			isAnswer = true;
		}

		else
		{
			votreReponse.GetComponent<Text>().text = reponse;
			panelAnswer.SetActive(true);
			imageSon.SetActive(true);
			audioSource.GetComponent<AudioSource>().PlayDelayed(2);
			repToDisplay = bonneReponse;
			asGood = false;
			pointToAdd = -1;
			isAnswer = true;

		}
	}

	public void StopAllSound()
	{

	}

	public void ReListen()
	{
		audioSource.GetComponent<AudioSource>().PlayDelayed(1);
	}

	public void DisplayAnswer(string repToDiplay, int pointToAdd, Color colorToPut)
	{
		isPlay = audioSource.GetComponent<AudioSource>().isPlaying;
		if(!isPlay && isAnswer)
		{
			imageSon.SetActive(false);
			//reponseText.GetComponent<Text>().text = repToDiplay;
			countScript.count += pointToAdd;
			//votreReponse.GetComponent<Text>().color = colorToPut;
			check.SetActive(asGood);
			uncheck.SetActive(!asGood);
			buttonSuivant.GetComponent<Button>().interactable = true;
			isAnswer = false;
		}
	}
	
	public string RemoveDiacriticsAndCap(string input)
	{
		string stFormD = input.Normalize(NormalizationForm.FormD);
		int len = stFormD.Length;
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < len; i++)
		{
			System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
			if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
			{
				sb.Append(stFormD[i]);
			}
		}
		return (sb.ToString().Normalize(NormalizationForm.FormC)).ToLower();
	}
}
