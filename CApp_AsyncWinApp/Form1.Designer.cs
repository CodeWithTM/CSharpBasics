namespace CApp_AsyncWinApp
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.resultWindow = new System.Windows.Forms.RichTextBox();
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAwait = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(285, 17);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(192, 23);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Normal Execution";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(285, 53);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(192, 23);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "Async Execution";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // resultWindow
            // 
            this.resultWindow.Location = new System.Drawing.Point(12, 156);
            this.resultWindow.Name = "resultWindow";
            this.resultWindow.Size = new System.Drawing.Size(776, 282);
            this.resultWindow.TabIndex = 2;
            this.resultWindow.Text = "";
            // 
            // downloadProgress
            // 
            this.downloadProgress.Location = new System.Drawing.Point(13, 119);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(775, 23);
            this.downloadProgress.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(285, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(192, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAwait
            // 
            this.btnAwait.Location = new System.Drawing.Point(285, 480);
            this.btnAwait.Name = "btnAwait";
            this.btnAwait.Size = new System.Drawing.Size(192, 23);
            this.btnAwait.TabIndex = 5;
            this.btnAwait.Text = "configure await";
            this.btnAwait.UseVisualStyleBackColor = true;
            this.btnAwait.Click += new System.EventHandler(this.btnAwait_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 533);
            this.Controls.Add(this.btnAwait);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.downloadProgress);
            this.Controls.Add(this.resultWindow);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnSync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.RichTextBox resultWindow;
        private System.Windows.Forms.ProgressBar downloadProgress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAwait;
    }
}

