using MyHomework.Data;
using MyHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Services
{
    public class AssignmentService
    {
        public bool CreateAssignment(AssignmentCreate model)
        {
            var entity =
                new Assignment()
                {
                    Name = model.Name,
                    Deadline = model.Deadline,
                    ClassId = model.ClassId,
                    IsAssigned=model.IsAssigned,
                    IsGraded=model.IsGraded
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all
        public IEnumerable<AssignmentList> GetAssignments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Assignments
                    .Select(
                        e => new AssignmentList
                        {
                            AssignmentId = e.AssignmentId,
                            Name = e.Name,
                            ClassId = e.ClassId
                        });
                return query.ToArray();
            }
        }

        //get by id
        public AssignmentDetail GetAssignmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assignments
                    .Single(e => e.AssignmentId == id);
                return
                    new AssignmentDetail
                    {
                        AssignmentId = entity.AssignmentId,
                        Name = entity.Name,
                        Deadline = entity.Deadline,
                        ClassId = entity.ClassId,
                        IsAssigned = entity.IsAssigned,
                        IsGraded=entity.IsGraded
                    };
            }
        }

        //update
        public bool UpdateAssignment(AssignmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assignments
                    .Single(e => e.AssignmentId == model.AssignmentId);

                entity.Name = model.Name;
                entity.Deadline = model.Deadline;
                entity.ClassId = model.ClassId;
                entity.IsAssigned = model.IsAssigned;
                entity.IsGraded = model.IsGraded;

                return ctx.SaveChanges() == 1;
            }
        }

        //delete
        public bool DeleteAssignment(int assignmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Assignments
                    .Single(e => e.AssignmentId == assignmentId);

                ctx.Assignments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
