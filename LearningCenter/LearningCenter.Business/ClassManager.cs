using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Repository;

namespace LearningCenter.Business
{
    public interface IClassManager
    {
        ClassModel[] Classes { get; }
        ClassModel Class(string className);
    }

    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public ClassModel(int classId, string className)
        {
            ClassId = classId;
            ClassName = className;
        }

    }
    public class ClassManager : IClassManager
    {
        private readonly IClassRepository classRepository;

        public ClassManager(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }
        public ClassModel[] Classes
        {
            get
            {
                return classRepository.Classes
                    .Select(t => new ClassModel(t.ClassId, t.ClassName))
                    .ToArray();
            }
        }
        public ClassModel Class(string className)
        {
            var classModel = classRepository.Class(className);
            return new ClassModel(classModel.ClassId, classModel.ClassName);
        }
    }
}
