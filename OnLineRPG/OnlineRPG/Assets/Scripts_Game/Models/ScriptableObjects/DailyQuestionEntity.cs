using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class DailyQuestionEntity : BaseQuestionEntity
{
    [JsonProperty("priority")]
    public int ProbabilityID;
}
