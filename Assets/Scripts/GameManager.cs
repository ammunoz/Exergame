using UnityEngine;
using System.Collections;

public class GameManager: MonoBehaviour {

  public static GameManager instance = null;
  private ScoreManager scoreManager = null;
  private BubbleManager bubbleManager = null;
  private GameMenu gameMenu = null;

  // Screen values
  public const float xMin = -8;
  public const float xMax = 8;
  public const float yMin = -3.5f;
  public const float yMax = 5.5f;

  // Pop values
  private int popValue = 1;
  private int popCountDownRate = 3;
  private int popCountDownBonus = 2;

  // Bubble values
  private int bubbleValue = 1;

  // Swish values
  private int swishValue = 2;
  private int swishRadiusMin = 1;
  private int swishRadiusMax = 5;
  private float swishRotateSpeed = 1f;

  // Slide values
  private int slideValue = 2;
  private float slideMoveSpeedMin = 0.05f;
  private float slideMoveSpeedMax = 0.20f;

  // Time Attack value
  private int timeLimit = 60;

  // Lose
  private bool lost = false;

  private void Awake () {
    if (instance == null) {
      instance = this;
    }
    else if (instance != this) {
      Destroy(gameObject);
    }

    if(scoreManager == null) {
      scoreManager = gameObject.GetComponent<ScoreManager>();
    }

    if(bubbleManager == null) {
      bubbleManager = gameObject.GetComponent<BubbleManager>();
    }

    if(gameMenu == null) {
      gameMenu = gameObject.GetComponent<GameMenu>();
    }

    lost = false;

    // DontDestroyOnLoad(gameObject);
  }

  public void IncreaseScore(int s) {
    scoreManager.IncreaseScore(s);
  }

  public int PopValue {
    get { return popValue; }
  }

  public int PopCountDownRate {
    get { return popCountDownRate; }
  }

  public int PopCountDownBonus {
    get { return popCountDownBonus; }
  }

  public int BubbleValue {
    get { return bubbleValue; }
  }

  public int SwishValue {
    get { return swishValue; }
  }

  public int SwishRadiusMin {
    get { return swishRadiusMin; }
  }

  public int SwishRadiusMax {
    get { return swishRadiusMax; }
  }

  public float SwishRotateSpeed {
    get { return swishRotateSpeed; }
  }

  public int SlideValue {
    get { return slideValue; }
  }

  public float SlideMoveSpeedMin {
    get { return slideMoveSpeedMin; }
  }

  public float SlideMoveSpeedMax {
    get { return slideMoveSpeedMax; }
  }

  public int TimeLimit {
    get { return timeLimit; }
  }

  public bool Lost {
    get { return lost; }
  }

  public void Lose() {
    lost = true;
    bubbleManager.ClearAllBubbles();
    gameMenu.Open(scoreManager.Score);
  }
}
