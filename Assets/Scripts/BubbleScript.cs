using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

  public bool debug = false;
  protected bool collided = false;
  protected int value = 0;

  virtual protected void Awake() {
    InitBubble();
  }

  virtual protected void GetRandomLocationOnScreen(out float x, out float y) {
    x = UnityEngine.Random.Range(GameManager.xMin, GameManager.xMax);
    y = UnityEngine.Random.Range(GameManager.yMin, GameManager.yMax);
    if (debug) Debug.Log("Bubble spawned at x: " + x + ", y: " + y);
  }

  virtual protected void InitBubble() {
    // Set values
    value = GameManager.instance.BubbleValue;

    // Set random location
    float x, y;
    GetRandomLocationOnScreen(out x, out y);
    transform.position = new Vector3(x, y, transform.position.z);
  }

  virtual protected void Move() { }

  protected void Update() {
    Move();
  }

  protected void OnTriggerEnter(Collider c) {
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

  protected void OnTriggerExit(Collider c) {
    if(c.tag == "Hand")
      collided = false;
  }
}