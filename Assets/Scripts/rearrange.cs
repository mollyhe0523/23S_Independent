using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rearrange : MonoBehaviour
{
    [SerializeField]
    private GameObject child1;
    [SerializeField]
    private GameObject child2;
    [SerializeField]
    private GameObject child3;
    [SerializeField]
    private GameObject child4;
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
        if (child1 != null)
        {
            myPos = transform.position;
            myRot = transform.rotation;
            // Set the transform of the target GameObject to the current GameObject's transform
            child1.transform.position = new Vector3(myPos.x, myPos.y-0.11f, myPos.z);
            child1.transform.rotation = myRot;
            child2.transform.position = new Vector3(myPos.x, myPos.y-0.22f, myPos.z);
            child2.transform.rotation = myRot;
            child3.transform.position = new Vector3(myPos.x-0.33f, myPos.y-0.22f, myPos.z);
            child3.transform.rotation = myRot;
            child4.transform.position = new Vector3(myPos.x+0.33f, myPos.y-0.22f, myPos.z);
            child4.transform.rotation = myRot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
