/**
 * Author: Yanping guo & Chiayin yang
 * Date: 2024-8-1
 * Project:build a basic app to create, edit, read, and delete 
 * clinical encounter notes that will be stored in a simple text file
 * 
 */
using EncounterClassLibrary;
using System.Runtime;
using System.Runtime.InteropServices.Marshalling;


namespace ChiayinYanping_A3
{
    public partial class EncounterForm : Form
    {
        ManageClinicalNotes mangeNotes = new ManageClinicalNotes();
        List<ClinicalNote> listNotes = new List<ClinicalNote>();
        public EncounterForm()
        {

            InitializeComponent();
            listNotes = mangeNotes.LoadNotes();
            getListInfo();
            txtNoteId.Text = mangeNotes.GetNewId().ToString();
            richboxNote.TextChanged += richboxNote_TextChanged;

        }

        /// <summary>
        /// start new one button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartNew_Click(object sender, EventArgs e)
        {
            txtNoteId.Text = mangeNotes.GetNewId().ToString();
            txtPatientName.Text = string.Empty;
            txtNewProblem.Text = string.Empty;
            problemListbox.Items.Clear();
            vitalsListbox.Items.Clear();
            richboxNote.Text = string.Empty;

            btnAddNote.Enabled = true;
            btnDeleteNote.Enabled = false;
            btnUpdateNote.Enabled = false;

        }

        /// <summary>
        /// Add new problems button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string value = txtNewProblem.Text.Trim();
            if (!string.IsNullOrWhiteSpace(value))
            {
                problemListbox.Items.Add(value);
                txtNewProblem.Text = string.Empty;
            }
        }

        /// <summary>
        /// remove item from new problmes listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemovePro_Click(object sender, EventArgs e)
        {
            if (problemListbox.SelectedIndex != -1)
            {
                problemListbox.Items.RemoveAt(problemListbox.SelectedIndex);
            }
        }

        /// <summary>
        /// Add new note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNote_Click(object sender, EventArgs e)
        {
            labMsg.Text = string.Empty;
            try
            {
                ClinicalNote clinicalNote = getNotesObject();
                mangeNotes.AddNotes(clinicalNote);

                listInfo.Items.Add($"{clinicalNote.PatientName} (Note:{clinicalNote.NoteId})");
                listInfo.SelectedIndex = listInfo.Items.Count - 1;
                btnAddNote.Enabled = false;
                btnDeleteNote.Enabled = true;
                btnUpdateNote.Enabled = true;
                getSuccessfulMsg("Add notes successfully");
            }
            catch (Exception ex)
            {
                getErrorMsg(ex);

            }
        }


        /// <summary>
        /// update notes information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateNote_Click(object sender, EventArgs e)
        {
            try
            {
                if (listInfo.SelectedIndex != -1 )
                {
                    labMsg.Text = string.Empty;
                    mangeNotes.UpdateNotes(getNotesObject());
                    getListInfo();
                    getSuccessfulMsg("Update notes successfully");
                }
                else
                {
                    MessageBox.Show("Please select an item to update", "No Item Selected ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {
                getErrorMsg(ex);
            }
        }


        /// <summary>
        /// delete data button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            if(listInfo.SelectedIndex != -1)
            {
                var confirmResult = MessageBox.Show($"Are you sure to delete the note for {listInfo.SelectedItem}?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes) {
                    mangeNotes.DeleteNotes(getSelectId());
                    getListInfo();
                    getSuccessfulMsg("Delete notes successfully");
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete", "No Item Selected ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        /// <summary>
        /// select navigation data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listInfo.SelectedIndex != -1)
            {
                ClinicalNote clinica = mangeNotes.GetNoteById(getSelectId());

                txtNoteId.Text = clinica.NoteId.ToString();
                txtPatientName.Text = clinica.PatientName;
                datebirth.Value = clinica.BirthDay;
                problemListbox.Items.Clear();
                problemListbox.Items.AddRange(clinica.NewProblem.ToArray());
                richboxNote.Text = clinica.Notes;

                btnDeleteNote.Enabled = true;
                btnUpdateNote.Enabled = true;
            }
         
        }

        /// <summary>
        /// noets change update vitals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richboxNote_TextChanged(object sender, EventArgs e)
        {
            var list = mangeNotes.GetExtractingVitals(richboxNote.Text);
            vitalsListbox.Items.Clear();
            vitalsListbox.Items.AddRange(list.ToArray());
        }

        //get selectindex value
        private int getSelectId()
        {
            string idStr = listInfo.SelectedItem.ToString();
            idStr = idStr.Split(":")[1].Trim().Substring(0, 1);
            return int.Parse(idStr);
        }

        //get Form notes
        private ClinicalNote getNotesObject()
        {
            List<string> probleList = problemListbox.Items.Cast<string>().ToList();
            return new ClinicalNote(int.Parse(txtNoteId.Text), txtPatientName.Text, datebirth.Value, probleList, richboxNote.Text);
        }

        //get Error Message
        private void getErrorMsg(Exception ex)
        {
            labMsg.Text = ex.Message;
            labMsg.ForeColor = Color.Red;
        }

        //get successfully message
        private void getSuccessfulMsg(string message)
        {
            labMsg.Text = message;
            labMsg.ForeColor = Color.Black;
        }

        //joint listbox name and id
        private void getListInfo()
        {
            listInfo.Items.Clear();
            listInfo.Items.AddRange(mangeNotes.getListBoxInfo().ToArray());
        }
    }
}
