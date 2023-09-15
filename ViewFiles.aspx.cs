using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClassPracticalActivity
{
    public partial class ViewFiles : System.Web.UI.Page
    {
        public string connString = "DefaultEndpointsProtocol=https;AccountName=practicalactivity;AccountKey=n6y4LmPxcg0X5OGXR69qhkrWM2ANL/BvrQn5N9Hb/bHBxUZb5EBnyj/57hYwNa8faLI0ZqSxqENv+AStIq2k9A==;EndpointSuffix=core.windows.net";
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ddlFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            void getFiles(BlobContainerClient client)
            {
                lbFiles.Items.Clear();
                var Items = client.GetBlobs();
                foreach (BlobItem item in Items)
                {
                    lbFiles.Items.Add(item.Name);
                }
                if(lbFiles.Items.Count == 0)
                {
                    lbFiles.Items.Add("No files found.");
                }
            }
            BlobContainerClient containerClient;
            if (ddlFileType.SelectedValue == "Files")
            {
                containerClient = new BlobContainerClient(connString, "activityfiles");
                getFiles(containerClient);
            }
            else if (ddlFileType.SelectedValue == "Videos")
            {
                containerClient = new BlobContainerClient(connString, "activityvideos");
                getFiles(containerClient);
            }
            else if (ddlFileType.SelectedValue == "Pictures")
            {
                containerClient = new BlobContainerClient(connString, "activitypictures");
                getFiles(containerClient);
            }
        }
    }
}