/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using Microsoft.MixedReality.Toolkit.UI;

[System.Serializable]
public class TransactionData
{
    public string scanCode;
    public string description;
    public string department;
    public int qty;
    public float cost;
    public float retail;
    public float posCost;
    public float posRetail;
    public float margin;
    public float profit;
    public int tranID;
    public string date;
    public string time;
    public int xpos;
    public int ypos;
}

[System.Serializable]
class TransactionsData
{
    public List<TransactionData> transactions;

    public static TransactionsData FromJSON(string json)
    {
        return JsonUtility.FromJson<TransactionsData>(json);
    }
}


public class UpdateInputField : MonoBehaviour
{
    public InputField mainInputField;
    private Calendar calendar;
    private GameObject dateCanvas;
    private GameObject testCanvas;
    public int dayNumb;
    public string sendVal, path;

    public Transform Parent;
    public GameObject DepartmentPrefab;
    public float DepartmentSeperationDistance;
    //public GridObjectCollection Collection;
    private bool isFirstRun = true;

    public Material MatCigDepartment;
    public Material MatBeerDepartment;
    public Material MatTobaccoDepartment;
    public Material MatGiftDepartment;

    void Start()
    {
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

    public void getVal(string val)
    {
        if (dayNumb != 0)
        {
            sendVal = calendar.ReturnDate(dayNumb);
            Debug.LogWarning(sendVal);
            testCanvasEnabled(false);
            dateCanvasEnabled(false);
            path = "JSON/sales";
            InitializeData(path);
        }


        //dataset load
        //date include vako data reterieve garne json ma
        //number of data jati aucha teti ota box banauna paryo

    }

    public void InitializeData(string path)
    {
        TextAsset asset = Resources.Load<TextAsset>(path);
        List<TransactionData> transactions = TransactionsData.FromJSON(asset.text).transactions;

        Dictionary<string, Material> typeMaterials = new Dictionary<string, Material>()
        {
            {"Cigarette Department", MatCigDepartment},
            {"Beer Department", MatBeerDepartment},
            {"Tobacco Department", MatTobaccoDepartment},
            {"Gift Items department", MatGiftDepartment}
        };


        if (isFirstRun == true)
        {
            // Insantiate the element prefabs in their correct locations and with correct text
            foreach (TransactionData transaction in transactions)
            {
                GameObject newElement = Instantiate<GameObject>(DepartmentPrefab, Parent);
                newElement.GetComponentInChildren<Department>().SetFromElementData(transaction, typeMaterials);
                newElement.transform.localPosition = new Vector3(transaction.xpos * DepartmentSeperationDistance - DepartmentSeperationDistance * 18 / 2, DepartmentSeperationDistance * 9 - transaction.ypos * DepartmentSeperationDistance, 2.0f);
                newElement.transform.localRotation = Quaternion.identity;
            }

            isFirstRun = false;
        }
        else
        {
            int i = 0;
            // Update position and data of existing element objects
            foreach (Transform existingElementObject in Parent)
            {
                existingElementObject.parent.GetComponentInChildren<Department>().SetFromElementData(transactions[i], typeMaterials);
                existingElementObject.localPosition = new Vector3(transactions[i].xpos * DepartmentSeperationDistance - DepartmentSeperationDistance * 18 / 2, DepartmentSeperationDistance * 9 - transactions[i].ypos * DepartmentSeperationDistance, 2.0f);
                existingElementObject.localRotation = Quaternion.identity;
                i++;
            }
            Parent.localPosition = new Vector3(0.0f, -0.7f, 0.7f);
        }
    }


    public void dateCanvasEnabled(bool canvasbool)
    {
        dateCanvas.SetActive(canvasbool);
    }
    public void testCanvasEnabled(bool canvasbool)
    {
        testCanvas.SetActive(canvasbool);
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using Microsoft.MixedReality.Toolkit.UI;

public class UpdateInputField2 : MonoBehaviour
{
    public InputField mainInputField;
    private Calendar calendar;
    private GameObject dateCanvas;
    private GameObject testCanvas;
    public int dayNumb;
    public string sendVal, path;

    void Start()
    {
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

    public void getVal(string val)
    {
        if (dayNumb != 0)
        {
            sendVal = calendar.ReturnDate(dayNumb);
            Debug.LogWarning(sendVal);
            testCanvasEnabled(false);
            dateCanvasEnabled(false);
        }


        //dataset load
        //date include vako data reterieve garne json ma
        //number of data jati aucha teti ota box banauna paryo

    }


    public void dateCanvasEnabled(bool canvasbool)
    {
        dateCanvas.SetActive(canvasbool);
    }
    public void testCanvasEnabled(bool canvasbool)
    {
        testCanvas.SetActive(canvasbool);
    }
}