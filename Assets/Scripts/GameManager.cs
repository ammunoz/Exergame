using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
  public static GameManager instance = null;
  private ScoreManager scoreManager = null;
  private BubbleManager bubbleManager = null;
  private TimeManager timeManager = null;
  private GameMenu gameMenu = null;

  // Screen values
  public float xMin = 0.0f; // previously -8.0f;
  public float xMax = 0.0f; // previously 8.0f;
  public float yMin = 0.0f; // previously 3.5f;
  public float yMax = 0.0f; // previously 5.5f;

  // Pop values
  public const int popValue = 1;
  public const int popCountDownRate = 3;
  public const int popCountDownBonus = 2;

  // Bubble values
  public const int bubbleValue = 1;

  // Swish values
  public const int swishValue = 2;
  public const int swishRadiusMin = 1;
  public const int swishRadiusMax = 5;
  public const float swishRotateSpeed = 0.5f;

  // Slide values
  public const int slideValue = 2;
  public const float slideMoveSpeedMin = 0.05f;
  public const float slideMoveSpeedMax = 0.10f;

  // Time Attack value
  public const int timeLimit = 60;

  // Game state
  public bool isPlaying = false;

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
    {
      Destroy(gameObject);
    }

    isPlaying = false;
    gameMenu = gameObject.AddComponent<GameMenu>();

    Vector3 screenInfo = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    float playableWidth = screenInfo.x * 0.85f;
    float playableHeight = screenInfo.y * 0.85f;
    xMax = System.Math.Min(5.0f, playableWidth); xMin = System.Math.Max(-4.75f, -playableWidth);
    yMax = playableHeight; yMin = -playableHeight / 2.0f;
  }

  public void IncreaseScore(int s)
  {
    scoreManager.IncreaseScore(s);
  }

  public void LoseCurrentGame()
  {
    isPlaying = false;
    bubbleManager.ClearAllBubbles();
    gameMenu.Open(scoreManager.Score);
  }

  public void StartNewGame()
  {
    if(isPlaying)
    {
      return;
    }

    if(scoreManager != null)
    {
      Destroy(scoreManager);
    }

    if(bubbleManager != null)
    {
      Destroy(bubbleManager);
    }

    if(timeManager != null)
    {
      Destroy(timeManager);
    }

    isPlaying = true;
    scoreManager = gameObject.AddComponent<ScoreManager>();
    bubbleManager = gameObject.AddComponent<BubbleManager>();
    timeManager = gameObject.AddComponent<TimeManager>();
    gameMenu.Close();
  }
}
