using UnityEngine;
using System.Collections;

public class GameManager: MonoBehaviour {

  public static GameManager instance = null;
  private ScoreManager scoreManager = null;
  private BubbleManager bubbleManager = null;

	private void Awake () {
    if (instance == null)
      instance = this;
    else if (instance != this)
      Destroy(gameObject);
    DontDestroyOnLoad(gameObject);

    if(scoreManager == null) {
      scoreManager = gameObject.GetComponent<ScoreManager>();
    }

    if(bubbleManager == null) {
      bubbleManager = gameObject.GetComponent<BubbleManager>();
    }
	}

  public void IncreaseScore(int s) {
    scoreManager.IncreaseScore(s);
  }
}
