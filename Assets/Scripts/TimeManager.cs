using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

  public bool debug = false;
  private float time = 0;
  private Text timeLabel = null;

  GameObject gameManagerObject;

  private void Start()
  {
    if (timeLabel == null) {
      timeLabel = GameObject.Find("TimeValue").GetComponent<Text>();
    }

    if (debug) Debug.Log("TimeValue found: " + (timeLabel != null));

    gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
    time = gameManagerObject.GetComponent<GameManager>().TimeLimit;
  }

  private void Update() {
    time -= Time.deltaTime;
    // Lose if time hits 0
    if(time <= 0) {
      if (!GameManager.instance.Lost){
        GameManager.instance.Lose();
      }
      if (debug) Debug.Log("Lost due to time out");
    } else {
      timeLabel.text = Mathf.RoundToInt(time).ToString();
    }
  }
}
