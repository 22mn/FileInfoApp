using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf = System.Windows.Forms;

// Navisworks API References
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.DocumentParts;

namespace FileInfoApp
{
    // plugin attribute require Name , DeveloperID and optional parameters
    [PluginAttribute("FileInfo", "TwentyTwo", DisplayName = "FileInfoSample", ToolTip = "a tutorial project by TwentyTwo")]

    public class MainClass : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            // get document from application
            Document document = Application.ActiveDocument;
            // info message - current file path with appended files
            string message = "Current File : " + document.CurrentFileName + 
                              "\nAppend File : " ;
            // get appended models from current document
            DocumentModels models = document.Models;
            // each model
            foreach(Model model in models)
            {
                // get filepath with index
                message += "\n         "+ (models.IndexOf(model)+1).ToString() +". "+ model.FileName;
            }
            // display message
            wf.MessageBox.Show(message);
            // int return
            return 0;
        }
    }
}
