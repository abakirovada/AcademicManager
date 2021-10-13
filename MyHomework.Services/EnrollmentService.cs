using MyHomework.Data;
using MyHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Services
{
    public class EnrollmentService
    {
        //create
        public bool CreateEnrollment(EnrollmentCreate model)
        {
            var entity =
                new Enrollment()
                {
                    ClassId = model.ClassId,
                    StudentId = model.StudentId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Enrollments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all
        public IEnumerable<EnrollmentList> GetEnrollments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Enrollments
                    .Select(
                        e => new EnrollmentList
                        {
                            EnrollmentId = e.EnrollmentId,
                            Class = e.Class,
                            Students = e.Students
                        });
                return query.ToArray();
            }
        }

        //get by id
        public EnrollmentDetail GetEnrollmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Enrollments
                    .Single(e => e.EnrollmentId == id);
                return
                    new EnrollmentDetail
                    {
                        EnrollmentId = entity.EnrollmentId,
                        ClassId = entity.ClassId,
                        Class = entity.Class,
                        StudentId=entity.StudentId,
                        Students = entity.Students
                    };
            }
        }

        //delete
        public bool DeleteEnrollment(int enrollmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Enrollments
                    .Single(e => e.EnrollmentId == enrollmentId);

                ctx.Enrollments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //update
        public bool UpdateEnrollment(EnrollmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Enrollments
                    .Single(e => e.EnrollmentId == model.EnrollmentId);

                entity.StudentId = model.StudentId;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
