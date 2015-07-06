using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class ValideReplique : MonoBehaviour {

	private GameObject audioSource;
	public string bonneReponse;
	private string reponse;
	private GameObject panelAnswer;

	public void Awake()
	{
		audioSource = GameObject.Find("Audio Source");
		panelAnswer = GameObject.Find("PanelReponse");
		panelAnswer.SetActive(false);
	}

	public void ValidateRep () 
	{
		reponse = GameObject.Find("Reponse").transform.FindChild("Text").GetComponent<Text>().text;
		reponse = RemoveDiacriticsAndCap(reponse);
		if (reponse == bonneReponse)
		{
			panelAnswer.SetActive(true);
			audioSource.GetComponent<AudioSource>().PlayDelayed(3);
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
