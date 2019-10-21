using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine.SceneManagement;
using HoloToolkit.MRDL.PeriodicTable;

public class UpdateInputField : MonoBehaviour
{
    public InputField mainInputField;
    private Calendar calendar;
    private GameObject dateCanvas;
    private GameObject testCanvas;
    public int dayNumb;
    public string path;
    public string sendVal;
    private string setVal;
    /*public static GlobalControl controller;*/

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        dateCanvas = GameObject.Find("Date Canvas");
        testCanvas = GameObject.Find("TestCanvas");
        if (!dateCanvas)
        {
            Debug.LogWarning("Did not find 'Date Canvas' canvas component!");
        }
        else if (!testCanvas)
        {
            Debug.LogWarning("Did not find 'Test Canvas' canvas component!");
        }

        var allInteractables = GameObject.FindObjectsOfType<Interactable>();
        foreach (var i in allInteractables)
        {
            i.OnClick.AddListener(() => UpdateField(i));
        }
    }

    public void UpdateField(Microsoft.MixedReality.Toolkit.UI.Interactable index)
    {
        dayNumb = GameObject.Find(index.gameObject.name).GetComponent<DayButton>().CurrentNumber();
        calendar = GameObject.FindObjectOfType<Calendar>();
        mainInputField.text = calendar.ReturnDate(dayNumb);
    }

    public void getVal()
    {
        if (dayNumb != 0)
        {
            sendVal = calendar.ReturnDate(dayNumb);
            //Debug.LogWarning(sendVal);

            /*GlobalControl.instance.sendVal = sendVal;*/
            //PeriodicTableLoader testObj = sendVal.AddComponent<PeriodicTableLoader>();
            //PeriodicTableLoader.getSendVal = sendVal;

            testCanvasEnabled(false);
            dateCanvasEnabled(false);
            GlobalControl.sendValFunc = sendVal;
            SceneManager.LoadScene("Department");

            //PeriodicTableLoader.getSendVal = sendVal;



/*          PeriodicTableLoader testobj;
            testobj = gameObject.AddComponent<PeriodicTableLoader>();
            testobj.sendVal = sendVal;
            Debug.LogWarning(testobj.sendVal);*/
        }
        


        //dataset load
        //date include vako data reterieve garne json ma
        //number of data jati aucha teti ota box banauna paryo

    }

   /* public void savePlayer()
    {
        GlobalControl.instance.sendVal = sendVal;
    }*/
    public void dateCanvasEnabled(bool canvasbool)
    {
        dateCanvas.SetActive(canvasbool);
    }
    public void testCanvasEnabled(bool canvasbool)
    {
        testCanvas.SetActive(canvasbool);
    }
}