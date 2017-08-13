using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleManager : MonoBehaviour
{
  public bool debug = false;
  public bool spawnBubbles = true;
  public GameObject[] bubbleTypes;

  private void Awake()
  {
    bubbleTypes = new GameObject[4];
    bubbleTypes[0] = Resources.Load("Prefabs/Bubble") as GameObject;
    bubbleTypes[1] = Resources.Load("Prefabs/Slide") as GameObject;
    bubbleTypes[2] = Resources.Load("Prefabs/Swish") as GameObject;
    bubbleTypes[3] = Resources.Load("Prefabs/Pop") as GameObject;
  }

  public void ClearAllBubbles()
  {
    GameObject[] currentBubbles = GameObject.FindGameObjectsWithTag("Bubble");
    foreach (GameObject bubble in currentBubbles)
    {
      Destroy(bubble);
    }
  }

  private void HandleInput()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      SpawnBubble("Bubble");
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      SpawnBubble("Slide");
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      SpawnBubble("Swish");
    }
    else if (Input.GetKeyDown(KeyCode.Alpha4))
    {
      SpawnBubble("Pop");
    }
  }

  private void SpawnBubble(int i)
  {
    if (debug) Debug.Log("Bubble spawned");
    GameObject bubble = GameObject.Instantiate(bubbleTypes[i]) as GameObject;
    bubble.tag = "Bubble";
  }

  private void SpawnBubble(string bubbleType)
  {
    if (debug) Debug.Log("Bubble spawned");
    GameObject bubble = GameObject.Instantiate(Resources.Load("Prefabs/" + bubbleType)) as GameObject;
    bubble.tag = "Bubble";
  }

  private void SpawnRandomBubble()
  {
    int randIndex = Random.Range(0, bubbleTypes.Length);
    SpawnBubble(randIndex);
  }

  // Update is called once per frame
  private void Update()
  {
    if (!GameManager.instance.isPlaying)
    {
      return;
    }

    if (Input.anyKeyDown)
    {
      HandleInput();
    }

    GameObject[] currentBubbles = GameObject.FindGameObjectsWithTag("Bubble");
    if (currentBubbles == null || currentBubbles.Length == 0)
    {
      SpawnRandomBubble();
    }
  }
}
