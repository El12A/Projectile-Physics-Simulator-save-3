using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class DropdownController : VariableControllerInput
{
    [SerializeField] private TMP_Dropdown dropdown1;
    [SerializeField] private TMP_Dropdown dropdown2;
    [SerializeField] private TMP_Dropdown dropdown3;

    private List<string> availableOptions1;
    private List<string> availableOptions2;
    private List<string> availableOptions3;

    private int index;


    protected override void Start()
    {
        Begin();
        Debug.Log("child start");
        // Initialize available options
        availableOptions1 = new List<string> { "Initial Velocity", "Displacement", "Time" };
        availableOptions2 = new List<string> { "Final Velocity", "Displacement", "Time" };
        availableOptions3 = new List<string> { "Acceleration", "Displacement", "Time" };
        // Update dropdown options
        UpdateDropdownOptions();
    }

    // Update options for all dropdowns
    private void UpdateDropdownOptions()
    {
        dropdown1.ClearOptions();
        dropdown1.AddOptions(new List<string>(availableOptions1));

        dropdown2.ClearOptions();
        dropdown2.AddOptions(new List<string>(availableOptions2));

        dropdown3.ClearOptions();
        dropdown3.AddOptions(new List<string>(availableOptions3));
    }

    // Update available options based on selection in any dropdown
    public void OnAnyDropdownValue1Changed()
    {

        index = dropdown1.value;
        Swap(availableOptions1);
        AddAndRemoveFromList(availableOptions1);
        UpdateDropdownOptions();
        
        // call function to activate the inputfield for the variable selected
        base.SetInputActive(0, dropdown1.options[dropdown1.value].text);
    }
    public void OnAnyDropdownValue2Changed()
    {
        index = dropdown2.value;
        Swap(availableOptions2);
        AddAndRemoveFromList(availableOptions2);
        UpdateDropdownOptions();

        // call function to activate the inputfield for the variable selected
        base.SetInputActive(1, dropdown2.options[dropdown2.value].text);
    }
    public void OnAnyDropdownValue3Changed()
    {
        index = dropdown3.value;
        Swap(availableOptions3);
        AddAndRemoveFromList(availableOptions3);
        UpdateDropdownOptions();

        // call function to activate the inputfield for the variable selected
        base.SetInputActive(2, dropdown3.options[dropdown3.value].text);
    }

    // Remove selected options from other dropdowns
    private void Swap(List<string> options)
    {
        string temp = options[0];
        options[0] = options[index];
        options[index] = temp;
    }

    private void AddAndRemoveFromList(List<string> KeyList)
    {
        List<List<string>> optionsList = new List<List<string>> { availableOptions1, availableOptions2, availableOptions3 };
        foreach (List<string> list in optionsList)
        {
            if (list != KeyList)
            {
                list.Add(KeyList[index]);
                list.Remove(KeyList[0]);
            }
        }
    }

}