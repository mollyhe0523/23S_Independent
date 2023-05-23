using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
    public GameObject DebugCube;
    
    // Start is called before the first frame update
    void Start()
    {
        DebugCube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDebugCube()
    {
        DebugCube.SetActive(true);
    }
}
