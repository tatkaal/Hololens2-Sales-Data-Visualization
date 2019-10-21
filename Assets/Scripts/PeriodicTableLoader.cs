//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.MRDL.PeriodicTable
{
    // [System.Serializable]
    // public class ElementDataSec
    // {
    //     public string Scan_Code;
    //     public string Description;
    //     public string Department;
    //     public int Qty;
    //     public float Cost;
    //     public float Retail;
    //     public float POS_Cost;
    //     public float POS_Retail;
    //     public float Margin;
    //     public float Profit;
    //     public int Tran_ID;
    //     public string date;
    //     public string time;
    // }

    [System.Serializable]
    public class ElementData
    {
        public string Department;
        public float Profit;
        public int Quantity;
        public int xpos;
        public int ypos;
        public int zpos;
        public string category;
    }

    // [System.Serializable]
    // class ElementsDataSec
    // {
    //     public List<ElementDataSec> elementsSec;

    //     public static ElementsDataSec FromJSON(string json)
    //     {
    //         return JsonUtility.FromJson<ElementsDataSec>(json);
    //     }
    // }

    [System.Serializable]
    class ElementsData
    {
        public List<ElementData> elements;

        public static ElementsData FromJSON(string json)
        {
            return JsonUtility.FromJson<ElementsData>(json);
        }
    }


    public class PeriodicTableLoader : MonoBehaviour
    {
        // What object to parent the instantiated elements to
        public Transform Parent;

        // Generic element prefab to instantiate at each position in the table
        public GameObject ElementPrefab;
        public SpriteRenderer dImage;

        // How much space to put between each element prefab
        public float ElementSeperationDistance;

        public GridObjectCollection Collection;

        public Material MatElectronicAccessories;
        public Material MatLottery;
        public Material MatHomeAppliances;
        public Material MatClothings;
        public Material MatSnacks;
        public Material MatGroceries;
        public Material MatSmokesAndDrinks;
        public Material MatSweets;
        public Material MatHealthAndBeauty;
        public Material MatOthers;

        private bool isFirstRun = true;
        private string sendVal;
        //public string sendVal;

        private void Start()
        {
            /*GlobalControl controllerObj = new GlobalControl();
            this.sendVal = controllerObj.sendValFunc();*/
            // Debug.LogWarning("This is Global COntroller" + GlobalControl.sendValFunc);
            InitializeData();
            //sendVal = GlobalControl.instance.sendVal;
        }


        public void InitializeData()
        {
            //if (Collection.transform.childCount > 0)
            //    return;

            //Parse the elements out of the json file
            sendVal = GlobalControl.sendValFunc;
            Debug.LogWarning("Date received here is :" + sendVal);

            TextAsset asset = Resources.Load<TextAsset>("JSON/department");
            // TextAsset assetSec = Resources.Load<TextAsset>("JSON/sales");

            List<ElementData> elements = ElementsData.FromJSON(asset.text).elements;
            // List<ElementDataSec> elementsSec = ElementsDataSec.FromJSON(assetSec.text).elementsSec;

            Dictionary<string, Material> typeMaterials = new Dictionary<string, Material>()
        {
            { "Electronics Accessories", MatElectronicAccessories },
            { "Lottery", MatLottery },
            { "Home Appliances", MatHomeAppliances },
            { "Clothings", MatClothings },
            { "Smokes and Drinks", MatSmokesAndDrinks },
            { "Snacks", MatSnacks },
            { "Groceries", MatGroceries },
            { "Sweets", MatSweets },
            { "Health and Beauty", MatHealthAndBeauty },
            { "Others", MatOthers },
        };


            if (isFirstRun == true)
            {
                // Insantiate the element prefabs in their correct locations and with correct text
                foreach (ElementData element in elements)
                {
                    GameObject newElement = Instantiate<GameObject>(ElementPrefab, Parent);
                    newElement.GetComponentInChildren<Element>().SetFromElementData(element, typeMaterials);
                    newElement.transform.localPosition = new Vector3(element.xpos - ElementSeperationDistance * 6 / 2, ElementSeperationDistance * 6 - element.ypos * ElementSeperationDistance, 2.0f);
                    // Sprite test = Resources.Load<Sprite>("Tobacco");
                    // newElement.GetComponentInChildren<Element>().depImage.sprite = test;
                    newElement.transform.localRotation = Quaternion.identity;
                }

                isFirstRun = false;
            }
            else
            {
                int i = 0;
                // Update position and data of existing element objects
                foreach(Transform existingElementObject in Parent)
                {
                    existingElementObject.parent.GetComponentInChildren<Element>().SetFromElementData(elements[i], typeMaterials);
                    existingElementObject.localPosition = new Vector3(elements[i].xpos - ElementSeperationDistance * 6 / 2, ElementSeperationDistance * 6 - elements[i].ypos * ElementSeperationDistance, 2.0f);
                    existingElementObject.localRotation = Quaternion.identity;
                    i++;
                }
                Parent.localPosition = new Vector3(0.0f, -0.7f, 0.7f);
            }

        }
    }
}