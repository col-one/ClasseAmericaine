using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using UnityEngine.UI;

public class CreateScenes 
{
	const string pathAssetRef = "Assets/AutoProto";

	[MenuItem("Tools/Create Scenes")]
	public static void MyMenuItem()
	{
		//parser le fichier xml
		TextAsset data = Resources.Load("repliquesData") as TextAsset;
		List<Dictionary<string,string>> repliques = new List<Dictionary<string,string>>();


		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(data.text);
		XmlNodeList repliquesList = xmlDoc.GetElementsByTagName("replique");
		foreach(XmlNode repliqueInfo in repliquesList)
		{
			Dictionary<string,string> repliqueAttr = new Dictionary<string,string>();
			repliqueAttr.Add("propo",repliqueInfo.Attributes["proposition"].Value);
			XmlNodeList repliquesContentList = repliqueInfo.ChildNodes;
			foreach(XmlNode repliqueContent in repliquesContentList)
			{
				repliqueAttr.Add(repliqueContent.Name,repliqueContent.InnerText);
			}
			repliques.Add(repliqueAttr);
		}



		//cloner une scn celon le type par repliques presentent dans le xml
		foreach(Dictionary<string,string> replique in repliques)
		{
			string name = replique["nom"];
			//AssetDatabase.CreateFolder(pathAssetRef, name);
			if(replique["propo"] == "false")
			{
				AssetDatabase.CopyAsset(pathAssetRef+"/saisieScnSq.unity", pathAssetRef+"/"+name+".unity");
				EditorApplication.OpenScene(pathAssetRef+"/"+name+".unity");

				//assigner la replique au text replique
				GameObject.Find("Replique").GetComponent<Text>().text = replique["textReplique"];
				//assigner la reponse au script dans camera
				Camera.main.GetComponent<ValideReplique>().bonneReponse = replique["reponse"];
				Camera.main.GetComponent<ValideReplique>().isPropo = false;
				//assigner la photo
				Sprite photo = (Sprite) AssetDatabase.LoadAssetAtPath(pathAssetRef+"/Photos/"+replique["photo"]+".jpg", typeof(Sprite));
				GameObject.Find("PhotoIndice").GetComponent<Image>().sprite = photo;
				//assigner le son
				AudioClip son = (AudioClip) AssetDatabase.LoadAssetAtPath(pathAssetRef+"/Sons/"+replique["son"]+".mp3", typeof(AudioClip));
				GameObject.Find("Audio Source").GetComponent<AudioSource>().clip = son;
			
				//save scene
				EditorApplication.SaveScene(pathAssetRef+"/"+name+".unity");
			}

			if(replique["propo"] == "true")
			{
				AssetDatabase.CopyAsset(pathAssetRef+"/propoScnSq.unity", pathAssetRef+"/"+name+".unity");
				EditorApplication.OpenScene(pathAssetRef+"/"+name+".unity");
				//assigner la replique au text replique
				GameObject.Find("Replique").GetComponent<Text>().text = replique["textReplique"];
				//assigner la reponse au script dans camera
				Camera.main.GetComponent<ValideReplique>().bonneReponse = replique["reponse"];
				Camera.main.GetComponent<ValideReplique>().isPropo = false;
				//assigner la photo
				Sprite photo = (Sprite) AssetDatabase.LoadAssetAtPath(pathAssetRef+"/Photos/"+replique["photo"]+".jpg", typeof(Sprite));
				GameObject.Find("PhotoIndice").GetComponent<Image>().sprite = photo;
				//assigner le son
				AudioClip son = (AudioClip) AssetDatabase.LoadAssetAtPath(pathAssetRef+"/Sons/"+replique["son"]+".mp3", typeof(AudioClip));
				GameObject.Find("Audio Source").GetComponent<AudioSource>().clip = son;
				//assigner propo
				GameObject.Find("Propo1").transform.FindChild("Text").GetComponent<Text>().text = replique["proposition1"];
				GameObject.Find("Propo2").transform.FindChild("Text").GetComponent<Text>().text = replique["proposition2"];
				GameObject.Find("Propo3").transform.FindChild("Text").GetComponent<Text>().text = replique["proposition3"];
				GameObject.Find("Propo4").transform.FindChild("Text").GetComponent<Text>().text = replique["proposition4"];

				//save scene
				EditorApplication.SaveScene(pathAssetRef+"/"+name+".unity");
			}
		}
	}
}
