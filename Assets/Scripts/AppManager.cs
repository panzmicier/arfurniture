using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AppManager : MonoBehaviour
{
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
