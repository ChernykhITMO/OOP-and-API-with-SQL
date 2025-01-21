using Itmo.ObjectOrientedProgramming.Lab2.Laboratory;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class SubjectMaterials
{
    public IReadOnlyCollection<LaboratoryWork> LaboratoryWorks { get; }

    public IReadOnlyCollection<LectureMaterial> LectureMaterials { get; }

    public SubjectMaterials(IReadOnlyCollection<LaboratoryWork> laboratoryWorks, IReadOnlyCollection<LectureMaterial> lectureMaterials)
    {
        LaboratoryWorks = new List<LaboratoryWork>(laboratoryWorks);
        LectureMaterials = new List<LectureMaterial>(lectureMaterials);
    }
}