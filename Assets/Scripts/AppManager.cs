using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AppManager : MonoBehaviour
{
    [SerializeField] GameObject markerPrefab;
    [SerializeField] GameObject spawnPrefab;
    public GameObject SpawnPrefab
    {
        get { return spawnPrefab; }
        set { spawnPrefab = value; }
    }
    private GameObject spawnObject;
    private GameObject selectedObject;

    private MenuManager menuManager;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    private Vector2 touchPosition;
    private Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

    Quaternion yRotation;

    [SerializeField] Camera arCamera;

    [SerializeField] bool isObjectChosen;
    public bool IsObjectChosen
    {
        get { return isObjectChosen; }
        set { isObjectChosen = value; }
    }

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        menuManager = FindObjectOfType<MenuManager>();
        SetMarker(false);
    }

    void Update()
    {
        if (menuManager.MainMenu.activeSelf || menuManager.RuleScreen.activeSelf)
            return;

        if (IsObjectChosen)
        {
            SpawnObject();
        }

        MoveAndRotateObject();
    }

    private void SpawnObject()
    {
        arRaycastManager.Raycast(screenCenter, s_Hits, TrackableType.PlaneWithinPolygon);
        Pose hitPose = s_Hits[0].pose;
        Touch touch = Input.GetTouch(0);

        if (s_Hits.Count > 0)
        {
            markerPrefab.transform.position = hitPose.position;
            SetMarker(true);
        }

        if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
        {
            spawnObject = Instantiate(SpawnPrefab, hitPose.position, hitPose.rotation);
            isObjectChosen = false;
            SetMarker(false);
        }
    }

    private void MoveAndRotateObject()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("Unselected"))
                    {
                        hitObject.collider.gameObject.tag = "Selected";
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved && Input.touchCount == 1)
            {
                arRaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon);
                Pose hitPose = s_Hits[0].pose;
                selectedObject = GameObject.FindWithTag("Selected");
                selectedObject.transform.position = hitPose.position;
            }

            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    float distance = Vector2.Distance(touch1.position, touch2.position);
                    float previousDistance = Vector2.Distance(touch1.position - touch1.deltaPosition, touch2.position - touch2.deltaPosition);
                    float delta = distance - previousDistance;

                    if (Mathf.Abs(delta) > 0)
                        delta *= 0.05f;
                    else
                    {
                        distance = delta = 0;
                    }

                    yRotation = Quaternion.Euler(0f, -touch1.deltaPosition.x * delta, 0f);
                    selectedObject.transform.rotation *= yRotation;
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (selectedObject.CompareTag("Selected"))
                {
                    selectedObject.gameObject.tag = "Unselected";
                }
            }
        }
    }

    private void SetMarker(bool choice) => markerPrefab.gameObject.SetActive(choice);























































    /*    //[SerializeField] ARSessionOrigin arSessionManager;
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject menuObjects;
        [SerializeField] GameObject sceneMode;
        [SerializeField] GameObject objectMenu;
        [SerializeField] PlaneDetect planeDetectScript;
        [SerializeField] ARRaycastManager arRaycastScript;
        [SerializeField] ARPlaneManager arPlaneScript;

        // Start is called before the first frame update
        void Start()
        {
            //planeDetectScript = arSessionManager.GetComponent<PlaneDetect>();
            //arRaycastScript = arSessionManager.GetComponent<ARRaycastManager>();
            //arPlaneScript = arSessionManager.GetComponent<ARPlaneManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void PlaneMode()
        {
            StartMode(false);
            planeDetectScript.isObjectChosen = false;
        }

        void StartMode(bool choice)
        {
            planeDetectScript.enabled = !choice;
            arRaycastScript.enabled = !choice;
            arPlaneScript.enabled = !choice;
            objectMenu.gameObject.SetActive(!choice);
            mainMenu.gameObject.SetActive(false);
            menuObjects.gameObject.SetActive(false);
            sceneMode.gameObject.SetActive(true);
        }

        public void ShowObjectView()
        {
            objectMenu.transform.GetChild(1).gameObject.SetActive(true);
        }

        public void QuitApp()
        {
            Application.Quit();
            Debug.Log("QUIT");
        }



        public void ChoosePrefab(GameObject prefabType)
        {
            planeDetectScript.prefabObject = prefabType;
            planeDetectScript.isObjectChosen = true;
            objectMenu.transform.GetChild(1).gameObject.SetActive(false);
        }

        void DeactivateGameObjects()
        {
            GameObject[] objectsOnScene = GameObject.FindGameObjectsWithTag("Spawn");
            foreach (GameObject obj in objectsOnScene)
            {
                obj.SetActive(false);
            }
        }*/
}
