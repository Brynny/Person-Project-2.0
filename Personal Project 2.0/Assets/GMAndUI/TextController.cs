using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour 
{
	//Texts
	[SerializeField]private Text PlayerExperienceText;
	[SerializeField]private Text PlayerRequiredExperienceText;
	[SerializeField]private Text PlayerLevelText;

	void Update ()
	{
		UpdateExperience ();
	}
		
	void UpdateExperience()
	{
		PlayerRequiredExperienceText.text = "XP Required For Next Level " + GameController._playerExperience + " / " + GameController._playerRequiredExperienceRounded;
		PlayerLevelText.text = "" + GameController._playerLevel;
	} 
}
