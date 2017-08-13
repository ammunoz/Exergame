using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
  private int score = 0;
  private bool show = false;
  private Rect windowRect = new Rect((Screen.width - 300) / 2, (Screen.height - 125) / 2, Screen.width / 4, Screen.height / 4);

  void OnGUI()
  {
    if (show)
    {
      windowRect = GUI.Window(0, windowRect, DialogWindow, "Game Over");
    }
  }

  // This is the actual window.
  void DialogWindow(int windowID)
  {
    const int numElements = 3;
    float buttonHeight = windowRect.height * 0.1875f; // magic number to tweak
    float buttonInterval = windowRect.height / (numElements + 1);
    
    GUI.Label(new Rect(5, buttonInterval, windowRect.width, buttonHeight), "You got: " + score.ToString() + " point(s)");

    if(GUI.Button(new Rect(5, buttonInterval * 2, windowRect.width - 10, buttonHeight), "Play Again"))
    {
      GameManager.instance.StartNewGame();
    }

    if (GUI.Button(new Rect(5, buttonInterval * 3, windowRect.width - 10, buttonHeight), "Quit"))
    {
      Application.Quit();
      show = false;
    }
  }

  public void Open(int s)
  {
    show = true;
    score = s;
  }

  public void Close()
  {
    show = false;
    score = 0;
  }
}