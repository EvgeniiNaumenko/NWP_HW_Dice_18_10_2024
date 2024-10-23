namespace WinFormsApp1_HW_18_10_2024
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ChangeModeButton = new Button();
            ThrowButton = new Button();
            label1 = new Label();
            ModeLable = new Label();
            DiceImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DiceImage).BeginInit();
            SuspendLayout();
            // 
            // ChangeModeButton
            // 
            ChangeModeButton.Location = new Point(34, 42);
            ChangeModeButton.Name = "ChangeModeButton";
            ChangeModeButton.Size = new Size(159, 33);
            ChangeModeButton.TabIndex = 0;
            ChangeModeButton.Text = "Change Mode";
            ChangeModeButton.UseVisualStyleBackColor = true;
            ChangeModeButton.Click += ChangeModeButton_Click;
            // 
            // ThrowButton
            // 
            ThrowButton.Location = new Point(34, 261);
            ThrowButton.Name = "ThrowButton";
            ThrowButton.Size = new Size(159, 43);
            ThrowButton.TabIndex = 1;
            ThrowButton.Text = "Throw";
            ThrowButton.UseVisualStyleBackColor = true;
            ThrowButton.Click += ThrowButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 19);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 2;
            label1.Text = "Game Mode:";
            // 
            // ModeLable
            // 
            ModeLable.AutoSize = true;
            ModeLable.Location = new Point(134, 19);
            ModeLable.Name = "ModeLable";
            ModeLable.Size = new Size(59, 20);
            ModeLable.TabIndex = 3;
            ModeLable.Text = "Pl vs PC";
            // 
            // DiceImage
            // 
            DiceImage.Image = (Image)resources.GetObject("DiceImage.Image");
            DiceImage.Location = new Point(34, 92);
            DiceImage.Name = "DiceImage";
            DiceImage.Size = new Size(155, 155);
            DiceImage.SizeMode = PictureBoxSizeMode.StretchImage;
            DiceImage.TabIndex = 4;
            DiceImage.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 326);
            Controls.Add(DiceImage);
            Controls.Add(ModeLable);
            Controls.Add(label1);
            Controls.Add(ThrowButton);
            Controls.Add(ChangeModeButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DiceImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ChangeModeButton;
        private Button ThrowButton;
        private Label label1;
        private Label ModeLable;
        private PictureBox DiceImage;
    }
}
