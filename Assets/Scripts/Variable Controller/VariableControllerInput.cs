using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class VariableControllerInput : MonoBehaviour
{
    [SerializeField] private GameObject singleInputPrefab;
    [SerializeField] private GameObject vector3InputPrefab;
    [SerializeField] private Transform parentTransform;
    private Vector3 spawnPosition;
    protected List<GameObject> spawnList;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    protected virtual void Begin()
    {
        Debug.Log("parent start");
        spawnList = new List<GameObject>();
        spawnNewInputField(vector3InputPrefab, new Vector3(790, 300, 0), 0);
        spawnNewInputField(vector3InputPrefab, new Vector3(790, 200, 0), 1);
        spawnNewInputField(vector3InputPrefab, new Vector3(790, 100, 0), 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void SetInputActive(int dropdownNum, string variable)
    {
        Debug.Log("count before:" + spawnList.Count);
        if (dropdownNum == 0)
        {
            spawnPosition = new Vector3(790, 300, 0);
        }
        else if (dropdownNum == 1)
        {
            spawnPosition = new Vector3(790, 200, 0);
        }
        else if (dropdownNum == 2)
        {
            spawnPosition = new Vector3(790, 100, 0);
        }

        int index = dropdownNum;

        if (variable == "Time")
        {
            spawnPosition.x = spawnPosition.x + 80;
            spawnNewInputField(singleInputPrefab, spawnPosition, dropdownNum);
        }
        else
        {
            
            spawnNewInputField(vector3InputPrefab, spawnPosition, dropdownNum);
        }
    }

    protected void spawnNewInputField(GameObject inputPrefab, Vector3 spawnPos, int index)
    {
        Debug.Log("Count" + spawnList.Count);
        if (spawnList.Count > 2)
        {
            Debug.Log("too many");
            Destroy(spawnList[index]);
            spawnList.RemoveAt(index);
        }
        Debug.Log("index" + index);
        GameObject spawnedInputField = Instantiate(inputPrefab, transform.position, Quaternion.identity);
        spawnedInputField.transform.SetParent(parentTransform);
        spawnedInputField.transform.Translate(spawnPos);
        spawnList.Insert(index, spawnedInputField);
        Debug.Log("Count after" + spawnList.Count);
    }

}
