using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Structure",menuName ="BuildSystem/Structure")]
public class Structure : ScriptableObject
{
    public string structureName;
    [TextArea(3,4)] public string structureDescription;
    public int structureHealth;
    public int structureDurability;
    public int structureID;
    public int PreviewID;
    public int socketID;
    public bool isOnlySocket;

    public GameObject completedPrefab;
}
