using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EncounterClassLibrary
{
    public class ManageClinicalNotes
    {
        List<ClinicalNote> clinicalNotesList = new List<ClinicalNote>();
        ClinicalNote clinical = new ClinicalNote();
        string fileName = "note.txt";
        public ManageClinicalNotes()
        {
           
        }

        /// <summary>
        /// Add notes
        /// </summary>
        /// <param name="clinicalNote"></param>
        /// <exception cref="Exception"></exception>        
         public void AddNotes(ClinicalNote clinicalNote)
        {
            clinical.ValidationInfor(clinicalNote.PatientName, clinicalNote.BirthDay, clinicalNote.Notes);

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName,true)) {
                    writer.WriteLine(clinicalNote.ToString());
                 }

                clinicalNotesList.Add(clinicalNote);
               
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while AddNotes the ManageClinicalNotes.", ex);
            }

        }

        /// <summary>
        /// update notes
        /// </summary>
        /// <param name="clinicalNote"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateNotes(ClinicalNote clinicalNote)
        {
            clinical.ValidationInfor(clinicalNote.PatientName, clinicalNote.BirthDay, clinicalNote.Notes);

            try
            { 
                int index = clinicalNotesList.FindIndex(n => n.NoteId == clinicalNote.NoteId);
                clinicalNotesList[index] = clinicalNote;

                ReplaceFileNewInfo(clinicalNotesList);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while UpdateNotes the ManageClinicalNotes.", ex);
            }
        }

        /// <summary>
        /// Delete notes
        /// </summary>
        /// <param name="noteId"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteNotes(int noteId)
        {
            try
            {
                int index = clinicalNotesList.FindIndex(n => n.NoteId == noteId);
                clinicalNotesList.RemoveAt(index);

                ReplaceFileNewInfo(clinicalNotesList);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while UpdateNotes the ManageClinicalNotes.", ex);
            }
        }

        /// <summary>
        /// when update or delete notes replace file infromation
        /// </summary>
        /// <param name="list"></param>
        private void ReplaceFileNewInfo(List<ClinicalNote> list)
        {
            File.WriteAllText(fileName, string.Empty);

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                foreach (var note in list)
                {
                    writer.WriteLine(note.ToString());

                }
            }
        }

        /// <summary>
        /// initia LoadNotes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<ClinicalNote> LoadNotes()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string [] linesArray = File.ReadAllText(fileName).Trim().Split(';');
                 
                        if (isNullOrNonValue(linesArray))  
                        {
                            foreach (var lines in linesArray)
                            {
                                string[] lineSecond = lines.Split("|");
                                if (isNullOrNonValue(lineSecond))
                                {
                                    DateTime birthday = DateTime.Parse(lineSecond[2]);
                                    List<string> listbox = new List<string>(lineSecond[3].Split(","));
                                    ClinicalNote clinicalNote = new ClinicalNote(int.Parse(lineSecond[0]), lineSecond[1], birthday, listbox, lineSecond[4]);
                                    clinicalNotesList.Add(clinicalNote);
                                }
                            }
                        }
                    
                }
                return clinicalNotesList;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while initializing the ManageClinicalNotes.", ex);
            }
        }

        /// <summary>
        /// determines whether the arrary has a value
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public bool isNullOrNonValue(string[] array)
        {
            return array !=null && array.Any(s=> !string.IsNullOrWhiteSpace(s));
        }

        //get max noteId from file
        public int GetNewId()
        {
            try
            {
                return clinicalNotesList.Any() ? clinicalNotesList.Max(u => u.NoteId) + 1 : 1;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while generating a new ID.", ex);
            }
        }

        /// <summary>
        /// group by id find  value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClinicalNote GetNoteById(int id)
        {
            return clinicalNotesList.Find(x => x.NoteId == id);
        }

        /// <summary>
        /// joint listbox information like name and id
        /// </summary>
        /// <returns></returns>
        public List<string> getListBoxInfo()
        {
            List<string> list = new List<string>();

            if (clinicalNotesList.Count > 0)
            {
                
                foreach (ClinicalNote note in clinicalNotesList)
                {
                    list.Add($"{note.PatientName} (Note:{note.NoteId})");
                }
            }
            return list;
        }

        /// <summary>
        /// Extracting Vitals
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        public List<Ivital> GetExtractingVitals(string notes) {
            List<Ivital> listvitals = new List<Ivital>();
            // Blood Pressure
            var bpMatches = Regex.Matches(notes, @"BP\s*:\s*(\d{2,3})/(\d{2,3})");
            foreach (Match match in bpMatches)
            {
                int systolic = int.Parse(match.Groups[1].Value);
                int diastolic = int.Parse(match.Groups[2].Value);
                listvitals.Add(new BloodPressure(systolic, diastolic));
            }

            //Heart Rate
            var heartRateMatch = Regex.Matches(notes, @"HR\s*:\s*(\d{2,3})");
            foreach (Match match in heartRateMatch)
            {
                int bpm = int.Parse(match.Groups[1].Value);
                listvitals.Add(new HearRate(bpm));
            }

            // Temperature
            //var temperaMatch = Regex.Matches(notes, @"T\s*:?(\d{2}(?:\.\d+)?)");
            var temperaMatch = Regex.Matches(notes, @"T\s*:?\s*(\d{1,2}(?:\.\d+)?)");


            foreach (Match match in temperaMatch)
            {
                var celsius = double.Parse(match.Groups[1].Value);
                listvitals.Add(new Temperature { Tcelsius = celsius });
            }

            // Respiratory Rate
            var rrMatches = Regex.Matches(notes, @"RR\s*:\s*(\d{2,3})");
            foreach (Match match in rrMatches)
            {
                var respiraBpm = int.Parse(match.Groups[1].Value);
                listvitals.Add(new RespiratoryRate { RespiraBpm = respiraBpm });
            }

            return listvitals;
        }

    }
}
