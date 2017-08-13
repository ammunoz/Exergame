using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
  public bool debug = false;
  private int score = 0;
  private Text scoreLabel = null;

  private void Awake()
  {
    scoreLabel = GameObject.Find("ScoreValue").GetComponent<Text>();
    scoreLabel.text = score.ToString();
    if (debug) Debug.Log("ScoreLabel found: " + (scoreLabel != null));
  }

  public int Score
  {
    get { return score; }
  }

  public void IncreaseScore(int s)
  {
    score += s;
    scoreLabel.text = score.ToString();
    if (debug) Debug.Log("Score: " + score);
  }
}
