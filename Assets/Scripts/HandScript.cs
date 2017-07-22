using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class HandScript : MonoBehaviour {

  public bool debug;
  private Vector3 offset;
  private Vector3 screenPoint;

  void OnMouseDown() {
    if (debug) Debug.Log(this.gameObject.name + ": CLICK");
    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
  }

  void OnMouseDrag() {
    if (debug) Debug.Log(this.gameObject.name + ": DRAG");
    Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
    transform.position = cursorPosition;
  }
}