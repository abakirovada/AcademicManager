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
                    TeacherId = model.TeacherId,
                    Teacher=model.Teacher
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
                            IsActive = e.IsActive,
                            TeacherId = e.TeacherId,
                            Teacher = e.Teacher,
                            Assignments = e.Assignments
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
                        Assignments = entity.Assignments
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
                entity.TeacherId = model.TeacherId;
                entity.Teacher = model.Teacher;
                entity.Assignments = model.Assignments;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
