﻿using UnityEngine;
using System.Collections;

public class SlideScript : BubbleScript {

  protected float horizontalDirection = 0f;
  protected float moveSpeed = 0f;
  protected float verticalDirection = 0f;

  protected override void GetRandomLocationOnScreen(out float x, out float y) {
    float a, b;
    base.GetRandomLocationOnScreen(out a, out b);
    x = Mathf.RoundToInt(a); y = Mathf.RoundToInt(b);
  }

  protected override void InitBubble() {
    base.InitBubble();

    // Set values
    value = GameManager.instance.SlideValue;
    moveSpeed = UnityEngine.Random.Range(GameManager.instance.SlideMoveSpeedMin, GameManager.instance.SlideMoveSpeedMax);

    // Set random direction
    verticalDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
    horizontalDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
  }

  protected override void Move() {
    base.Move();
    float current_x = transform.position.x;
    float current_y = transform.position.y;

    // If bubble passes horizontal boundaries, switch direction
    if (current_x + 1 <= GameManager.xMin || current_x - 1 >= GameManager.xMax)
      horizontalDirection *= -1;

    // If bubble passes vertical boundaries, switch direction
    if (current_y <= GameManager.yMin || current_y >= GameManager.yMax)
      verticalDirection *= -1;

    transform.position = new Vector3(
      current_x + horizontalDirection * moveSpeed,
      current_y + verticalDirection * moveSpeed,
      transform.position.z
    );
  }
}
