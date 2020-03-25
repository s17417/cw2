using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cw2.Models;
using cw2.DAL;

namespace cw2.Controllers
{
    [ApiController]
    [Route("api/students")]


    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService; //zad 8(interfejs do bazy)
        //zad8 (konstruktor)
        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }



        //Zad 3
       /*[HttpGet]
        public string GetStudents()
        {
            return "Kowalski, Malewski, Andrzejewski";
        }
      */

         //zad4
        /*[HttpGet("{id}")]
        public IActionResult GetStudent(int id) 
        { 
            if (id==1)
            {
                return Ok("Kowalski");
            } else if (id==2)
            {
                return Ok("Malewski");
            }
            else
            {
                return NotFound("Nie znaleziono studenta");
            }
        }*/
        
        //zad 5
        /*[HttpGet]
        public string GetStudents(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        }*/

        
        //zad 8
        [HttpGet]
        public IActionResult GetStudents(string orderBy) //te atrybut orderBy to tutaj niepotrzebny bo i tak dane nie sa sortowane
        { 
            return Ok(_dbService.GetStudents());
        }

        //zad6
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 2000)}";
            return Ok(student);
        }

        //zad7
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            
            //aktualiacja student odanym id
            return Ok($"Aktualizacja dokończona dla id={id}");
        }

        //zad7
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent (int id)
        {
            //znalezenie w kolekcji i usuniecie
            return Ok($"Usuwanie ukończonedla id={id}");

            //nieznalezienie w kolekcji
        }

    }
}