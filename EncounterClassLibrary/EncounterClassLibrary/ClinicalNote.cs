using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterClassLibrary
{
    public class ClinicalNote
    {
        public int NoteId {  get; set; }
        private string patientName;
        public string PatientName { get => patientName; set => patientName = value?.Trim(); }
        public DateTime BirthDay {  get; set; }

        private List<string> newProblem = new List<string>();

        public List<string> NewProblem
        {
            get
            {
                return newProblem;
            }
            set
            {
                if (value != null)
                {
                    newProblem = value.Select(p => p?.Trim()).ToList();
                }
                else
                {
                    newProblem = new List<string>(); 
                }
            }
        }
        public string Notes {  get; set; }

        public ClinicalNote() { }

        public ClinicalNote(int noteId, string patientName, DateTime birthDay, List<string> newProblem, string notes)
        {
            NoteId = noteId;
            PatientName = patientName;
            BirthDay = birthDay;
            NewProblem = newProblem;
            Notes = notes;
        }



        public void ValidationInfor(string name, DateTime birthDate, string notes)
        {

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("patient name is required");

            if (birthDate > DateTime.Now) throw new ArgumentNullException("Date of birth is required and cannot be in the future");

            if (string.IsNullOrWhiteSpace(notes)) throw new ArgumentNullException("clinical note content is required");

        }

        public override string ToString()
        {
            string problems = string.Join(",", NewProblem);
            return $"{NoteId} | {PatientName} | {BirthDay} | {problems} | {Notes} ;"; 
        }

    }
}
