﻿using UnityEngine;
using System.Collections;

public class SwishScript : BubbleScript
{
  protected float angle = 0;
  protected Vector3 center;
  protected int radius = 0;
  protected float rotateSpeed = 0;

  protected override void GetRandomLocationOnScreen(out float x, out float y)
  {
    x = UnityEngine.Random.Range(GameManager.instance.xMin + radius, GameManager.instance.xMax - radius);
    y = UnityEngine.Random.Range(GameManager.instance.yMin + radius, GameManager.instance.yMax - radius);
    if (debug) Debug.Log("[Swish] Bubble spawned at x: " + x + ", y: " + y);
  }

  protected override void InitBubble()
  {
    base.InitBubble();
    value = GameManager.swishValue;
    radius = UnityEngine.Random.Range(GameManager.swishRadiusMin, GameManager.swishRadiusMax);
    center = transform.position;
    rotateSpeed = GameManager.swishRotateSpeed;
  }

  protected override void Move()
  {
    base.Move();
    angle += rotateSpeed * Time.deltaTime;
    Vector3 offset = new Vector3(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius, transform.position.z);
    transform.position = center + offset;
  }
}
