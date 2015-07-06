using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class ValideReplique : MonoBehaviour {

	public string bonneReponse;
	private string reponse;

	public void ValidateRep () 
	{
		reponse = GameObject.Find("Reponse").transform.FindChild("Text").GetComponent<Text>().text;
		Debug.Log(reponse);
		reponse = RemoveDiacriticsAndCap(reponse);
		Debug.Log(reponse);
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
