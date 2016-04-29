namespace Rhydon.SAV
{
    partial class SAV_Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAV_Options));
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.CHK_BattleEffects = new System.Windows.Forms.CheckBox();
            this.CB_BattleStyle = new System.Windows.Forms.ComboBox();
            this.LBL_BattleStyle = new System.Windows.Forms.Label();
            this.LBL_TextSpeed = new System.Windows.Forms.Label();
            this.CB_TextSpeed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_SoundType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(105, 137);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(85, 23);
            this.B_Save.TabIndex = 11;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.Save);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(12, 137);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(85, 23);
            this.B_Cancel.TabIndex = 10;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.Cancel);
            // 
            // CHK_BattleEffects
            // 
            this.CHK_BattleEffects.AutoSize = true;
            this.CHK_BattleEffects.Location = new System.Drawing.Point(68, 22);
            this.CHK_BattleEffects.Name = "CHK_BattleEffects";
            this.CHK_BattleEffects.Size = new System.Drawing.Size(111, 17);
            this.CHK_BattleEffects.TabIndex = 12;
            this.CHK_BattleEffects.Text = "Use Battle Effects";
            this.CHK_BattleEffects.UseVisualStyleBackColor = true;
            // 
            // CB_BattleStyle
            // 
            this.CB_BattleStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BattleStyle.FormattingEnabled = true;
            this.CB_BattleStyle.Location = new System.Drawing.Point(94, 45);
            this.CB_BattleStyle.Name = "CB_BattleStyle";
            this.CB_BattleStyle.Size = new System.Drawing.Size(85, 21);
            this.CB_BattleStyle.TabIndex = 13;
            // 
            // LBL_BattleStyle
            // 
            this.LBL_BattleStyle.AutoSize = true;
            this.LBL_BattleStyle.Location = new System.Drawing.Point(27, 48);
            this.LBL_BattleStyle.Name = "LBL_BattleStyle";
            this.LBL_BattleStyle.Size = new System.Drawing.Size(63, 13);
            this.LBL_BattleStyle.TabIndex = 14;
            this.LBL_BattleStyle.Text = "Battle Style:";
            // 
            // LBL_TextSpeed
            // 
            this.LBL_TextSpeed.AutoSize = true;
            this.LBL_TextSpeed.Location = new System.Drawing.Point(25, 102);
            this.LBL_TextSpeed.Name = "LBL_TextSpeed";
            this.LBL_TextSpeed.Size = new System.Drawing.Size(65, 13);
            this.LBL_TextSpeed.TabIndex = 16;
            this.LBL_TextSpeed.Text = "Text Speed:";
            // 
            // CB_TextSpeed
            // 
            this.CB_TextSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TextSpeed.FormattingEnabled = true;
            this.CB_TextSpeed.Location = new System.Drawing.Point(94, 99);
            this.CB_TextSpeed.Name = "CB_TextSpeed";
            this.CB_TextSpeed.Size = new System.Drawing.Size(85, 21);
            this.CB_TextSpeed.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sound Type:";
            // 
            // CB_SoundType
            // 
            this.CB_SoundType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SoundType.FormattingEnabled = true;
            this.CB_SoundType.Location = new System.Drawing.Point(94, 72);
            this.CB_SoundType.Name = "CB_SoundType";
            this.CB_SoundType.Size = new System.Drawing.Size(85, 21);
            this.CB_SoundType.TabIndex = 17;
            // 
            // SAV_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 176);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_SoundType);
            this.Controls.Add(this.LBL_TextSpeed);
            this.Controls.Add(this.CB_TextSpeed);
            this.Controls.Add(this.LBL_BattleStyle);
            this.Controls.Add(this.CB_BattleStyle);
            this.Controls.Add(this.CHK_BattleEffects);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.B_Cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(220, 215);
            this.MinimumSize = new System.Drawing.Size(220, 215);
            this.Name = "SAV_Options";
            this.Text = "Options Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.CheckBox CHK_BattleEffects;
        private System.Windows.Forms.ComboBox CB_BattleStyle;
        private System.Windows.Forms.Label LBL_BattleStyle;
        private System.Windows.Forms.Label LBL_TextSpeed;
        private System.Windows.Forms.ComboBox CB_TextSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_SoundType;
    }
}