//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.MRDL.PeriodicTable
{
    [System.Serializable]
    public class TransactionData
    {
        // public string name;
        // public string category;
        // public string spectral_img;
        // public int xpos;
        // public int ypos;
        // public string named_by;
        // public float density;
        // public string color;
        // public float molar_heat;
        // public string symbol;
        // public string discovered_by;
        // public string appearance;
        // public float atomic_mass;
        // public float melt;
        // public string number;
        // public string source;
        // public int period;
        // public string phase;
        // public string summary;
        // public int boil;

        public string Description;
        public float Total_Profit;
        public int Total_Quantity;
        public int Total_Transaction;
        public string Department;
        public string Product_Description;
        public int xpos;
        public int ypos; 
    }

    [System.Serializable]
    class TransactionsData
    {
        public List<TransactionData> elements;

        public static TransactionsData FromJSON(string json)
        {
            return JsonUtility.FromJson<TransactionsData>(json);
        }
    }

    public class TransactionTableLoader : MonoBehaviour
    {
        // What object to parent the instantiated elements to
        public Transform Parent;

        // Generic element prefab to instantiate at each position in the table
        public GameObject ElementPrefab;

        // How much space to put between each element prefab
        public float ElementSeperationDistance;

        public GridObjectCollection Collection;

        public Material MatCigarette;
        // public Material MatAlkalineEarthMetal;
        // public Material MatTransitionMetal;
        // public Material MatMetalloid;
        // public Material MatDiatomicNonmetal;
        // public Material MatPolyatomicNonmetal;
        // public Material MatPostTransitionMetal;
        // public Material MatNobleGas;
        // public Material MatActinide;
        // public Material MatLanthanide;

        private string DepName;

        private bool isFirstRun = true;

        private void Start()
        {
            InitializeData();
        }


        public void InitializeData()
        {
            //if (Collection.transform.childCount > 0)
            //    return;

            //Parse the elements out of the json file
            DepName = GlobalControl.sendValFunc;
            Debug.LogWarning("Clicked Department is :" + DepName);


            TextAsset asset = Resources.Load<TextAsset>("JSON/Cigarettes");
            List<TransactionData> elements = TransactionsData.FromJSON(asset.text).elements;

            Dictionary<string, Material> typeMaterials = new Dictionary<string, Material>()
        {
            { "Cigarettes", MatCigarette },
            // { "alkaline earth metal", MatAlkalineEarthMetal },
            // { "transition metal", MatTransitionMetal },
            // { "metalloid", MatMetalloid },
            // { "diatomic nonmetal", MatDiatomicNonmetal },
            // { "polyatomic nonmetal", MatPolyatomicNonmetal },
            // { "post-transition metal", MatPostTransitionMetal },
            // { "noble gas", MatNobleGas },
            // { "actinide", MatActinide },
            // { "lanthanide", MatLanthanide },
        };


            if (isFirstRun == true)
            {
                // Insantiate the element prefabs in their correct locations and with correct text
                foreach (TransactionData element in elements)
                {
                    GameObject newElement = Instantiate<GameObject>(ElementPrefab, Parent);
                    newElement.GetComponentInChildren<Transaction>().SetFromElementData(element, typeMaterials);
                    newElement.transform.localPosition = new Vector3(element.xpos - ElementSeperationDistance * 6 / 2, ElementSeperationDistance * 6 - element.ypos * ElementSeperationDistance, 2.0f);
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
                    existingElementObject.parent.GetComponentInChildren<Transaction>().SetFromElementData(elements[i], typeMaterials);
                    existingElementObject.localPosition = new Vector3(elements[i].xpos - ElementSeperationDistance * 6 / 2, ElementSeperationDistance * 6 - elements[i].ypos * ElementSeperationDistance, 2.0f);
                    existingElementObject.localRotation = Quaternion.identity;
                    i++;
                }
                Parent.localPosition = new Vector3(0.0f, -0.7f, 0.7f);
            }

        }
    }
}