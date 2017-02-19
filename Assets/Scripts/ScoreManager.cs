using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

  public Text scoreLabel;
  private int score = 0;

  private void Awake() {
    if(scoreLabel == null) {
      scoreLabel = GameObject.Find("ScoreValue").GetComponent<Text>();
    }
  }

  public void IncreaseScore(int s) {
    score += s;
    UpdateScore();
  }

  private void UpdateScore() {
    scoreLabel.text = score.ToString();
  }
}
