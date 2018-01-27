using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class button_manager : MonoBehaviour
{
    public GameObject cameraRotateButton;
    public GameObject cameraSelectionButton;
    public GameObject mainButton3;

    public GameObject cameraLeft;
    public GameObject cameraCenter;
    public GameObject cameraRight;

    public GameObject cameraA;
    public GameObject cameraB;
    public GameObject cameraC;

    public GameObject displayCameraAButton;
    public GameObject displayCameraBButton;
    public GameObject displayCameraCButton;

    public GameObject tempMainButton3Child1;
    public GameObject tempMainButton3Child2;
    public GameObject tempMainButton3Child3;

    [SerializeField]
    private string targetCamera;

    [SerializeField]
    private int displayCamera;

    public GameObject displayCameraPanel;

    public Material displayCameraMatA;
    public Material displayCameraMatB;
    public Material displayCameraMatC;

    GameObject[] cameras;


    void Start()
    {
        //Main buttons
        Button camRotate = cameraRotateButton.GetComponent<Button>(); camRotate.onClick.AddListener(CameraRotateClick);
        Button camSelection = cameraSelectionButton.GetComponent<Button>(); camSelection.onClick.AddListener(CameraSelectionClick);
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
        Button dispCamA = displayCameraAButton.GetComponent<Button>(); dispCamA.onClick.AddListener(DisplayCamAClick);
        Button dispCamB = displayCameraBButton.GetComponent<Button>(); dispCamB.onClick.AddListener(DisplayCamBClick);
        Button dispCamC = displayCameraCButton.GetComponent<Button>(); dispCamC.onClick.AddListener(DisplayCamCClick);

        //Main3 children
        Button main3Child1 = tempMainButton3Child1.GetComponent<Button>(); main3Child1.onClick.AddListener(m3c1Click);
        Button main3Child2 = tempMainButton3Child2.GetComponent<Button>(); main3Child2.onClick.AddListener(m3c2Click);
        Button main3Child3 = tempMainButton3Child3.GetComponent<Button>(); main3Child3.onClick.AddListener(m3c3Click);

        cameras = GameObject.FindGameObjectsWithTag("Camera");

        targetCamera = "Empty";

        DisableAllButtons();
    }

    public void OpenMenu()
    {
        SetMainControls(true);
    }

    void CameraRotateClick()
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
        foreach (GameObject obj in cameras)
        {
            if (obj.name.Equals(targetName))
            {
                if (position == 1) obj.GetComponent<camera_rotate>().turnLeft();
                else if (position == 2) obj.GetComponent<camera_rotate>().turnCenter();
                else if (position == 3) obj.GetComponent<camera_rotate>().turnRight();
            };
        }
    }

    void CameraSelectionClick()
    {
        SetMainControls(false);
        SetMain2Children(true);
    }

    void Main3()
    {
        SetMainControls(false);
        SetMain3Children(true);
    }

    void DisplayCamAClick()
    {
        SetMain2Children(false);
        displayCamera = 1;
        ChangeDisplayCamera();
    }

    void DisplayCamBClick()
    {
        SetMain2Children(false);
        displayCamera = 2;
        ChangeDisplayCamera();
    }

    void DisplayCamCClick()
    {
        SetMain2Children(false);
        displayCamera = 3;
        ChangeDisplayCamera();
    }

    void ChangeDisplayCamera()
    {
        if (displayCamera == 1) displayCameraPanel.GetComponent<Renderer>().material = displayCameraMatA;
        else if (displayCamera == 2) displayCameraPanel.GetComponent<Renderer>().material = displayCameraMatB;
        else if (displayCamera == 3) displayCameraPanel.GetComponent<Renderer>().material = displayCameraMatC;
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
        cameraRotateButton.SetActive(isEnabled);
        cameraSelectionButton.SetActive(isEnabled);
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
        displayCameraAButton.SetActive(isEnabled);
        displayCameraBButton.SetActive(isEnabled);
        displayCameraCButton.SetActive(isEnabled);
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