using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Panel : MonoBehaviour
{
    [SerializeField] private SceneManager SceneManager;
    [SerializeField] private sumButton SumButton;
    [SerializeField] private paraButton ParaButton;
    [SerializeField] private closeButton CloseButton;
    [SerializeField] private childrenButton ChildrenButton;
    
    [SerializeField] private bool hasChild;
    [SerializeField] private List<GameObject> children;
    
    [SerializeField] private bool isRoot;
    
    [SerializeField] private bool isSummary;
    [SerializeField] private GameObject sumOrPara;
    [SerializeField] private bool noContent;

    [SerializeField] private GameObject bPanel;
    [SerializeField] private GameObject bSum;
    [SerializeField] private GameObject bPara;
    [SerializeField] private GameObject bChildren;
    [SerializeField] private GameObject bClose;
    [SerializeField] private GameObject bRearrange;
    
    [SerializeField] private GameObject line;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject parentLine;

    [SerializeField] private GameObject progressCircle;
    private Image myImage;
    
    [SerializeField] private GameObject debugCanvas;
    private TextMeshProUGUI debugText;
    
    private float pinchMove=0;
    private float timer=0;
    private Vector3 prePinchPos;
    private Vector3 curPinchPos;
    private bool pinched = false;
    private bool buttonOn = false;

    private Vector3 preTransform;
    private Vector3 curTransform;
    
    private XRGrabInteractable _grabInteractable;
    void Start()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _grabInteractable.selectEntered.AddListener(mySelect);
        _grabInteractable.selectExited.AddListener(myRelease);
        debugText = debugCanvas.GetComponent<TextMeshProUGUI>();
        prePinchPos = new Vector3(0, 0, 0);
        preTransform= new Vector3(0, 0, 0);
        myImage = progressCircle.GetComponent<Image>();
    }

    void mySelect(SelectEnterEventArgs args)
    {
        if ((!isRoot) & (isSummary) & (parent.activeSelf))
        {
            line.SetActive(true);
            if (!hasChild)
            {
                parentLine.SetActive(true);
            }
        }
            
        
        pinched = true;
    }
    void myRelease(SelectExitEventArgs args)
    {
        if ((!isRoot) & (isSummary))
        {
            line.SetActive(false);
            if (!hasChild)
            {
                parentLine.SetActive(false);
            }
        }
        pinched = false;
        buttonOn = false;
        pinchMove = 0;
        timer=0;
        myImage.fillAmount = 0;
        progressCircle.SetActive(false);
        bPanel.SetActive(false);
    }
    public void PassValueToSumButton()
    {
        SumButton.p_sumOrPara = sumOrPara;
        SumButton.p_original = gameObject;
    }
    public void PassValueToParaButton()
    {
        ParaButton.p_sumOrPara = sumOrPara;
        ParaButton.p_original = gameObject;
    }
    public void PassValueToCloseButton()
    {
        CloseButton.p_original = gameObject;
    }
    public void PassValueToChildrenButton()
    {
        ChildrenButton.p_children = children;
        ChildrenButton.p_original = gameObject;
    }
    
    private void Update()
    {
        if (pinched)
        {
            curPinchPos = new Vector3(SceneManager.pinchPos.x, SceneManager.pinchPos.y, SceneManager.pinchPos.z);

            if ((timer > 2) & (pinchMove<0.2) & (!buttonOn))
            { 
               buttonOn = true;
               bPanel.SetActive(true);
               myImage.fillAmount = 0;
               progressCircle.SetActive(false);
               
               
               if (!isRoot)
               {
                   bClose.SetActive(true);
               }
               else
               {
                   bClose.SetActive(false);
               }
               
               if (hasChild)
               {
                   bChildren.SetActive(true);
               }
               else
               {
                   bChildren.SetActive(false);
               }

               if (!noContent)
               {
                   if (!isSummary)
                   {
                       bSum.SetActive(true);
                       bPara.SetActive(false);
                   }
                   else
                   {
                       bPara.SetActive(true);
                       bSum.SetActive(false);
                   }
               }
               else
               {
                   bPara.SetActive(false);
                   bSum.SetActive(false);
               }
               
               
               if ((hasChild) | (!isRoot))
               {
                   bRearrange.SetActive(true);
               }
               else
               {
                   bRearrange.SetActive(false);
               }
               

               // debugText.text = "Triggered";

               // bSummary.transform.rotation = SceneManager.pinchRot;

               // bSummary.GetComponent<Image>().enabled = true;
               // bSummary.GetComponent<XRSimpleInteractable>().enabled = true;

               // debugText.text = "Done! frameCount: " + frameCount.ToString() + " pinchMove: " + pinchMove.ToString();
            }
           else if ((timer <= 2) & (timer > 0) & (pinchMove < 0.2))
           {
               // progressCircle.SetActive(true);
               pinchMove += Vector3.Distance(prePinchPos, curPinchPos);
               myImage.fillAmount = (float) timer / 2;
               updatePos(progressCircle);
               timer += Time.deltaTime;
               // debugText.text = "on timer ++";
               // debugText.text = "In! frameCount: " + frameCount.ToString() + " pinchMove: " + pinchMove.ToString();
           }
           else if (timer == 0)
            { 
                progressCircle.SetActive(true);
                timer += Time.deltaTime;
               // debugText.text = "Start! frameCount: " + frameCount.ToString() +"prePinchPos" + prePinchPos.ToString();
           }
            else
            {
                myImage.fillAmount = 0;
                progressCircle.SetActive(false);
                // debugText.text = "ELSE!!!!";
            }

            if (buttonOn)
            {
                updatePos(bPanel);
                // debugText.text = transform.rotation.eulerAngles.x.ToString();

            }

            prePinchPos = new Vector3(curPinchPos.x, curPinchPos.y, curPinchPos.z);

        }
    }

    private void updatePos(GameObject target)
    {
        target.transform.rotation = transform.rotation;

        if (transform.rotation.eulerAngles.x < 180)
        {
            target.transform.position = new Vector3(transform.position.x, transform.position.y+0.1f, transform.position.z);
        }
        else
        {
            target.transform.position = new Vector3(transform.position.x, transform.position.y-0.1f, transform.position.z);
        }
    }
}
