using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    GameObject openedScene;

    private GameObject currentPageMiniature;

    public float duration = 1f;
    public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f); // Animation curve to use for the motion

    //public GameObject sceneProperty;
    private Vector3 openedSceneStartPos;
    private Vector3 openedSceneStartScale;
    private MiniatureManager _miniatureManager;

    //public GameObject debugCube;
    
    public GameObject NextPage;
    public Vector3 openScenePosition;
    //public string pageName;
    private GameObject NewlyOpenedPage;
    private GameObject CurrentPage;

    private bool StartingPageAssignment = false;
    
    // Start is called before the first frame update
    
    
    //Open new page: Instantiate next page
    
    //Instantiate new miniature, assign the newly opened page to the mniature's page slot
    
    //Find and destroy the previous page in scene hierarchy
    
    void Start()
    {

        openedScene = transform.parent.parent.Find("Orb").gameObject;
        _miniatureManager = GameObject.FindGameObjectsWithTag("MiniatureManager")[0].GetComponent<MiniatureManager>();
        currentPageMiniature = _miniatureManager.miniatures[_miniatureManager.miniatures.Count -1];
        CurrentPage = transform.parent.gameObject;
        
        openedSceneStartPos = openedScene.transform.position;
        openedSceneStartScale = openedScene.transform.localScale;
        
        //debugCube.SetActive(false);
        
    }

    public GameObject FindChildWithTag(GameObject parent, string tag)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }

        return null;
    }
    
    public void ShrinkAndMove()
    {
        //debugCube.SetActive(true);
        StartCoroutine(ShrinkAndMoveCoroutine());
        Invoke("DisableSceneProperty", duration);
    }


    public void DisableSceneProperty()
    {
        CurrentPage.SetActive(false);
    }

    private IEnumerator ShrinkAndMoveCoroutine()
    {
        /*//Instantiate miniature of new scene
        _miniatureManager.SpawnMiniature();*/
        
        //
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            float t = curve.Evaluate(timeElapsed / duration);

            // Shrink the big sphere using Lerp
            openedScene.transform.localScale = Vector3.Lerp(openedSceneStartScale, currentPageMiniature.transform.localScale, t);

            // Move the big sphere using Lerp
            openedScene.transform.position = Vector3.Lerp(openedSceneStartPos, currentPageMiniature.transform.position, t);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (StartingPageAssignment == false && _miniatureManager.miniatures.Count == 1)
        {
            _miniatureManager.miniatures[0].GetComponentInChildren<Miniature>().sceneProperties = CurrentPage;
            StartingPageAssignment = true;
        }
    }

    public void SwitchPage()
    {
        //Open new page: Instantiate next page
    
        NewlyOpenedPage =Instantiate(NextPage, openScenePosition, Quaternion.identity);
        
        //Instantiate new miniature, assign the newly opened page to the miniature's page slot

        _miniatureManager.SpawnMiniature();
        _miniatureManager.miniatures[_miniatureManager.miniatures.Count-1].GetComponentInChildren<Miniature>().sceneProperties = NewlyOpenedPage;

        //Find and destroy the previous page in scene hierarchy

        ShrinkAndMove();

        
    }
}
