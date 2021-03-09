using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    public GameObject MainMenu
    {
        get { return mainMenu; }
        set { mainMenu = value; }
    }

    [SerializeField] GameObject ruleScreen;
    public GameObject RuleScreen
    {
        get { return ruleScreen; }
        set { ruleScreen = value; }
    }

    private AppManager appManager;

    void Awake()
    {
        appManager = FindObjectOfType<AppManager>();
    }

    public void ChooseObject(GameObject spawnPrefab)
    {
        appManager.SpawnPrefab = spawnPrefab;
        appManager.IsObjectChosen = true;
    }

    public void CloseApp()
    {
        Application.Quit();
        Debug.Log("App closed");
    }

}
