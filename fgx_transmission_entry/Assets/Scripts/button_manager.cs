using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class button_manager : MonoBehaviour
{
    public GameObject cameraButton;
    public GameObject mainButton2;
    public GameObject mainButton3;

    public GameObject cameraLeft;
    public GameObject cameraCenter;
    public GameObject cameraRight;

    public GameObject cameraA;
    public GameObject cameraB;
    public GameObject cameraC;

    public GameObject tempMainButton2Child1;
    public GameObject tempMainButton2Child2;
    public GameObject tempMainButton2Child3;

    public GameObject tempMainButton3Child1;
    public GameObject tempMainButton3Child2;
    public GameObject tempMainButton3Child3;

    [SerializeField]
    private string targetCamera;

    GameObject[] objects;


    void Start()
    {
        //Main buttons
        Button camBtn = cameraButton.GetComponent<Button>(); camBtn.onClick.AddListener(CameraClick);
        Button mainBtn2 = mainButton2.GetComponent<Button>(); mainBtn2.onClick.AddListener(Main2);
        Button mainBtn3 = mainButton3.GetComponent<Button>(); mainBtn3.onClick.AddListener(Main3);

        //Camera selection
        Button camA = cameraA.GetComponent<Button>(); camA.onClick.AddListener(CameraAClick);
        Button camB = cameraB.GetComponent<Button>(); camB.onClick.AddListener(CameraBClick);
        Button camC = cameraC.GetComponent<Button>(); camC.onClick.AddListener(CameraCClick);

        //Cameraselection children
        Button camLeft = cameraLeft.GetComponent<Button>(); camLeft.onClick.AddListener(CameraLeftClick);
        Button camCenter = cameraCenter.GetComponent<Button>(); camCenter.onClick.AddListener(CameraCenterClick);
        Button camRight = cameraRight.GetComponent<Button>(); camRight.onClick.AddListener(CameraRightClick);

        //Main2 children
        Button main2Child1 = tempMainButton2Child1.GetComponent<Button>(); main2Child1.onClick.AddListener(m2c1Click);
        Button main2Child2 = tempMainButton2Child2.GetComponent<Button>(); main2Child2.onClick.AddListener(m2c2Click);
        Button main2Child3 = tempMainButton2Child3.GetComponent<Button>(); main2Child3.onClick.AddListener(m2c3Click);

        //Main3 children
        Button main3Child1 = tempMainButton3Child1.GetComponent<Button>(); main3Child1.onClick.AddListener(m3c1Click);
        Button main3Child2 = tempMainButton3Child2.GetComponent<Button>(); main3Child2.onClick.AddListener(m3c2Click);
        Button main3Child3 = tempMainButton3Child3.GetComponent<Button>(); main3Child3.onClick.AddListener(m3c3Click);

        objects = GameObject.FindGameObjectsWithTag("Camera");

        targetCamera = "Empty";

        DisableAllButtons();
    }

    public void OpenMenu()
    {
        SetMainControls(true);
    }

    void CameraClick()
    {
        SetMainControls(false);
        SetCameraSelections(true);
    }

    void SetCameraSelections(bool isEnabled)
    {
        cameraA.SetActive(isEnabled);
        cameraB.SetActive(isEnabled);
        cameraC.SetActive(isEnabled);
    }

    void CameraAClick()
    {
        targetCamera = "Camera-A";
        SetCameraSelections(false);
        SetCameraControls(true);
        Debug.Log("You have clicked the Camera button!");
    }

    void CameraBClick()
    {
        targetCamera = "Camera-B";
        SetCameraSelections(false);
        SetCameraControls(true);
        Debug.Log("You have clicked the Camera button!");
    }

    void CameraCClick()
    {
        targetCamera = "Camera-C";
        SetCameraSelections(false);
        SetCameraControls(true);
        Debug.Log("You have clicked the Camera button!");
    }

    void CameraLeftClick()
    {
        SetCameraControls(false);
        TurnCamera(targetCamera, 1);
        Debug.Log("You have clicked the Camera button!");
    }
    void CameraCenterClick()
    {
        SetCameraControls(false);
        TurnCamera(targetCamera, 2);
        Debug.Log("You have clicked the Camera button!");
    }
    void CameraRightClick()
    {
        SetCameraControls(false);
        TurnCamera(targetCamera, 3);
        Debug.Log("You have clicked the Camera button!");
    }

    /// <summary>
    /// Turns the target camera in the designated position
    /// </summary>
    /// <param name="targetName"></param>
    /// <param name="position">1:left, 2:center, 3:right</param>
    void TurnCamera(string targetName, int position)
    {
        foreach (GameObject obj in objects)
        {
            if (obj.name.Equals(targetName))
            {
                if (position == 1) obj.GetComponent<camera_rotate>().turnLeft();
                else if (position == 2) obj.GetComponent<camera_rotate>().turnCenter();
                else if (position == 3) obj.GetComponent<camera_rotate>().turnRight();
            };
        }
    }

    void Main2()
    {
        SetMainControls(false);
        SetMain2Children(true);
    }

    void Main3()
    {
        SetMainControls(false);
        SetMain3Children(true);
    }

    void m2c1Click()
    {
        SetMain2Children(false);
    }

    void m2c2Click()
    {
        SetMain2Children(false);
    }

    void m2c3Click()
    {
        SetMain2Children(false);
    }
    void m3c1Click()
    {
        SetMain3Children(false);
    }

    void m3c2Click()
    {
        SetMain3Children(false);
    }

    void m3c3Click()
    {
        SetMain3Children(false);
    }

    void SetMainControls(bool isEnabled)
    {
        cameraButton.SetActive(isEnabled);
        mainButton2.SetActive(isEnabled);
        mainButton3.SetActive(isEnabled);
    }

    void SetCameraControls(bool isEnabled)
    {
        cameraLeft.SetActive(isEnabled);
        cameraCenter.SetActive(isEnabled);
        cameraRight.SetActive(isEnabled);
    }

    void SetMain2Children(bool isEnabled)
    {
        tempMainButton2Child1.SetActive(isEnabled);
        tempMainButton2Child2.SetActive(isEnabled);
        tempMainButton2Child3.SetActive(isEnabled);
    }

    void SetMain3Children(bool isEnabled)
    {
        tempMainButton3Child1.SetActive(isEnabled);
        tempMainButton3Child2.SetActive(isEnabled);
        tempMainButton3Child3.SetActive(isEnabled);
    }

    void DisableAllButtons()
    {
        SetMainControls(false);
        SetCameraSelections(false);
        SetCameraControls(false);
        SetMain2Children(false);
        SetMain3Children(false);
    }
}