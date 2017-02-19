﻿using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

  public bool debug = false;
  private bool collided = false;
  private int value = 1;

  private void Awake() {
    InitBubble();
  }

  private void Update() {
    Move();
  }

  private void OnTriggerEnter(Collider c) {
    if (debug) 
      Debug.Log(gameObject.name + ": collided with " + c.name);

    if (c.tag == "Hand") {
      if (!collided) {
        collided = true;
        GameManager.instance.IncreaseScore(value);
        Destroy(this.gameObject);
      }
    }
  }

  private void OnTriggerExit(Collider c) {
    if(c.tag == "Hand")
      collided = false;
  }

  private void Move() {}

  private void GetRandomLocationOnScreen(out int x, out int y) {
    x = UnityEngine.Random.Range(-10, 10);
    y = UnityEngine.Random.Range(-3, 6);
    if (debug) Debug.Log("Bubble spawned at x: " + x + ", y: " + y);
  }

  private void InitBubble() {
    int x, y;
    GetRandomLocationOnScreen(out x, out y);
    transform.position = new Vector3(x, y, transform.position.z);
  }
}