using MyHomework.Data;
using MyHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Services
{
    public class GradeService
    {
        //create
        public bool CreateGrade(GradeCreate model)
        {
            var entity =
                new Grade()
                {
                    Points = model.Points
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Grades.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all
        public IEnumerable<GradeList> GetGrades()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Grades
                    .Select(
                        e => new GradeList
                        {
                            GradeId = e.GradeId,
                            Assignment = e.Assignment,
                            Points = e.Points
                        });
                return query.ToArray();
            }
        }

        //get by id
        public GradeDetail GetGradeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Grades
                    .Single(e => e.GradeId == id);
                return
                    new GradeDetail
                    {
                        GradeId = entity.GradeId,
                        Assignment = entity.Assignment,
                        Student = entity.Student,
                        Points = entity.Points
                    };
            }
        }

        //delete
        public bool DeleteGrade(int gradeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Grades
                    .Single(e => e.GradeId == gradeId);

                ctx.Grades.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //update
        public bool UpdateGrade(GradeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Grades
                    .Single(e => e.GradeId == model.GradeId);

                entity.Points = model.Points;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
