using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
  // 300x200 px window will apear in the center of the screen.
  private Rect windowRect = new Rect((Screen.width - 300) / 2, (Screen.height - 125) / 2, 300, 125);
  // Only show it if needed.
  private bool show = false;
  private int score = 0;

  void OnGUI()
  {
    if (show)
      windowRect = GUI.Window(0, windowRect, DialogWindow, "Game Over");
  }

  // This is the actual window.
  void DialogWindow(int windowID)
  {
    float y = 30;
    GUI.Label(new Rect(5, y, windowRect.width, 20), "You got: " + score.ToString() + " point(s)");

    if (GUI.Button(new Rect(5, y*2, windowRect.width - 10, 20), "Play Again"))
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
      show = false;
    }

    if (GUI.Button(new Rect(5, y*3, windowRect.width - 10, 20), "Quit"))
    {
      Application.Quit();
      show = false;
    }
  }

  // To open the dialogue from outside of the script.
  public void Open(int s)
  {
    show = true;
    score = s;
  }
}