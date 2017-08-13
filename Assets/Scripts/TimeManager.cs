using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
  public bool debug = false;
  private float time = 0;
  private Text timeLabel = null;

  private void Start()
  {
    if (timeLabel == null)
    {
      timeLabel = GameObject.Find("TimeValue").GetComponent<Text>();
    }

    if (debug) Debug.Log("TimeValue found: " + (timeLabel != null));
    time = GameManager.timeLimit;
  }

  private void Update()
  {
    if(!GameManager.instance.isPlaying)
    {
      return;
    }

    time -= Time.deltaTime;
    // Lose if time hits 0
    if (time <= 0)
    {
      GameManager.instance.LoseCurrentGame();
      if (debug) Debug.Log("Lost due to time out");
    }
    else
    {
      timeLabel.text = Mathf.RoundToInt(time).ToString();
    }
  }
}
