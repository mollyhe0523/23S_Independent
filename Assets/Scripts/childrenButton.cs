using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class childrenButton : MonoBehaviour
{
    private XRSimpleInteractable _simpleInteractable;
    private Image myImage;
    
    public GameObject p_original;
    public List<GameObject> p_children;

    [SerializeField] private List<Panel> panelScripts; // A list of references to all panel scripts
    [SerializeField] private List<XRGrabInteractable> panelGrabInteractables; 
    [SerializeField] private GameObject debugCanvas;
    private TextMeshProUGUI debugText;
    void Start()
    {
        debugText = debugCanvas.GetComponent<TextMeshProUGUI>();

        _simpleInteractable = GetComponent<XRSimpleInteractable>();
        myImage = GetComponent<Image>();
        
        
        _simpleInteractable.selectEntered.AddListener(mySelect);
        _simpleInteractable.hoverEntered.AddListener(myHover);
        _simpleInteractable.hoverExited.AddListener(myHoverExit);

    }

    private void mySelect(SelectEnterEventArgs args)
    {
        debugText.text = "Button clicked";
        int panelIndex = GetCurrentlyGrabbedPanelIndex();
        if (panelIndex != -1)
        {
            panelScripts[panelIndex].PassValueToChildrenButton();
            for (int i = 0; i < p_children.Count; i++)
            {
                debugText.text += ", " + p_children[i].name;
            }
        }

        for (int i = 0; i < p_children.Count; i++)
        {
            p_children[i].SetActive(true);
            p_children[i].transform.position = new Vector3(p_original.transform.position.x + 0.5f * i, p_original.transform.position.y - 0.3f, p_original.transform.position.z);
            p_children[i].transform.rotation = p_original.transform.rotation;
        }
        // p_original.SetActive(false);
        // debugText.text = "Button went through";
        // gameObject.SetActive(false);
    }
    private int GetCurrentlyGrabbedPanelIndex()
    {
        for (int i = 0; i < panelGrabInteractables.Count; i++)
        {
            if (panelGrabInteractables[i].isSelected)
            {
                // debugText.text = i.ToString();
                return i;
            }
        }
        // debugText.text = "-1";
        return -1; // Return -1 if no panel is currently grabbed
    }
    private void myHover(HoverEnterEventArgs args)
    {
        myImage.color = Color.blue;
    }
    
    private void myHoverExit(HoverExitEventArgs args)
    {
        debugText.text = "Hover exit";
        myImage.color = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
