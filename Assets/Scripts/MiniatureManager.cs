using System.Collections.Generic;
using UnityEngine;

public class MiniatureManager : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    public GameObject miniaturePrefab;

    public List<GameObject> miniatures = new List<GameObject>();
    public Camera mainCamera;

    void Awake()
    {
        // Instantiate a prefab at the first position
        if (positions.Count > 0)
        {
            GameObject miniatureObject = Instantiate(miniaturePrefab, positions[0].position, Quaternion.identity);
            Miniature miniature = miniatureObject.GetComponentInChildren<Miniature>();

            if (miniature != null)
            {
                // Assign the number order to the miniature
                miniature.SetNumber(1);
            }

            // Set the miniature as a child of the MainCamera
            if (mainCamera != null)
            {
                miniatureObject.transform.SetParent(mainCamera.transform);
            }

            miniatures.Add(miniatureObject);
        }
    }
    
    
    public void SpawnMiniature()
    {
        // Find the next available position
        int nextPositionIndex = miniatures.Count;

        if (nextPositionIndex < positions.Count)
        {
            // Instantiate the miniature at the next position
            GameObject miniatureObject = Instantiate(miniaturePrefab, positions[nextPositionIndex].position, Quaternion.identity);
            Miniature miniature = miniatureObject.GetComponentInChildren<Miniature>();

            if (miniature != null)
            {
                // Assign the number order to the miniature
                miniature.SetNumber(nextPositionIndex + 1);
            }

            // Set the miniature as a child of the MainCamera
            
            if (mainCamera != null)
            {
                miniatureObject.transform.SetParent(mainCamera.transform);
            }

            miniatures.Add(miniatureObject);
        }
        else
        {
            Debug.Log("All positions are filled!");
        }
    }

    public void DestroyMiniatures(int startNumber)
    {
		
        for (int i = miniatures.Count - 1; i >= 0; i--)
        {
            Miniature miniature = miniatures[i].GetComponentInChildren<Miniature>();
			//Debug.Log(miniature.number);
            //Debug.Log(miniature.number + " " + startNumber);
            if (miniature != null && miniature.number > startNumber)
            {
                //Debug.Log(miniature.number + " " + startNumber);
                if (miniatures[i].GetComponentInChildren<Miniature>().sceneProperties != null)
                {
                    Destroy(miniature.sceneProperties);
                    //Destroy(miniatures[i].GetComponentInChildren<Miniature>().sceneProperties);
                }
                Destroy(miniatures[i]);
                miniatures.RemoveAt(i);
            }
        }
    }
}