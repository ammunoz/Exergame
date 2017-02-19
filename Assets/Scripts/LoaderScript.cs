using UnityEngine;
using System.Collections;

public class LoaderScript : MonoBehaviour {

  public GameObject gameManager;
	// Use this for initialization
	void Awake () {
    if(GameManager.instance == null) {
      gameManager = Instantiate(gameManager);
      gameManager.name = "GameManager";
    }
	}
}
