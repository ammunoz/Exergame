using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleManager : MonoBehaviour {

  public bool debug = false;

  private void HandleInput() {
    if(Input.GetKeyDown(KeyCode.Alpha1)) {
      SpawnBubble("Bubble");
    } else if(Input.GetKeyDown(KeyCode.Alpha2)) {
      SpawnBubble("Slide");
    } else if(Input.GetKeyDown(KeyCode.Alpha3)) {
      SpawnBubble("Swish");
    } else if(Input.GetKeyDown(KeyCode.Alpha4)) {
      SpawnBubble("Pop");
    }
  }

  private void SpawnBubble(string bubbleType) {
    if (debug) Debug.Log("Bubble spawned");
    GameObject.Instantiate(Resources.Load("Prefabs/" + bubbleType));
  }

  // Update is called once per frame
  private void Update() {
    if (Input.anyKeyDown) {
      HandleInput();
    }
  }
}
