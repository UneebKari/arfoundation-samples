using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetectionController : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public GameObject prefabToInstantiate;

    private void Start()
    {
        Invoke("ss",1f);
    }
    void ss() {
        arRaycastManager = GetComponent<ARRaycastManager>();


    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Pose hitPose = new Pose(hit.point, Quaternion.LookRotation(hit.normal));
                Instantiate(prefabToInstantiate, hitPose.position, hitPose.rotation);
            }
        }
    }
}
