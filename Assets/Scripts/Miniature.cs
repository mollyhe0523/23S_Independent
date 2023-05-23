using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Miniature : MonoBehaviour
{
    public int number;
    public MiniatureManager _MiniatureManager;
    public GameObject sceneProperties;
    public Vector3 openScenePosition;
    
    private void Awake()
    {
        //GetComponent<XRSimpleInteractable>().interactionManager = GameObject.FindGameObjectsWithTag("XRInteractionManager")[0];
        _MiniatureManager = GameObject.FindGameObjectsWithTag("MiniatureManager")[0].GetComponent<MiniatureManager>();
    }

    private void Start()
    {
        //OpenScene();
    }

    public void SetNumber(int newNumber)
    {
        number = newNumber;
    }

/*
    public void OpenScene()
    {
        //instantiate new scene
        GameObject OpenedScene = Instantiate(sceneProperties, openScenePosition, Quaternion.identity);
        for (int i = 0; i < FindChildrenWithScript(OpenedScene).Length; i++)
        {
            FindChildrenWithScript(OpenedScene)[i].GetComponent<SwitchScene>().miniature = gameObject;
            FindChildrenWithScript(OpenedScene)[i].GetComponent<SwitchScene>().sceneProperty = sceneProperties;
        }
    }
*/
    public void JumpToScene()
    {
        //call destroy later miniatures
        _MiniatureManager.DestroyMiniatures(number);
        //open scene properties
		sceneProperties.SetActive(true);
		
        //GameObject OpenedScene = Instantiate(sceneProperties, openScenePosition, Quaternion.identity);
        /*
		for (int i = 0; i < FindChildrenWithScript(OpenedScene).Length; i++)
        {
            FindChildrenWithScript(OpenedScene)[i].GetComponent<SwitchScene>().miniature = gameObject;
            FindChildrenWithScript(OpenedScene)[i].GetComponent<SwitchScene>().sceneProperty = sceneProperties;
        }
		*/
        //collapse old webpage
        
    }
    
    public GameObject[] FindChildrenWithScript(GameObject parentObject)
    {
        Component[] components = parentObject.GetComponentsInChildren<SwitchScene>();
        GameObject[] result = new GameObject[components.Length];
        for (int i = 0; i < components.Length; i++)
        {
            result[i] = components[i].gameObject;
        }
        return result;
    }
}