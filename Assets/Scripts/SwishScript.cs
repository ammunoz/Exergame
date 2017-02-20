using UnityEngine;
using System.Collections;

public class SwishScript : MonoBehaviour{

  public bool debug = false;
  private bool collided = false;

  private int value = 0;
  private int radius = 0;
  private float rotateSpeed = 0;
  private float angle = 0;
  private Vector3 center;

  // Use this for initialization
  private void Awake() {
    InitBubble();
  }

  private void Move() {
    angle += rotateSpeed * Time.deltaTime;

    Vector3 offset = new Vector3(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius, transform.position.z);
    transform.position = center + offset;
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

  private void GetRandomLocationOnScreen(out int x, out int y) {
    x = UnityEngine.Random.Range(GameManager.xMin + radius, GameManager.xMax - radius);
    y = UnityEngine.Random.Range(GameManager.yMin + radius, GameManager.yMax - radius);
    if (debug) Debug.Log("Bubble spawned at x: " + x + ", y: " + y);
  }

  private void InitBubble() {
    // Set values
    value = GameManager.instance.SwishValue;
    radius = UnityEngine.Random.Range(GameManager.instance.SwishRadiusMin, GameManager.instance.SwishRadiusMax);
    rotateSpeed = GameManager.instance.SwishRotateSpeed;

    // Set random location
    int x, y;
    GetRandomLocationOnScreen(out x, out y);
    transform.position = new Vector3(x, y, transform.position.z);
    center = transform.position;
  }
}
