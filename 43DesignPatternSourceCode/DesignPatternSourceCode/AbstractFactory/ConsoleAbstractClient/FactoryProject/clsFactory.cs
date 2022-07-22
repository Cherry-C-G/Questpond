using System;
using System.Collections.Generic;
using System.Text;
using InterfaceUI;
using TextProject;
using ButtonProject;
namespace FactoryProject
{
    public abstract class clsAbstractFactory 
    {
        static public InterfaceRender getUIObject(int intTypeOfObject)
        {
            if (intTypeOfObject == 1)
            {
                return clsFactoryTextBox.getTextBoxObject();
            }
            else
            {
                return clsFactoryButton.getButtonObject();
            }

        }
    }
    public class clsFactoryButton : clsAbstractFactory
    {
        static public InterfaceRender getButtonObject()
        {
            return new clsButton();
        }
    }
    public class clsFactoryTextBox : clsAbstractFactory
    {
        static public InterfaceRender getTextBoxObject()
        {
            return new clsTextBox();
        }
    }
}
