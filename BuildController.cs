using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public Structure[] structures;
    public GameObject[] previews;
    private Structure currentStructure;
    private GameObject currentPreview;
    public GameObject objectPrefab;
    public GameObject objectPreview;
    DetectCollider detectCollider;
    [SerializeField] Material WhiteMaterial;
    [SerializeField] Material RedMaterial;
    Color redColor=new Color32( 255, 90, 105, 83 );
    Color whiteColor=new Color32( 255, 255, 255, 118 );
    RaycastHit hit;
    Transform socket;
    private bool canBuild;

    private void Awake()
    {
        currentStructure = structures[0];
        currentPreview = previews[0];
        CloseAllPreviews();
        currentPreview.SetActive(true);
        detectCollider = currentPreview.GetComponent<DetectCollider>();
    }

    private void Update()
    {
        HandleInput();
        Raycasting();

    }

    private void Raycasting()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5f))
        {

            if (!detectCollider.GetIsDetect())
            {
                canBuild = true;
            }
            else
            {
                if (hit.transform.GetComponent<Socket>())
                {
                    canBuild = true;
                }
                else
                {
                    Debug.Log("Cant build");
                    SetPreviewColor(redColor);
                    canBuild = false;
                }
            }

            if (currentStructure.isOnlySocket)
            {
                if (hit.transform.gameObject.GetComponent<Socket>())
                {
                    if (hit.transform.gameObject.GetComponent<Socket>().socketID == currentStructure.socketID)
                    {
                        if (canBuild)
                        {
                            socket = hit.transform;
                            SetPreviewColor(whiteColor);
                            currentPreview.transform.localPosition = socket.transform.position;
                            currentPreview.transform.localRotation = socket.transform.rotation;
                            if (Input.GetMouseButtonDown(0))
                            {
                                GameObject spawnedObject = Instantiate(currentStructure.completedPrefab, socket.transform.position, socket.transform.rotation);
                                spawnedObject.GetComponent<StructureModel>().Setup(currentStructure.structureName,
                                                                                   currentStructure.structureHealth,
                                                                                   currentStructure.structureDurability,
                                                                                   currentStructure.structureID,
                                                                                   currentStructure.PreviewID,
                                                                                   currentStructure.socketID,
                                                                                   currentStructure.isOnlySocket);
                            }
                        }
                        else
                        {
                            SetPreviewColor(redColor);
                        }
                    }
                }
            }
            else if (!currentStructure.isOnlySocket)
            {
                if (hit.transform.GetComponent<Socket>())
                {
                    if (hit.transform.gameObject.GetComponent<Socket>().socketID == currentStructure.socketID)
                    {
                        if (canBuild)
                        {
                            socket = hit.transform;
                            SetPreviewColor(whiteColor);
                            currentPreview.transform.localPosition = socket.transform.position;
                            currentPreview.transform.localRotation = socket.transform.rotation;
                            if (Input.GetMouseButtonDown(0))
                            {
                                GameObject spawnedObject = Instantiate(currentStructure.completedPrefab, socket.transform.position, socket.transform.rotation);
                                spawnedObject.GetComponent<StructureModel>().Setup(currentStructure.structureName,
                                                                                   currentStructure.structureHealth,
                                                                                   currentStructure.structureDurability,
                                                                                   currentStructure.structureID,
                                                                                   currentStructure.PreviewID,
                                                                                   currentStructure.socketID,
                                                                                   currentStructure.isOnlySocket);
                                foreach (Transform child in spawnedObject.transform)
                                {
                                    if (child.GetComponent<Socket>())
                                    {
                                        child.GetComponent<Socket>().CheckOtherSockets();
                                    }
                                }
                            }
                        }
                        else
                        {
                            SetPreviewColor(redColor);
                        }
                    }
                }
                else
                {
                    currentPreview.transform.localPosition = hit.point;
                    if (currentStructure.structureID != 2)
                    {
                        currentPreview.transform.forward = transform.forward;
                    }
                    if (canBuild)
                    {
                        SetPreviewColor(whiteColor);
                        if (Input.GetMouseButtonDown(0))
                        {
                            GameObject spawnedObject = Instantiate(currentStructure.completedPrefab, hit.point, currentPreview.transform.localRotation);
                            spawnedObject.GetComponent<StructureModel>().Setup(currentStructure.structureName,
                                                                                   currentStructure.structureHealth,
                                                                                   currentStructure.structureDurability,
                                                                                   currentStructure.structureID,
                                                                                   currentStructure.PreviewID,
                                                                                   currentStructure.socketID,
                                                                                   currentStructure.isOnlySocket);
                        }
                    }
                    else
                    {
                        SetPreviewColor(redColor);
                    }

                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Camera.main.gameObject.transform.position, hit.point);
    }

    private void SetPreviewColor(Color tempColor)
    {
        if (!currentPreview.GetComponent<Renderer>())
        {
            if (currentPreview.GetComponentInChildren<Renderer>().materials.Length > 1)
            {

                currentPreview.GetComponentInChildren<Renderer>().materials[0].color = tempColor;
                currentPreview.GetComponentInChildren<Renderer>().materials[1].color = tempColor;
                currentPreview.GetComponentInChildren<Renderer>().materials[2].color = tempColor;
            }
            else
            {
                currentPreview.GetComponentInChildren<Renderer>().material.color = tempColor;
            }
        }
        else
        {
            if (currentPreview.GetComponent<Renderer>().materials.Length > 1)
            {

                currentPreview.GetComponent<Renderer>().materials[0].color = tempColor;
                currentPreview.GetComponent<Renderer>().materials[1].color = tempColor;
                currentPreview.GetComponent<Renderer>().materials[2].color = tempColor;
            }
            else
            {

                currentPreview.GetComponent<Renderer>().material.color = tempColor;
            }
        }
    }

    private void HandleInput()
    {
        for (int i = 0; i < structures.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                CloseAllPreviews();
                currentStructure = structures[i];
                currentPreview = previews[currentStructure.PreviewID];
                currentPreview.SetActive(true);
                detectCollider = currentPreview.GetComponent<DetectCollider>();
            }
        }
    }

    private void CloseAllPreviews()
    {
        foreach (var preview in previews)
        {
            preview.SetActive(false);
        }
    }
}
