using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class syncTransform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Button clickButton;

    private Vector3 myPos;
    private Quaternion myRot;

    // Start is called before the first frame update
    void Start()
    {
        // Add the OnClick listener to the button
        clickButton.onClick.AddListener(OnButtonClick);
 
    }

    // Method to execute when the button is clicked
    private void OnButtonClick()
    {
        if (target != null)
        {
            myPos = transform.position;
            myRot = transform.rotation;
            // Set the transform of the target GameObject to the current GameObject's transform
            target.transform.position = myPos;
            target.transform.rotation = myRot;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
