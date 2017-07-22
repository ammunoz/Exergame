using UnityEngine;
using System.Collections;

public class PopScript : BubbleScript {

  protected int countdownBonus = 0;
  protected int countdownRate = 0;
  public Material[] materials = new Material[maxStage];
  protected const int maxStage = 3;
  protected int stage = 0;

  protected void CountDown() {
    if (debug) Debug.Log("Pop bubble: counting down, at stage: " + stage);

    if (stage >= maxStage)
    {
      if (debug) Debug.Log("Pop bubble: popped at stage " + stage);
      Destroy(gameObject);
      return;
    }

    if (stage++ > 0)
    {
      value += countdownBonus;
      Vector3 currentScale = gameObject.transform.localScale;
      gameObject.transform.localScale = new Vector3(
        currentScale.x + 1, currentScale.y + 1, currentScale.z);
      UpdateColor();
    }
  }

  protected override void InitBubble() {
    base.InitBubble();
    value = GameManager.instance.PopValue;
    countdownRate = GameManager.instance.PopCountDownRate;
    countdownBonus = GameManager.instance.PopCountDownBonus;
    InvokeRepeating("CountDown", 0, countdownRate);
  }

  protected void UpdateColor() {
    gameObject.GetComponent<Renderer>().material = materials[stage-1];
  }
}
