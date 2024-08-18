using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MnS_UI_Test_Project.FrameworkLayer.Utility
{
    public class PathHelper
    {
        public static string GetPathToFile(string fileName, string folderName = "")
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            //var fileLocation = $"/{folderName}/{fileName}";
            var fileLocation = "";
            if(string.IsNullOrEmpty(folderName))
            {
                fileLocation = fileName;
            }
            else fileLocation = Path.Combine(folderName, fileName);

            var fullPath = Path.Combine(currentDirectory, fileLocation);
            return fullPath;
        }
    }
}
