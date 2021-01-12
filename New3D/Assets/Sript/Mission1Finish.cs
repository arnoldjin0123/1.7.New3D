using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionData", menuName = "MisionData/Mission1Finish")]

public class Mission1Finish : ScriptableObject
{
    [Header("Daiolouge 1"), TextArea(1, 10)]
    public string Daiolouge1;
    [Header("Daiolouge 2"), TextArea(1, 10)]
    public string Daiolouge2;
    [Header("Daiolouge 3"), TextArea(1, 10)]
    public string Daiolouge3;
}
