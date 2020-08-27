using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class BaseQuestionEntity
{
    public string name;
    [JsonProperty("id")]
    public int ID;
    [JsonProperty("question")]
    public string Question;
    [JsonProperty("answer")]
    public string Answer;
    [JsonProperty("category")]
    public int CategoryID;
    [JsonProperty("maxHt")]
    public int MaxAutoHint;
    [JsonProperty("posMode")]
    public int Priority;
    [JsonProperty("SimiWords")]
    public List<string> SimiWords;
    [JsonProperty("wordSpit")]
    public string wordSpit;
}
