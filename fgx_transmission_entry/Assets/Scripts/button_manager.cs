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

    public GameObject tempMainButton2Child1;
    public GameObject tempMainButton2Child2;
    public GameObject tempMainButton2Child3;

    public GameObject tempMainButton3Child1;
    public GameObject tempMainButton3Child2;
    public GameObject tempMainButton3Child3;


    void Start()
    {
        //Main buttons
        Button camBtn = cameraButton.GetComponent<Button>(); camBtn.onClick.AddListener(CameraClick);
        Button mainBtn2 = mainButton2.GetComponent<Button>(); mainBtn2.onClick.AddListener(Main2);
        Button mainBtn3 = mainButton3.GetComponent<Button>(); mainBtn3.onClick.AddListener(Main3);

        //Camerabutton children
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

        DisableAllButtons();
    }

    public void OpenMenu()
    {
        SetMainControls(true);
    }

    void CameraClick()
    {
        SetMainControls(false);
        SetCameraControls(true);
    }
    void CameraLeftClick()
    {
        SetCameraControls(false);
        Debug.Log("You have clicked the Camera button!");
    }
    void CameraCenterClick()
    {
        SetCameraControls(false);
        Debug.Log("You have clicked the Camera button!");
    }
    void CameraRightClick()
    {
        SetCameraControls(false);
        Debug.Log("You have clicked the Camera button!");
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
        SetCameraControls(false);
        SetMain2Children(false);
        SetMain3Children(false);
    }
}