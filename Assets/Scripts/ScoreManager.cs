using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

  public bool debug = false;
  private Text scoreLabel = null;

  private int score = 0;

  private void Awake() {
    if(scoreLabel == null) {
      scoreLabel = GameObject.Find("ScoreValue").GetComponent<Text>();
    }
    
    if (debug) Debug.Log("ScoreLabel found: " + (scoreLabel != null));
  }

  public void IncreaseScore(int s) {
    score += s;
    UpdateScore();
    if (debug) Debug.Log("Score: " + score);
  }

  private void UpdateScore() {
    scoreLabel.text = score.ToString();
  }
}
