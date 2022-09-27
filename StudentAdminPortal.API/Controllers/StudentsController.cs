using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]  // This means '/students' for some reason
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            List<DataModels.Student> students = await _studentRepository.GetStudentsAsync();
            List<DomainModels.Student> domainModelStudents = _mapper.Map<List<DomainModels.Student>>(students);

            //foreach (var student in students)
            //{
            //    domainModelStudents.Add(new DomainModels.Student
            //    {
            //        Id = student.Id,
            //        FirstName = student.FirstName,
            //        LastName = student.LastName,
            //        DateOfBirth = student.DateOfBirth,
            //        Email = student.Email,
            //        Mobile = student.Mobile,
            //        ProfileImageUrl = student.ProfileImageUrl,
            //        GenderId = student.GenderId,
            //        Address = new DomainModels.Address
            //        {
            //            Id = student.Address.Id,
            //            PhysicalAddress = student.Address.PhysicalAddress,
            //            PostalAddress = student.Address.PostalAddress
            //        },
            //        Gender = new DomainModels.Gender
            //        {
            //            Id = student.Gender.Id,
            //            Description = student.Gender.Description,
            //        }

            //    });
            //}
            //return Ok(domainModelStudents);
            return Ok(domainModelStudents);
        }

        [HttpGet]
        [Route("[controller]/{studentId:Guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute]Guid studentId)
        {
            DataModels.Student student = await _studentRepository.GetStudentAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DomainModels.Student>(student));
        }
    }

}
