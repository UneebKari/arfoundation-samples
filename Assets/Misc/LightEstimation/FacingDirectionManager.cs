<<<<<<<< Updated upstream:Assets/Scenes/Camera/LightEstimation/FacingDirectionManager.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.XR.CoreUtils;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// This script enables face tracking with user facing camera and disables it otherwise.
    /// It enables the world space object with world facing camera and disables it otherwise.
    /// </summary>
    [RequireComponent(typeof(XROrigin))]
    [RequireComponent(typeof(ARFaceManager))]
    public class FacingDirectionManager : MonoBehaviour
    {
        [SerializeField]
        GameObject m_WorldSpaceObject;

        [SerializeField]
        ARSession m_Session;

        public GameObject worldSpaceObject
        {
            get => m_WorldSpaceObject;
            set => m_WorldSpaceObject = value;
        }

        CameraFacingDirection m_CurrentCameraFacingDirection;
        ARCameraManager m_CameraManager;

        void OnEnable()
        {
            m_CameraManager = GetComponentInChildren<ARCameraManager>();
            m_CurrentCameraFacingDirection = m_CameraManager.currentFacingDirection;
        }

        void Update()
        {
            var updatedCameraFacingDirection = m_CameraManager.currentFacingDirection;
            if (updatedCameraFacingDirection != CameraFacingDirection.None && updatedCameraFacingDirection != m_CurrentCameraFacingDirection)
            {
                if (updatedCameraFacingDirection == CameraFacingDirection.User)
                {
                    m_CurrentCameraFacingDirection = updatedCameraFacingDirection;
                    GetComponent<ARFaceManager>().enabled = true;
                    worldSpaceObject.SetActive(false);
                    Application.onBeforeRender -= OnBeforeRender;
                    if (m_Session)
                    {
                        m_Session.requestedTrackingMode = TrackingMode.RotationOnly;
                    }
                }
                else if (updatedCameraFacingDirection == CameraFacingDirection.World)
                {
                    m_CurrentCameraFacingDirection = updatedCameraFacingDirection;
                    GetComponent<ARFaceManager>().enabled = false;
                    worldSpaceObject.SetActive(true);
                    Application.onBeforeRender += OnBeforeRender;
                    if (m_Session)
                    {
                        m_Session.requestedTrackingMode = TrackingMode.PositionAndRotation;
                    }
                }
            }
        }

        void OnDisable()
        {
            GetComponent<ARFaceManager>().enabled = false;
            Application.onBeforeRender -= OnBeforeRender;
        }

        void OnBeforeRender()
        {
            var camera = GetComponent<XROrigin>().Camera;
            if (camera && worldSpaceObject)
            {
                worldSpaceObject.transform.position = camera.transform.position + camera.transform.forward;
            }
        }

        void Reset()
        {
            if (m_Session == null)
            {
#if UNITY_2023_1_OR_NEWER
                m_Session = FindAnyObjectByType<ARSession>();
#else
                m_Session = FindObjectOfType<ARSession>();
#endif
            }
        }
    }
}
========
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.XR.CoreUtils;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// This script enables face tracking with user facing camera and disables it otherwise.
    /// It enables the world space object with world facing camera and disables it otherwise.
    /// </summary>
    [RequireComponent(typeof(XROrigin))]
    [RequireComponent(typeof(ARFaceManager))]
    public class FacingDirectionManager : MonoBehaviour
    {
        [SerializeField]
        GameObject m_WorldSpaceObject;

        public GameObject worldSpaceObject
        {
            get => m_WorldSpaceObject;
            set => m_WorldSpaceObject = value;
        }

        CameraFacingDirection m_CurrentCameraFacingDirection;
        ARCameraManager m_CameraManager;

        void OnEnable()
        {
            m_CameraManager = GetComponentInChildren<ARCameraManager>();
            m_CurrentCameraFacingDirection = m_CameraManager.currentFacingDirection;
        }

        void Update()
        {
            var updatedCameraFacingDirection = m_CameraManager.currentFacingDirection;
            if (updatedCameraFacingDirection != CameraFacingDirection.None && updatedCameraFacingDirection != m_CurrentCameraFacingDirection)
            {
                if (updatedCameraFacingDirection == CameraFacingDirection.User)
                {
                    m_CurrentCameraFacingDirection = updatedCameraFacingDirection;
                    GetComponent<ARFaceManager>().enabled = true;
                    worldSpaceObject.SetActive(false);
                    Application.onBeforeRender -= OnBeforeRender;
                }
                else if (updatedCameraFacingDirection == CameraFacingDirection.World)
                {
                    m_CurrentCameraFacingDirection = updatedCameraFacingDirection;
                    GetComponent<ARFaceManager>().enabled = false;
                    worldSpaceObject.SetActive(true);
                    Application.onBeforeRender += OnBeforeRender;
                }
            }
        }

        void OnDisable()
        {
            GetComponent<ARFaceManager>().enabled = false;
            Application.onBeforeRender -= OnBeforeRender;
        }

        void OnBeforeRender()
        {
            var camera = GetComponent<XROrigin>().Camera;
            if (camera && worldSpaceObject)
            {
                worldSpaceObject.transform.position = camera.transform.position + camera.transform.forward;
            }
        }
    }
}
>>>>>>>> Stashed changes:Assets/Misc/LightEstimation/FacingDirectionManager.cs
