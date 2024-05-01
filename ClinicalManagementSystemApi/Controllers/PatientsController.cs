using ClinicalManagementSystemApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {

        //dummy data
        private static readonly List<Patient> _patients = new List<Patient>
        {
            new Patient { PatientId = 1,PatientName="Renil",Gender="Male",DateOfBirth=Convert.ToDateTime("12/12/1999"),Address="Tvm",Phone=Convert.ToInt64(9487887788) },
            new Patient { PatientId = 2,PatientName="Dinesh",Gender="Male",DateOfBirth=Convert.ToDateTime("09/11/2000"),Address="Mtm",Phone=Convert.ToInt64(9487888699) }
        };
        #region Get All Products


        //Get Patients: api/patients
        [HttpGet]
        public IEnumerable<Patient> GetPatients()
        {
            return _patients;
        }
        #endregion
        #region
        //Get :api/patients/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var Patient = _patients.FirstOrDefault(x => x.PatientId == id);
            if (Patient == null)
            {
                return NotFound();
            }
            return Ok(Patient);
        }
        #endregion

        #region Create a Patient
        //Post:api/patients
        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.PatientId = _patients.Count + 1;
                _patients.Add(patient);
                return Ok(patient);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region
        //Delete :api/patients/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var Patient = _patients.FirstOrDefault(x => x.PatientId == id);
            if (Patient == null)
            {
                return NotFound();
            }
            _patients.Remove(Patient);
            return Ok(Patient);
        }
        #endregion

        #region Edit a Patient
        //Post:api/patients
        [HttpPut]
        public IActionResult EditPatient(int id,[FromBody] Patient UpdatePatient)
        {
            var Patient = _patients.FirstOrDefault(x => x.PatientId == id);
            if (Patient == null)
            {
                return NotFound();
            }
            Patient.PatientId = UpdatePatient.PatientId;
            Patient.PatientName=UpdatePatient.PatientName;
            Patient.Gender=UpdatePatient.Gender;
            Patient.DateOfBirth=UpdatePatient.DateOfBirth;
            Patient.Address=UpdatePatient.Address;
            Patient.Phone=UpdatePatient.Phone;

            return Ok(Patient);
            
        }
        #endregion

    }
}
