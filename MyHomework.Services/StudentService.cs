using MyHomework.Data;
using MyHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Services
{
    public class StudentService
    {
        public bool CreateStudent(StudentCreate model)
        {
            var entity =
                new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all
        public IEnumerable<StudentList> GetStudents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Students
                    .Select(
                        e => new StudentList
                        {
                            StudentId = e.StudentId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Email = e.Email
                        });
                return query.ToArray();
            }
        }

        //get by id
        public StudentDetail GetStudentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Students
                    .Single(e => e.StudentId == id);
                return
                    new StudentDetail
                    {
                        StudentId = entity.StudentId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Classes = entity.Classes,
                        Points=entity.Points
                    };
            }
        }

        //update
        public bool UpdateStudent(StudentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Students
                    .Single(e => e.StudentId == model.StudentId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }
        //delete
        public bool DeleteStudent(int studentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Students
                    .Single(e => e.StudentId == studentId);

                ctx.Students.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
