using System;
using System.IO;
namespace ghoster
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                //this.notifyIcon1.Icon = null;
                this.notifyIcon1.Dispose(); //we dispose our tray icon here
            }


            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);


            if (disposing)
            {
                clearIECache();
                //   WebBrowserHelper.ClearCache();
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion


        /// <summary>
        /// Clears the Internet Explorer cache folder (Temporary Internet Files)
        /// </summary>
        void clearIECache()
        {
            // Clear the special cache folder
            ClearFolder(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)));
        }

        /// <summary>
        /// Deletes all the files within the specified folder
        /// </summary>
        /// The folder from which we wish to delete all of the files
        void ClearFolder(DirectoryInfo folder)
        {
            // Iterate each file
            foreach (FileInfo file in folder.GetFiles())
            {
                try
                {
                    // Delete the file, ignoring any exceptions
                    file.Delete();
                }
                catch (Exception)
                {
                }
            }

            // For each folder in the specified folder
            foreach (DirectoryInfo subfolder in folder.GetDirectories())
            {
                // Clear all the files in the folder
                ClearFolder(subfolder);
            }
        }
    
    
    }
}

