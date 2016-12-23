using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MemoryManager : MonoBehaviour {

    public int NumPairs;
    public Color DefaultColor;
    public ChangeColor Bloc1;
    public ChangeColor Bloc2;
    public bool IsWaiting;
    public Text TextLabel;
    public Text TimerLabel;
    public float Timer;
    public Spawner Spawn;
    private int Score;

	// Use this for initialization
	void Start () {
	   IsWaiting = false;
       NumPairs = Spawn.NumPairs;
       TextLabel.text = NumPairs.ToString();
       TimerLabel.text = Timer.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	   TimerCheck();
	}

    void TimerCheck () {
        if (Timer <= 0.0f) {
            SceneManager.LoadScene("GameOver");
        } else {
            Timer -= Time.deltaTime;
            TimerLabel.text = Mathf.Ceil(Timer).ToString();
        }
    }

    IEnumerator Delay(float amount) {
        yield return new WaitForSeconds(amount);
        IsWaiting = false;
        Compare();
    }

    public void CubeClicked(ChangeColor Bloc) {
        if (Bloc1 == null) {
            Bloc1 = Bloc;
        } else if (Bloc != Bloc1) {
            Bloc2 = Bloc;
            IsWaiting = true;
            StartCoroutine(Delay(0.5f));
        }
    }

    void Compare() {
        if (Bloc1.TrueColor == Bloc2.TrueColor) {
            Bloc1.Anim.SetBool("Destroy", true);
            Bloc2.Anim.SetBool("Destroy", true);
            Destroy(Bloc1.gameObject, 0.5f);
            Destroy(Bloc2.gameObject, 0.5f);
            NumPairs --;
            TextLabel.text = NumPairs.ToString();
            Score += 2;
            if (NumPairs == 0) {
                Score += (int)Mathf.Ceil(Timer);
                if (!PlayerPrefs.HasKey("HighScore")) {
                    PlayerPrefs.SetInt("HighScore", Score);
                }
                else if (Score > PlayerPrefs.GetInt("HighScore")) {
                    PlayerPrefs.SetInt("HighScore", Score);
                }
                PlayerPrefs.SetInt("Score", Score);
                SceneManager.LoadScene("Victory");
            }
        } else {
            Bloc1.SetColor(DefaultColor);
            Bloc2.SetColor(DefaultColor);
            Score -= 1;
        }
        Bloc1.Anim.SetBool("Selected", false);
        Bloc2.Anim.SetBool("Selected", false);
        Bloc1 = null;
        Bloc2 = null;
    }
}
