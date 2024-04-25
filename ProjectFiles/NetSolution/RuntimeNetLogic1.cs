#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using System.Linq;
using System.Collections.Generic;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {   
        //Get container to hold labels
        ColumnLayout targetContainer = Owner.Get<ColumnLayout>("VerticalLayout1");
        
        //Get variables
        var variableNode = Owner.GetVariable("VariableToPopulate");
        var variableToUse= InformationModel.GetVariable(variableNode.Value);
        var variableDataType = InformationModel.Get(variableToUse.DataType).BrowseName;

        //Create List                       
        var variableList = new List<RemoteVariable>()
        {
            new RemoteVariable(variableToUse),
        };

        //Read current values and add to list
        var variableValues = InformationModel.RemoteRead(variableList).ToList();

        //Create labels and add to containter based on data type
        int index = 0;

        switch(variableDataType)
        {
            case "String":
                var variableArrayString = (string[])variableValues[0].Value.Value;
                
                foreach (string arrayElementString in variableArrayString)
                {
                    var newLabel = InformationModel.Make<Label>("Label"+ index);
                    newLabel.Text = arrayElementString;
                    targetContainer.Add(newLabel);
                    index ++;

                }
                break;

            case "Boolean":
                var variableArrayBool = (bool[])variableValues[0].Value.Value;

                foreach (bool arrayElementBool in variableArrayBool)
                {
                    var newLabel = InformationModel.Make<Label>($"Label"+ index);
                    newLabel.Text = arrayElementBool.ToString();
                    targetContainer.Add(newLabel);
                    index ++;
                }
                break;
            
            case "Int16":
                var variableArrayInt16 = (Int16[])variableValues[0].Value.Value;

                foreach (Int16 arrayElementInt16 in variableArrayInt16)
                {
                    var newLabel = InformationModel.Make<Label>("Label"+ index);
                    newLabel.Text = arrayElementInt16.ToString();
                    targetContainer.Add(newLabel);
                    index ++;
                }
                break;

            case "Int32":
                var variableArrayInt32 = (Int32[])variableValues[0].Value.Value;

                foreach (Int32 arrayElementInt32 in variableArrayInt32)
                {
                    var newLabel = InformationModel.Make<Label>("Label"+index);
                    newLabel.Text = arrayElementInt32.ToString();
                    targetContainer.Add(newLabel);
                    index++;
                }
                break;   

            case "Float":
                var variableArrayFloat = (Double[])variableValues[0].Value.Value;

                foreach (Double arrayElementFloat in variableArrayFloat)
                {
                    var newLabel = InformationModel.Make<Label>("Label"+index);
                    newLabel.Text = arrayElementFloat.ToString();
                    targetContainer.Add(newLabel);
                    index++;
                }
                break;                              
        }

      

    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

}
