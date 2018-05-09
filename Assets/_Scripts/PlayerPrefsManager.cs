using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	public const string MASTER_VOLUME = "master_volume";
	public const string DIFF_KEY = "difficulty"; 
	public const string LEVEL_KEY = "level_unlocked_";



	public static void SetMasterVolume (float Volume) {
		if (Volume >= 0.0f && Volume <= 1.0f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME, Volume);
		} else {
			Debug.LogError ("Prefs Manager Error - cannot set Volume to " + Volume);
		}
	}



	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME);
	}



	public static void SetUnlockLevel (int levelToUnlock){
		if (levelToUnlock < SceneManager.sceneCountInBuildSettings) {
			PlayerPrefs.SetInt (string.Concat(LEVEL_KEY+levelToUnlock), 1);
		} else {
			Debug.LogError ("Level" + levelToUnlock + " cannot be unlocked as it does not exist.");
		}
	}



	public static bool GetLevelUnockedStatus (int levelToUnlock){
		string levelUnlockKey = string.Concat (LEVEL_KEY + levelToUnlock);
		if (PlayerPrefs.HasKey (levelUnlockKey)) {
			Debug.Log ("Level " + levelToUnlock + " is unlocked");
			return true;
		} else {
			Debug.Log ("Level " + levelToUnlock + " is locked");
			return false;
		}
	}



	public static void GetAllUnlockedStatus (){
		for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
			print ("Level " + i + " is unlocked  - " + GetLevelUnockedStatus (i));
		}
	}


	public static void SetDifficulty (float diffRating){
		if (diffRating >= 0f && diffRating <= 4f) {
			PlayerPrefs.SetFloat (DIFF_KEY, diffRating);
		} else {
			Debug.LogError ("Cannot set difficulty rating below zero or over 1, trying to set it to " + diffRating);
		}
	}


	public static float GetDifficulty (){
		return PlayerPrefs.GetFloat (DIFF_KEY);
	}

	public static void readAllValues(){
	
		Debug.Log ("Volume" + GetMasterVolume());
		Debug.Log ("Difficulty " + GetDifficulty());
		Debug.Log ("Level Status:-");
		GetAllUnlockedStatus ();
	}

	public static bool doesKeyExist (string keyToCheck){
		
		print ("Does " + keyToCheck + " exist? " + PlayerPrefsManager.doesKeyExist (keyToCheck));

		return (PlayerPrefs.HasKey (keyToCheck));
	}


}
