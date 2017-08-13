using UnityEngine;

public class HandManager : MonoBehaviour
{

  public GameObject LeftHand;
  public GameObject RightHand;

  // Update is called once per frame
  void Update()
  {
    if (KinectManager.instance == null ||
        !KinectManager.instance.IsAvailable)
    {
      return;
    }

    RightHand.transform.position = KinectManager.instance.RightHandPos;
    LeftHand.transform.position = KinectManager.instance.LeftHandPos;
  }
}
