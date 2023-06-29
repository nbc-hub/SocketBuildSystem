using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureModel : MonoBehaviour
{
    [SerializeField]private string structureName;
    [SerializeField]private int structureHealth;
    [SerializeField]private int structureDurability;
    [SerializeField]private int structureID;
    [SerializeField]private int PreviewID;
    [SerializeField]private int socketID;
    [SerializeField]private bool isOnlySocket;

    public void Setup(string structureName,int structureHealth,int structureDurability,int structureID,int PreviewID,int socketID,bool isOnlySocket){
        this.structureName=structureName;
        this.structureHealth=structureHealth;
        this.structureDurability=structureDurability;
        this.structureID=structureID;
        this.PreviewID=PreviewID;
        this.socketID=socketID;
        this.isOnlySocket=isOnlySocket;
    }

    public int GetStructureID(){
        return structureID;
    }
}
