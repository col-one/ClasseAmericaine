using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class FixBugTextField : MonoBehaviour {
	private string backUpString = "";
	private InputField input;
	
	void Start (){
		input = GetComponent<InputField> ();
		input.onValueChange.AddListener (OnChangeValue);
	}
	
	void OnDestroy(){
		input.onValueChange.RemoveAllListeners ();
	}
	
	void OnChangeValue (string value){
		if (string.IsNullOrEmpty (value) && backUpString.Length > 1) {
			input.text = backUpString;
			return;
		}
		
		backUpString = value;
	}
}
