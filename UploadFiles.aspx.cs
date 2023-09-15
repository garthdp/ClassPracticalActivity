using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Ajax.Utilities;

namespace ClassPracticalActivity
{
    public partial class UploadFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string connString = "DefaultEndpointsProtocol=https;AccountName=practicalactivity;AccountKey=n6y4LmPxcg0X5OGXR69qhkrWM2ANL/BvrQn5N9Hb/bHBxUZb5EBnyj/57hYwNa8faLI0ZqSxqENv+AStIq2k9A==;EndpointSuffix=core.windows.net";
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFiles)
            {
                string path = @"C:\Users\garth\OneDrive - ADvTECH Ltd\Year 2\Cloud Development\Semester 2\ClassPracticalActivity\Files\";
                FileUpload.SaveAs(path + FileUpload.FileName);
                Label1.Text = "File Uploaded: " + FileUpload.FileName;
                var files = GetFiles(path);
                if (ddlFileUploadType.SelectedValue != null)
                {
                    Upload(files, connString, ddlFileUploadType.SelectedValue);
                    DeleteFiles(path);
                }
            }
            else
            {
                Label1.Text = "Nothing Uploaded.";
            }
        }
        static IEnumerable<FileInfo> GetFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            return directory.GetFiles();
        }
        static IEnumerable<FileInfo> DeleteFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                dir.Delete(true);
            }
            return directory.GetFiles();
        }
        static void Upload(IEnumerable<FileInfo> files, string connectionString, string fileType)
        {
            void upload(BlobContainerClient client)
            {
                foreach (var file in files)
                {
                    var blobClient = client.GetBlobClient(file.Name);
                    using (var filesStream = File.OpenRead(file.FullName))
                    {
                        blobClient.Upload(filesStream, overwrite:true);
                    }
                    Console.WriteLine(file.Name + " Uploaded");
                    File.Delete(file.FullName);
                }
            }
            BlobContainerClient containerClient;
            if (fileType == "Files")
            {
                containerClient = new BlobContainerClient(connectionString, "activityfiles");
                upload(containerClient);
            }
            else if (fileType == "Videos")
            {
                containerClient = new BlobContainerClient(connectionString, "activityvideos");
                upload(containerClient);
            }
            else if (fileType == "Pictures")
            {
                containerClient = new BlobContainerClient(connectionString, "activitypictures");
                upload(containerClient);
            }
        }
    }
}