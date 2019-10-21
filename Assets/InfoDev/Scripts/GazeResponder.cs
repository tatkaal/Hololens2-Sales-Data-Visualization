// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

// This example is built from HoloToolkit examples package.

using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

namespace InfoDev
{
    /// <summary>
    /// This class implements IFocusable to respond to gaze changes.
    /// It highlights the object being gazed at.
    /// </summary>
    public class GazeResponder : MonoBehaviour, IMixedRealityFocusHandler
    {
        private Material[] defaultMaterials;

        private void Start()
        {
            defaultMaterials = GetComponent<Renderer>().materials;
        }

        public void OnFocusEnter(FocusEventData Mark)
        {
            Mark mark = gameObject.GetComponent<Mark>();
            if(mark != null)
            {
                mark.OnFocusEnter();
            } 
        }

        public void OnFocusExit(FocusEventData Mark)
        {
            Mark mark = gameObject.GetComponent<Mark>();
            if (mark != null)
            {
                mark.OnFocusExit();
            }
        }

        private void OnDestroy()
        {
            
        }
    }
}