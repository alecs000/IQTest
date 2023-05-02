using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class IQTestData
{
    [JsonProperty(PropertyName = "data")]
    public List<bool> TestResults = new List<bool>();
}
