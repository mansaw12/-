using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sulakore.Communication;
using Sulakore.Components;
using Sulakore.Habbo;
using Sulakore.Modules;
using Tangine;

namespace fb
{
    [Module("fb", "?_?")]
    [Author("Motive", HabboName = "Motive", Hotel = Sulakore.Habbo.HHotel.Com)]
    public class Form1 : ExtensionForm
    {
        private Dictionary<string, HEntity> Users = new Dictionary<string, HEntity>();
        private IContainer components = (IContainer)null;
        private bool IsStarted;
        private SKoreLabelBox txtUser;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox checkBox2;

        [Obsolete]
        public Form1()
        {
            InitializeComponent();
        }

        [InDataCapture("84c6b9e56653d64d21cd8cf47c4242f1")]
        public void GetRoomUsers(DataInterceptedEventArgs e)
        {
            foreach (HEntity hentity1 in HEntity.Parse(e.Packet))
            {
                HEntity hentity = hentity1;

                if (Users.ContainsKey(hentity.Name))
                    Users.Remove(hentity.Name);
                    Users.Add(hentity.Name, hentity);


            }
        }

        [OutDataCapture("RequestWearingBadges")]
        [Obsolete]
        public void TargetUser(DataInterceptedEventArgs e)
        {
            if (IsStarted)
                return;
            int id = e.Packet.ReadInteger();
            {
                foreach (KeyValuePair<string, HEntity> user in Users)
                
                    if (user.Value.Id == id)
                        txtUser.Value = user.Key;
                }
            } 
     

        [InDataCapture("1d1cb11cb8d5156afeb284fb1eb04339")]
        [Obsolete]
        public async void OnUserStatus(DataInterceptedEventArgs e)
        {
            if (IsStarted)
                return;
            HEntityUpdate[] hentityUpdateArray = HEntityUpdate.Parse(e.Packet);
            for (int index = 1; index < hentityUpdateArray.Length; ++index)
            {
                HEntityUpdate hupdate = hentityUpdateArray[index];
                if (hupdate.Index == Users[txtUser.Value].Index)
                {
                    if (checkBox1.Checked && hupdate.Action == HAction.Move)
                    {
                        int serverAsync4 = await Connection.SendToServerAsync(Out.RoomUserWalk, (object)(hupdate.MovingTo.X - 1), (object)hupdate.MovingTo.Y);
                    }
                }
                hupdate = (HEntityUpdate)null;
            }
            hentityUpdateArray = (HEntityUpdate[])null;
        }

        [Obsolete]

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                TopMost = true;
            else
                TopMost = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        [Obsolete]
        private void InitializeComponent()
        {
            txtUser = new SKoreLabelBox();
            checkBox1 = new CheckBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            checkBox2 = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            txtUser.BackColor = Color.FromArgb(243, 63, 63);
            txtUser.Enabled = false;
            txtUser.Location = new Point(14, 39);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(119, 20);
            txtUser.TabIndex = 1;
            txtUser.Text = "User";
            txtUser.Value = "";
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 45);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(114, 17);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Lock";
            checkBox1.UseVisualStyleBackColor = true;
            groupBox1.Controls.Add((Control)txtUser);
            groupBox1.Location = new Point(9, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(147, 114);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "User";
            groupBox2.Controls.Add((Control)checkBox1);
            groupBox2.Location = new Point(163, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(130, 114);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Options";
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(169, 132);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(68, 17);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "Top";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += new EventHandler(checkBox2_CheckedChanged);
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(303, 155);
            Controls.Add((Control)groupBox2);
            Controls.Add((Control)checkBox2);
            Controls.Add((Control)groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = nameof(Form1);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fb";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
