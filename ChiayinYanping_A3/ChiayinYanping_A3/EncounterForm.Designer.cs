namespace ChiayinYanping_A3
{
    partial class EncounterForm
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
            btnStartNew = new Button();
            listInfo = new ListBox();
            groupAED = new GroupBox();
            btnDeleteNote = new Button();
            btnUpdateNote = new Button();
            btnAddNote = new Button();
            vitalsListbox = new ListBox();
            problemListbox = new ListBox();
            btnRemovePro = new Button();
            label6 = new Label();
            label5 = new Label();
            btnAdd = new Button();
            datebirth = new DateTimePicker();
            richboxNote = new RichTextBox();
            txtNewProblem = new TextBox();
            txtPatientName = new TextBox();
            txtNoteId = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            labNoteId = new Label();
            labMsg = new Label();
            groupAED.SuspendLayout();
            SuspendLayout();
            // 
            // btnStartNew
            // 
            btnStartNew.Location = new Point(45, 28);
            btnStartNew.Name = "btnStartNew";
            btnStartNew.Size = new Size(328, 58);
            btnStartNew.TabIndex = 0;
            btnStartNew.Text = "Start new note";
            btnStartNew.UseVisualStyleBackColor = true;
            btnStartNew.Click += btnStartNew_Click;
            // 
            // listInfo
            // 
            listInfo.FormattingEnabled = true;
            listInfo.ItemHeight = 36;
            listInfo.Location = new Point(49, 110);
            listInfo.Name = "listInfo";
            listInfo.Size = new Size(324, 832);
            listInfo.TabIndex = 1;
            listInfo.SelectedIndexChanged += listInfo_SelectedIndexChanged;
            // 
            // groupAED
            // 
            groupAED.Controls.Add(btnDeleteNote);
            groupAED.Controls.Add(btnUpdateNote);
            groupAED.Controls.Add(btnAddNote);
            groupAED.Controls.Add(vitalsListbox);
            groupAED.Controls.Add(problemListbox);
            groupAED.Controls.Add(btnRemovePro);
            groupAED.Controls.Add(label6);
            groupAED.Controls.Add(label5);
            groupAED.Controls.Add(btnAdd);
            groupAED.Controls.Add(datebirth);
            groupAED.Controls.Add(richboxNote);
            groupAED.Controls.Add(txtNewProblem);
            groupAED.Controls.Add(txtPatientName);
            groupAED.Controls.Add(txtNoteId);
            groupAED.Controls.Add(label4);
            groupAED.Controls.Add(label3);
            groupAED.Controls.Add(label2);
            groupAED.Controls.Add(label1);
            groupAED.Controls.Add(labNoteId);
            groupAED.Location = new Point(415, 44);
            groupAED.Name = "groupAED";
            groupAED.Size = new Size(1581, 912);
            groupAED.TabIndex = 2;
            groupAED.TabStop = false;
            groupAED.Text = "Add/Edit/Delete Encounter Note:";
            // 
            // btnDeleteNote
            // 
            btnDeleteNote.Enabled = false;
            btnDeleteNote.Location = new Point(513, 848);
            btnDeleteNote.Name = "btnDeleteNote";
            btnDeleteNote.Size = new Size(147, 58);
            btnDeleteNote.TabIndex = 18;
            btnDeleteNote.Text = "Delete note";
            btnDeleteNote.UseVisualStyleBackColor = true;
            btnDeleteNote.Click += btnDeleteNote_Click;
            // 
            // btnUpdateNote
            // 
            btnUpdateNote.Enabled = false;
            btnUpdateNote.Location = new Point(212, 848);
            btnUpdateNote.Name = "btnUpdateNote";
            btnUpdateNote.Size = new Size(234, 58);
            btnUpdateNote.TabIndex = 17;
            btnUpdateNote.Text = "Update note";
            btnUpdateNote.UseVisualStyleBackColor = true;
            btnUpdateNote.Click += btnUpdateNote_Click;
            // 
            // btnAddNote
            // 
            btnAddNote.Enabled = false;
            btnAddNote.Location = new Point(16, 848);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(147, 58);
            btnAddNote.TabIndex = 16;
            btnAddNote.Text = "Add note";
            btnAddNote.UseVisualStyleBackColor = true;
            btnAddNote.Click += btnAddNote_Click;
            // 
            // vitalsListbox
            // 
            vitalsListbox.FormattingEnabled = true;
            vitalsListbox.ItemHeight = 36;
            vitalsListbox.Location = new Point(965, 98);
            vitalsListbox.Name = "vitalsListbox";
            vitalsListbox.Size = new Size(322, 220);
            vitalsListbox.TabIndex = 15;
            // 
            // problemListbox
            // 
            problemListbox.FormattingEnabled = true;
            problemListbox.ItemHeight = 36;
            problemListbox.Location = new Point(658, 98);
            problemListbox.Name = "problemListbox";
            problemListbox.Size = new Size(240, 220);
            problemListbox.TabIndex = 14;
            // 
            // btnRemovePro
            // 
            btnRemovePro.Location = new Point(658, 324);
            btnRemovePro.Name = "btnRemovePro";
            btnRemovePro.Size = new Size(240, 46);
            btnRemovePro.TabIndex = 13;
            btnRemovePro.Text = "Remove problem";
            btnRemovePro.UseVisualStyleBackColor = true;
            btnRemovePro.Click += btnRemovePro_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(965, 50);
            label6.Name = "label6";
            label6.Size = new Size(82, 36);
            label6.TabIndex = 12;
            label6.Text = "Vitals:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(658, 50);
            label5.Name = "label5";
            label5.Size = new Size(128, 36);
            label5.TabIndex = 11;
            label5.Text = "Problems:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(468, 277);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 46);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // datebirth
            // 
            datebirth.Location = new Point(212, 212);
            datebirth.Name = "datebirth";
            datebirth.Size = new Size(346, 42);
            datebirth.TabIndex = 9;
            // 
            // richboxNote
            // 
            richboxNote.Location = new Point(0, 428);
            richboxNote.Name = "richboxNote";
            richboxNote.Size = new Size(1287, 414);
            richboxNote.TabIndex = 8;
            richboxNote.Text = "";
            richboxNote.TextChanged += richboxNote_TextChanged;
            // 
            // txtNewProblem
            // 
            txtNewProblem.Location = new Point(212, 281);
            txtNewProblem.Name = "txtNewProblem";
            txtNewProblem.Size = new Size(234, 42);
            txtNewProblem.TabIndex = 7;
            // 
            // txtPatientName
            // 
            txtPatientName.Location = new Point(212, 135);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(348, 42);
            txtPatientName.TabIndex = 6;
            // 
            // txtNoteId
            // 
            txtNoteId.Enabled = false;
            txtNoteId.Location = new Point(212, 60);
            txtNoteId.Name = "txtNoteId";
            txtNoteId.Size = new Size(200, 42);
            txtNoteId.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 379);
            label4.Name = "label4";
            label4.Size = new Size(85, 36);
            label4.TabIndex = 4;
            label4.Text = "Note :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 135);
            label3.Name = "label3";
            label3.Size = new Size(172, 36);
            label3.TabIndex = 3;
            label3.Text = "Patient name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 207);
            label2.Name = "label2";
            label2.Size = new Size(166, 36);
            label2.TabIndex = 2;
            label2.Text = "Date of birth:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 287);
            label1.Name = "label1";
            label1.Size = new Size(176, 36);
            label1.TabIndex = 1;
            label1.Text = "New problem:";
            // 
            // labNoteId
            // 
            labNoteId.AutoSize = true;
            labNoteId.Location = new Point(6, 60);
            labNoteId.Name = "labNoteId";
            labNoteId.Size = new Size(110, 36);
            labNoteId.TabIndex = 0;
            labNoteId.Text = "Note ID:";
            // 
            // labMsg
            // 
            labMsg.AutoSize = true;
            labMsg.Location = new Point(43, 980);
            labMsg.Name = "labMsg";
            labMsg.Size = new Size(83, 36);
            labMsg.TabIndex = 3;
            labMsg.Text = "label7";
            // 
            // EncounterForm
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2264, 1224);
            Controls.Add(labMsg);
            Controls.Add(groupAED);
            Controls.Add(listInfo);
            Controls.Add(btnStartNew);
            Name = "EncounterForm";
            Text = "Encounter Notes";
            groupAED.ResumeLayout(false);
            groupAED.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartNew;
        private ListBox listInfo;
        private GroupBox groupAED;
        private TextBox txtNoteId;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label labNoteId;
        private Label label6;
        private Label label5;
        private Button btnAdd;
        private DateTimePicker datebirth;
        private RichTextBox richboxNote;
        private TextBox txtNewProblem;
        private TextBox txtPatientName;
        private Button btnDeleteNote;
        private Button btnUpdateNote;
        private Button btnAddNote;
        private ListBox vitalsListbox;
        private ListBox problemListbox;
        private Button btnRemovePro;
        private Label labMsg;
    }
}
