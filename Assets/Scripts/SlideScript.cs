using UnityEngine;
using System.Collections;

public class SlideScript : MonoBehaviour {

  public bool debug = false;
  private bool collided = false;
  private int value = 0;
  private float moveSpeed = 0f;
  private float verticalDirection = 0f;
  private float horizontalDirection = 0f;

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
    if (c.tag == "Hand")
      collided = false;
  }

  private void Move() {
    float current_x = transform.position.x;
    float current_y = transform.position.y;

    // If bubble passes horizontal boundaries, switch direction
    if (current_x+1 <= GameManager.xMin || current_x-1 >= GameManager.xMax)
      horizontalDirection *= -1;
    
    // If bubble passes vertical boundaries, switch direction
    if (current_y <= GameManager.yMin || current_y >= GameManager.yMax)
      verticalDirection *= -1;

    transform.position = new Vector3(
      current_x + horizontalDirection*moveSpeed,
      current_y + verticalDirection*moveSpeed,
      transform.position.z
    );
  }

  private void GetRandomLocationOnScreen(out int x, out int y) {
    x = UnityEngine.Random.Range(-10, 10);
    y = UnityEngine.Random.Range(-3, 6);
    if (debug) Debug.Log("Bubble spawned at x: " + x + ", y: " + y);
  }

  private void InitBubble() {
    // Set values
    value = GameManager.instance.SlideValue;
    moveSpeed = UnityEngine.Random.Range(GameManager.instance.SlideMoveSpeedMin, GameManager.instance.SlideMoveSpeedMax);

    // Set random location
    int x, y;
    GetRandomLocationOnScreen(out x, out y);
    transform.position = new Vector3(x, y, transform.position.z);

    // Set random direction
    verticalDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
    horizontalDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
  }
}
