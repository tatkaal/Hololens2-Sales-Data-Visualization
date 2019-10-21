using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace InfoDev
{
    public class ScaleNone : Scale
    {
        public ScaleNone(JSONNode scaleSpecs) : base(scaleSpecs) {

        }
        
        public override string ApplyScale(string domainValue)
        {
            return domainValue;
        }
    }
}
