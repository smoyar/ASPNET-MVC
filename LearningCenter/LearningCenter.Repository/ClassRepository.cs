using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{
    public interface IClassRepository
    {
        ClassModel Class(string className);
        ClassModel[] Classes { get; }
    }

    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
        public int ClassSessions { get; set; }
    }
    public class ClassRepository : IClassRepository
    {
        public ClassModel Class(string className)
        {

            var Class = Database.DatabaseAccessor.Instance.ClassMasters
                .Where(t => t.ClassName.ToLower() == className.ToLower())
            .Select(t => new ClassModel
            {
                ClassId = t.ClassId,
                ClassName = t.ClassName,
                ClassDescription = t.ClassDescription,
                ClassPrice = t.ClassPrice ,
                ClassSessions = t.ClassSessions
            })
            .First();

            return Class;
        }
        public ClassModel[] Classes
        {
            get
            {
                return Database.DatabaseAccessor.Instance.ClassMasters
                    .Select(t => new ClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                        ClassDescription = t.ClassDescription,
                        ClassPrice = t.ClassPrice,
                        ClassSessions = t.ClassSessions
                    })
                    .ToArray();
            }

        }
    }
}
