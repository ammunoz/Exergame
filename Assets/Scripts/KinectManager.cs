using UnityEngine;
using Windows.Kinect;

public class KinectManager : MonoBehaviour
{
  private KinectSensor _sensor;
  private Body[] _bodies = null;
  private BodyFrameReader _bodyFrameReader;

  public bool IsFire;
  public bool IsAvailable;
  public Vector3 LeftHandPos;
  public Vector3 RightHandPos;

  public static KinectManager instance = null;

  public Body[] GetBodies()
  {
    return _bodies;
  }

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
    {
      Destroy(gameObject);
    }
  }

  // Use this for initialization
  void Start()
  {
    _sensor = KinectSensor.GetDefault();

    if (_sensor != null)
    {
      IsAvailable = _sensor.IsAvailable;

      _bodyFrameReader = _sensor.BodyFrameSource.OpenReader();

      if (!_sensor.IsOpen)
      {
        _sensor.Open();
      }

      _bodies = new Body[_sensor.BodyFrameSource.BodyCount];
    }
  }

  // Update is called once per frame
  void Update()
  {
    IsAvailable = _sensor.IsAvailable;

    if (_bodyFrameReader != null)
    {
      BodyFrame frame = _bodyFrameReader.AcquireLatestFrame();

      if (frame != null)
      {
        frame.GetAndRefreshBodyData(_bodies);

        foreach (Body body in _bodies)
        {
          if(!body.IsTracked)
          {
            continue;
          }

          IsAvailable = true;

          if (body.HandRightConfidence == TrackingConfidence.High && body.HandRightState == HandState.Lasso)
          {
            GameManager.instance.StartNewGame();
          }

          float x = 0.0f;
          float y = 0.0f;

          Windows.Kinect.Joint RightHand = body.Joints[JointType.HandRight];
          x = RescalingToRangesB(-1, 1, -8, 8, RightHand.Position.X);
          y = RescalingToRangesB(-1, 1, -8, 8, RightHand.Position.Y);
          RightHandPos = new Vector3(x, y, 0);

          Windows.Kinect.Joint LeftHand = body.Joints[JointType.HandLeft];
          x = RescalingToRangesB(-1, 1, -8, 8, LeftHand.Position.X);
          y = RescalingToRangesB(-1, 1, -8, 8, LeftHand.Position.Y);
          LeftHandPos = new Vector3(x, y, 0);
        }

        frame.Dispose();
        frame = null;
      }
    }
  }

  static float RescalingToRangesB(float scaleAStart, float scaleAEnd, float scaleBStart, float scaleBEnd, float valueA)
  {
    return (((valueA - scaleAStart) * (scaleBEnd - scaleBStart)) / (scaleAEnd - scaleAStart)) + scaleBStart;
  }

  void OnApplicationQuit()
  {
    if (_bodyFrameReader != null)
    {
      _bodyFrameReader.IsPaused = true;
      _bodyFrameReader.Dispose();
      _bodyFrameReader = null;
    }

    if (_sensor != null)
    {
      if (_sensor.IsOpen)
      {
        _sensor.Close();
      }

      _sensor = null;
    }
  }
}





