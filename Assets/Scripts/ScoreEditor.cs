using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreEditor : MonoBehaviour {

    public Text Score;
    public Text HighScore;

	// Use this for initialization
	void Start () {
       Score.text = PlayerPrefs.GetInt("Score").ToString();
	   HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
