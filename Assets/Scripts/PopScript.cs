using UnityEngine;
using System.Collections;

public class PopScript : MonoBehaviour {

  public bool debug = false;

  private bool collided = false;
  private int value = 0;
  private int countdownRate = 0;
  private int countdownBonus = 0;
  private int stage = 0;
  private const int maxStage = 3;

  public Material[] materials = new Material[maxStage];

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

  private void Move() { }

  private void GetRandomLocationOnScreen(out int x, out int y) {
    x = UnityEngine.Random.Range(GameManager.xMin + maxStage, GameManager.xMax - maxStage);
    y = UnityEngine.Random.Range(GameManager.yMin + maxStage, GameManager.yMax - maxStage);
    if (debug) Debug.Log("Bubble spawned at x: " + x + ", y: " + y);
  }

  private void InitBubble() {
    // Set values
    value = GameManager.instance.PopValue;
    countdownRate = GameManager.instance.PopCountDownRate;
    countdownBonus = GameManager.instance.PopCountDownBonus;

    // Set random location
    int x, y;
    GetRandomLocationOnScreen(out x, out y);
    transform.position = new Vector3(x, y, transform.position.z);
    InvokeRepeating("CountDown", 0, countdownRate);
  }

  private void CountDown() {
    if (debug) Debug.Log("Pop bubble: counting down, at stage: " + stage);
    if (stage >= maxStage) {
      if (debug) Debug.Log("Pop bubble: popped at stage " + stage);
      Destroy(gameObject);
      return;
    }
      
    if (stage++ > 0) {
      value += countdownBonus;
      Vector3 currentScale = gameObject.transform.localScale;
      gameObject.transform.localScale = new Vector3(
        currentScale.x + 1,
        currentScale.y + 1,
        currentScale.z
      );
      UpdateColor();
    }
  }

  private void UpdateColor() {
    gameObject.GetComponent<Renderer>().material = materials[stage-1];
  }
}
