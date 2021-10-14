using MyHomework.Data;
using MyHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Services
{
    public class ClassService
    {
        public bool CreateClass(ClassCreate model)
        {
            var entity =
                new Class()
                {
                    Name = model.Name,
                    IsActive = model.IsActive,
                    Teacher=model.Teacher,
                    Assignments=model.Assignments,
                    Enrollments=model.Enrollments
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Classes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all
        public IEnumerable<ClassList> GetClasses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Classes
                    .Select(
                        e => new ClassList
                        {
                            ClassId=e.ClassId,
                            Name = e.Name,
                            Teacher = e.Teacher
                        });
                return query.ToArray();
            }
        }

        //get by id
        public ClassDetail GetClassById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Classes
                    .Single(e => e.ClassId == id);
                return
                    new ClassDetail
                    {
                        ClassId = entity.ClassId,
                        Name = entity.Name,
                        IsActive = entity.IsActive,
                        Teacher = entity.Teacher,
                        Assignments = entity.Assignments,
                        Enrollments=entity.Enrollments
                    };
            }
        }

        //delete
        public bool DeleteClass(int classId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Classes
                    .Single(e => e.ClassId == classId);

                ctx.Classes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //update
        public bool UpdateClass(ClassEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Classes
                    .Single(e => e.ClassId == model.ClassId);

                entity.Name = model.Name;
                entity.IsActive = model.IsActive;
                entity.Teacher = model.Teacher;
                entity.Assignments = model.Assignments;
                entity.Enrollments = model.Enrollments;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
