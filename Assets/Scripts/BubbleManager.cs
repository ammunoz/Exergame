using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleManager : MonoBehaviour {

  public bool debug = false;

	// Use this for initialization
	private void Start () {
	}

  private void Awake() {
  }
	
	// Update is called once per frame
	private void Update () {
    if(Input.anyKeyDown)
      HandleInput();
	}

  private void HandleInput() {
    if(Input.GetKeyDown(KeyCode.Alpha1)) {
      SpawnBubble("Bubble");
    } else if(Input.GetKeyDown(KeyCode.Alpha2)) {
      SpawnBubble("Swish");
    }
  }

  private void SpawnBubble(string bubbleType) {
    if (debug) Debug.Log("Bubble spawned");
    GameObject bubble = GameObject.Instantiate(Resources.Load("Prefabs/" + bubbleType)) as GameObject;
  }
}
