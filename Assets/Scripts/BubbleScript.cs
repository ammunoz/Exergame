using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

  public bool debug = false;
  private bool collided = false;
  private int value = 0;

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

  private void GetRandomLocationOnScreen(out float x, out float y) {
    x = UnityEngine.Random.Range(GameManager.xMin, GameManager.xMax);
    y = UnityEngine.Random.Range(GameManager.yMin, GameManager.yMax);
    if (debug) Debug.Log("Bubble spawned at x: " + x + ", y: " + y);
  }

  private void InitBubble() {
    // Set values
    value = GameManager.instance.BubbleValue;

    // Set random location
    float x, y;
    GetRandomLocationOnScreen(out x, out y);
    transform.position = new Vector3(x, y, transform.position.z);
  }
}