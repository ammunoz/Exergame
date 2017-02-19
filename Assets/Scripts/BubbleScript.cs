using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

  public bool debug;
  private bool collided;
  private int value = 1;
  
  void Start() {
    collided = false;
  }

  void Update() {

  }

  void OnTriggerEnter(Collider c) {
    if (debug) 
      Debug.Log(gameObject.name + ": collided with " + c.name);

    if (c.tag == "Hand") {
      if (!collided) {
        collided = true;
        GameManager.instance.IncreaseScore(value);
      }
    }
  }

  void OnTriggerExit(Collider c) {
    if(c.tag == "Hand")
      collided = false;
  }
}