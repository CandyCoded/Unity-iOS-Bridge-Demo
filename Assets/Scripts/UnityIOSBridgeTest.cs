using UnityEngine;
using UnityEngine.UI;
using CandyCoded.UnityIOSBridge;
using System.Collections.Generic;
using System;

public class UnityIOSBridgeTest : MonoBehaviour
{

    private struct iOSBridgeMethods
    {
        public string label;
        public Func<string> method;
    }

    [SerializeField]
    private Transform listTransform;

    [SerializeField]
    private VerticalLayoutGroup listVerticalLayoutGroup;

    [SerializeField]
    private GameObject listItemPrefab;

    private List<iOSBridgeMethods> iosBridgeMethods = new List<iOSBridgeMethods>();

    private List<ListItemController> listItemControllers = new List<ListItemController>();

    private void Awake()
    {

        #region Accessibility

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsAssistiveTouchRunning",
            method = () => Accessibility.IOSUIAccessibilityIsAssistiveTouchRunning().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsVoiceOverRunning",
            method = () => Accessibility.IOSUIAccessibilityIsVoiceOverRunning().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsSwitchControlRunning",
            method = () => Accessibility.IOSUIAccessibilityIsSwitchControlRunning().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsShakeToUndoEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsShakeToUndoEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsClosedCaptioningEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsClosedCaptioningEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsBoldTextEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsBoldTextEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "DarkerSystemColorsEnabled",
            method = () => Accessibility.IOSUIAccessibilityDarkerSystemColorsEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsGrayscaleEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsGrayscaleEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsGuidedAccessEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsGuidedAccessEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsInvertColorsEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsInvertColorsEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsMonoAudioEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsMonoAudioEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsReduceMotionEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsReduceMotionEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsReduceTransparencyEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsReduceTransparencyEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsSpeakScreenEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsSpeakScreenEnabled().ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IsSpeakSelectionEnabled",
            method = () => Accessibility.IOSUIAccessibilityIsSpeakSelectionEnabled().ToString()
        });

        #endregion

        #region Permission

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "PermissionCameraOK",
            method = () => Permission.IOSPermissionCameraOK().ToString()
        });

        #endregion

        #region Settings

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IOSIsLowPowerModeEnabled",
            method = () => Settings.IOSIsLowPowerModeEnabled().ToString()
        });

        #endregion

        #region View

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IOSSafeAreaInsets (top)",
            method = () => View.IOSSafeAreaInsets().top.ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IOSSafeAreaInsets (left)",
            method = () => View.IOSSafeAreaInsets().left.ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IOSSafeAreaInsets (right)",
            method = () => View.IOSSafeAreaInsets().right.ToString()
        });

        iosBridgeMethods.Add(new iOSBridgeMethods
        {
            label = "IOSSafeAreaInsets (bottom)",
            method = () => View.IOSSafeAreaInsets().bottom.ToString()
        });

        #endregion

    }

    private void Start()
    {

        for (var i = 0; i < iosBridgeMethods.Count; i += 1)
        {

            var spawnedObject = Instantiate(listItemPrefab, listTransform);

            var listItemController = spawnedObject.GetComponent<ListItemController>();

            listItemController.SetLabel(iosBridgeMethods[i].label);

            listItemControllers.Add(listItemController);

        }

        UpdateListItemValues();
        UpdateLayoutGroupPadding();

    }

    private void UpdateListItemValues()
    {

#if UNITY_IOS
        for (var i = 0; i < iosBridgeMethods.Count; i += 1)
        {

            listItemControllers[i].SetValue(iosBridgeMethods[i].method());

        }
#endif

    }

    private void UpdateLayoutGroupPadding()
    {

        listVerticalLayoutGroup.padding.top = (int)View.IOSSafeAreaInsets().top + 10;
        listVerticalLayoutGroup.padding.left = (int)View.IOSSafeAreaInsets().left + 10;
        listVerticalLayoutGroup.padding.right = (int)View.IOSSafeAreaInsets().right + 10;
        listVerticalLayoutGroup.padding.bottom = (int)View.IOSSafeAreaInsets().bottom + 10;

    }

    private void OnApplicationPause(bool pause)
    {

        UpdateListItemValues();
        UpdateLayoutGroupPadding();

    }

}
