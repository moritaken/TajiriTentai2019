using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MainScript : MonoBehaviour
{
    public GameObject tracker;
    public GameObject spaceSun;
    public GameObject earthSun;
    public GameObject earthEnv;
    public GameObject earthModel;
    public Material skyBoxEarth;
    public Material skyBoxSpace;
    public GameObject trackerModel;
    public GameObject offsetEarthSun;
    public GameObject offsetSpaceSun;
    public GameObject offsetEarthModel;
    private SteamVR_Action_Boolean triger;
    private SteamVR_Action_Boolean trackPad;
    private Vector2 trackPadPos;
    private bool viewState; // false = earth view , true = space view    

    static readonly float spring = 55.0f;
    static readonly float fall = 55.0f;
    static readonly float summer = 78.4f;
    static readonly float winter = 31.6f;

    private void Start()
    {
        triger = SteamVR_Actions.default_InteractUI;
        trackPad = SteamVR_Actions.default_Teleport;
        viewState = false;
    }

    private void Update()
    {
        ControllerUpdate();
        UpdateSunRotation();
    } // Update

    private void ControllerUpdate()
    {
        // trigger 
        if (triger.GetStateDown(SteamVR_Input_Sources.LeftHand) || triger.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            viewState = !viewState;

            if (viewState) //spaceView
            {
                earthEnv.SetActive(false);
                spaceSun.SetActive(true);
                earthSun.SetActive(false);
                earthModel.SetActive(true);
                RenderSettings.skybox = skyBoxSpace;
            }
            else if (!viewState)
            {
                earthEnv.SetActive(true);
                spaceSun.SetActive(false);
                earthSun.SetActive(true);
                earthModel.SetActive(false);
                RenderSettings.skybox = skyBoxEarth;
            }
        }

        // trackpad
        if (trackPad.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {

            trackPadPos = SteamVR_Actions.default_TrackPad.GetLastAxis(SteamVR_Input_Sources.LeftHand);
            if (trackPadPos.x == 0.0f && trackPadPos.y == 0.0f)
            {
                return;
            }
            if (trackPadPos.y / trackPadPos.x > 1 || trackPadPos.y / trackPadPos.x < -1)
            {
                if (trackPadPos.y > 0)
                {
                    // 春
                    offsetEarthSun.transform.localRotation = Quaternion.Euler(spring, 90.0f, 0.0f);
                    offsetSpaceSun.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                    offsetEarthModel.transform.localRotation = Quaternion.Euler(45.0f, 90.0f, 90.0f);
                    Debug.Log("Up Button"); 
                }
                else
                {
                    // 秋
                    offsetEarthSun.transform.localRotation = Quaternion.Euler(fall, 90.0f, 0.0f);
                    offsetSpaceSun.transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                    offsetEarthModel.transform.localRotation = Quaternion.Euler(225.0f, 90.0f, 90.0f);
                    Debug.Log("Down Button");
                }
            }
            else
            {
                if (trackPadPos.x > 0)
                {
                    // 冬
                    offsetEarthSun.transform.localRotation = Quaternion.Euler(winter, 90.0f, 0.0f);
                    offsetSpaceSun.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    offsetEarthModel.transform.localRotation = Quaternion.Euler(-45.0f, 90.0f, 90.0f);
                    Debug.Log("Right Button");
                }
                else
                {
                    // 夏
                    offsetEarthSun.transform.localRotation = Quaternion.Euler(summer, 90.0f, 0.0f);
                    offsetSpaceSun.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    offsetEarthModel.transform.localRotation = Quaternion.Euler(120.0f, 90.0f, 90.0f);
                    Debug.Log("Left Button");
                }
            }
        }
        else if (trackPad.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            trackPadPos = SteamVR_Actions.default_TrackPad.GetLastAxis(SteamVR_Input_Sources.RightHand);
            if (trackPadPos.x == 0.0f && trackPadPos.y == 0.0f)
            {
                return;
            }
            if (trackPadPos.y / trackPadPos.x > 1 || trackPadPos.y / trackPadPos.x < -1)
            {
                if (trackPadPos.y > 0)
                {
                    // 春
                    offsetEarthSun.transform.localRotation = Quaternion.Euler(spring, 90.0f, 0.0f);
                    offsetSpaceSun.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                    offsetEarthModel.transform.localRotation = Quaternion.Euler(45.0f, 90.0f, 90.0f);
                    Debug.Log("Up Button"); 
                }
                else
                {
                    // 秋
                    offsetEarthSun.transform.localRotation = Quaternion.Euler(fall, 90.0f, 0.0f);
                    offsetSpaceSun.transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                    offsetEarthModel.transform.localRotation = Quaternion.Euler(225.0f, 90.0f, 90.0f);
                    Debug.Log("Down Button");
                }
            }
            else
            {
                if (trackPadPos.x > 0)
                {
                    // 冬
                    offsetEarthSun.transform.localRotation = Quaternion.Euler(winter, 90.0f, 0.0f);
                    offsetSpaceSun.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    offsetEarthModel.transform.localRotation = Quaternion.Euler(-45.0f, 90.0f, 90.0f);
                    Debug.Log("Right Button");
                }
                else
                {
                    // 夏
                    offsetEarthSun.transform.localRotation = Quaternion.Euler(summer, 90.0f, 0.0f);
                    offsetSpaceSun.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    offsetEarthModel.transform.localRotation = Quaternion.Euler(120.0f, 90.0f, 90.0f);
                    Debug.Log("Left Button");
                }
            }
        }
    } // ControllerUpdate

    private void UpdateSunRotation()
    {
        float trackerZAngle = tracker.transform.eulerAngles.z;
        earthSun.transform.localRotation = Quaternion.Euler(0.0f, -trackerZAngle + 90, 0.0f);
    } // UpdateSunRotation
}// MainScript
