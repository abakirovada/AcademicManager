using MyHomework.Data;
using MyHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Services
{
    public class TeacherService
    {
        //private readonly int _userId;
        //public TeacherService(int userId)
        //{
        //    _userId = userId;
        //}

        //create
        public bool CreateTeacher(TeacherCreate model)
        {
            var entity =
                new Teacher()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };
            using(var ctx=new ApplicationDbContext())
            {
                ctx.Teachers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all
        public IEnumerable<TeacherList> GetTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Teachers
                    .Select(
                        e =>new TeacherList
                        {
                            TeacherId = e.TeacherId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Email = e.Email
                        });
                return query.ToArray();
            }
        }

        //get by id
        public TeacherDetail GetTeacherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teachers
                    .Single(e => e.TeacherId == id);
                return
                    new TeacherDetail
                    {
                        TeacherId = entity.TeacherId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Classes=entity.Classes
                    };
            }
        }

        //delete
        public bool DeleteTeacher(int teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Teachers
                    .Single(e => e.TeacherId == teacherId);

                ctx.Teachers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //update
        public bool UpdateTeacher(TeacherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teachers
                    .Single(e => e.TeacherId == model.TeacherId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Classes = model.Classes;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
