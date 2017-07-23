using UnityEngine;
using System.Collections;

public class LoaderScript : MonoBehaviour {

  public GameObject gameManager;

	void Awake () {
    if(GameManager.instance == null) {
      gameManager = Instantiate(gameManager);
      gameManager.name = "GameManager";
      gameManager.tag = "GameManager";
    }
	}
}
