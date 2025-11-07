using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace prak7_WPF
{
    class WorkWithData
    {
        private Dictionary<int, Doctor> _doctors = new Dictionary<int, Doctor>();

        public WorkWithData()
        {
            LoadAllDoctors();
        }

        public void SaveDoctorInFile(Doctor doctor)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"D_{doctor.Id}.json");

            var po = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string json = JsonSerializer.Serialize(doctor, po);
            File.WriteAllText(filePath, json);

            _doctors[doctor.Id] = doctor;
        }


        private void LoadAllDoctors()
        {
            _doctors.Clear();

            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "D_*.json");



            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                var doctor = JsonSerializer.Deserialize<Doctor>(json);

                if (doctor != null)
                {
                    _doctors[doctor.Id] = doctor;
                }
            }
        }
    }
}
