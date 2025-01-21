using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.Laboratory;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectsUpdaters;
using Xunit;

namespace Lab2.Tests;

public class AbstractUniversityTests
{
    [Fact]
    public void NotAuthorCantResetSubject()
    {
        var author = new User(1, "Number1");
        var author2 = new User(2, "Number2");

        Subject subject = new SubjectBuilder()
            .SetId(1)
            .SetName("C# University")
            .SetAuthor(author)
            .AddLaboratoryWork(new LaboratoryWork(3200, "OOP", author, "SOLID", 40, CreditFormat.Exam))
            .AddLaboratoryWork(new LaboratoryWork(3201, "OOP", author, "Patterns", 30, CreditFormat.Exam))
            .AddLaboratoryWork(new LaboratoryWork(3202, "OOP", author, "GRASP", 30, CreditFormat.Exam))
            .SetDescription("Programming")
            .Build();

        var validator = new SubjectValidator();
        var updater = new SubjectUpdater(
            new SubjectUpdaterWithBuilder(subject).SetDescription("Updated by unauthorized user"));

        ResultType<Subject> validationResult = validator.Validate(subject);
        ResultType<Subject> updateResult = updater.Update(subject, author2);

        Assert.True(validationResult.IsSuccess);
        Assert.Equal(string.Empty, validationResult.Error);

        Assert.False(updateResult.IsSuccess);
        Assert.Equal("Author must be the same", updateResult.Error);
    }

    [Fact]
    public void NotAuthorCantResetLaboratoryWork()
    {
        var user = new User(1, "Number1");
        var user2 = new User(2, "Number2");
        var laboratoryWork = new LaboratoryWork(1, "OOP", user, "SOLID", 20, CreditFormat.Exam);
        var repository = new InMemoryRepository<LaboratoryWork>();
        repository.Add(laboratoryWork);

        LaboratoryUpdaterBuilder laboratoryUpdate = new LaboratoryUpdaterBuilder(laboratoryWork)
            .SetName("Laboratory name Update");
        var laboratoryUpdater = new LaboratoryWorkUpdater(laboratoryUpdate);

        ResultType<LaboratoryWork> updateResult = laboratoryUpdater.Update(laboratoryWork, user2);

        Assert.False(updateResult.IsSuccess);
        Assert.Equal("Only the author can update the laboratory works", updateResult.Error);
    }

    [Fact]
    public void NotAuthorCantResetLecture()
    {
        var user = new User(1, "Number1");
        var user2 = new User(2, "Number2");

        var lectureMaterial = new LectureMaterial(3300, "Lection", user, "Introduction to C# programming", "Content");
        var repositoryLectureMaterial = new InMemoryRepository<LectureMaterial>();
        repositoryLectureMaterial.Add(lectureMaterial);

        LectureUpdaterBuilder lectureUpdaterBuilder = new LectureUpdaterBuilder(lectureMaterial)
            .SetContent("New content from C# programming");
        var lectureMaterialUpdater = new LectureMaterialUpdater(lectureUpdaterBuilder);

        ResultType<LectureMaterial> updateResult = lectureMaterialUpdater.Update(lectureMaterial, user2);

        Assert.False(updateResult.IsSuccess);
        Assert.Equal("Only the author can update the lecture materials", updateResult.Error);
    }

    [Fact]
    public void OnlyAuthorCanCloneSubject()
    {
        var user = new User(1, "Number1");
        var subjectBuilder = new SubjectBuilder();

        Subject subject = subjectBuilder
            .SetId(1)
            .SetName("C# University")
            .SetAuthor(user)
            .AddLaboratoryWork(new LaboratoryWork(3200, "OOP", user, "SOLID", 40, CreditFormat.Exam))
            .AddLaboratoryWork(new LaboratoryWork(3201, "OOP", user, "Patterns", 30, CreditFormat.Exam))
            .AddLaboratoryWork(new LaboratoryWork(3202, "OOP", user, "GRASP", 30, CreditFormat.Exam))
            .SetDescription("Programming")
            .SetExamFormat(100)
            .Build();

        var subjectValidator = new SubjectValidator();
        ResultType<Subject> validationResult = subjectValidator.Validate(subject);
        var repositorySubjects = new InMemoryRepository<Subject>();
        repositorySubjects.Add(subject);

        Subject subject2 = subject.Clone();

        Assert.True(validationResult.IsSuccess);
        Assert.Equal(subject.Id, subject2.OriginalId);
    }

    [Fact]
    public void OnlyAuthorCanCloneLaboratoryWork()
    {
        var user = new User(1, "Number1");
        var labWork = new LaboratoryWork(3300, "OOP", user, "GRASP", 30, CreditFormat.Exam);
        var repository = new InMemoryRepository<LaboratoryWork>();
        repository.Add(labWork);

        LaboratoryWork labWork2 = labWork.Clone();

        Assert.Equal(labWork.Id, labWork2.OriginalId);
    }

    [Fact]
    public void OnlyAuthorCanCloneLecture()
    {
        var user = new User(1, "Number1");
        var lectureMaterial = new LectureMaterial(6600, "Lecture", user, "Patterns", "Content");
        var repositoryLectureMaterial = new InMemoryRepository<LectureMaterial>();
        repositoryLectureMaterial.Add(lectureMaterial);

        LectureMaterial lectureMaterial2 = lectureMaterial.Clone();

        Assert.Equal(lectureMaterial.Id, lectureMaterial2.OriginalId);
    }

    [Fact]
    public void FailWhenTotalPointsNot100()
    {
        var author = new User(1, "Number1");

        Subject subject = new SubjectBuilder()
            .SetId(1)
            .SetName("C# University")
            .SetAuthor(author)
            .AddLaboratoryWork(new LaboratoryWork(3200, "OOP", author, "SOLID", 50, CreditFormat.Exam))
            .AddLaboratoryWork(new LaboratoryWork(3201, "OOP", author, "Patterns", 30, CreditFormat.Exam))
            .AddLaboratoryWork(new LaboratoryWork(3202, "OOP", author, "GRASP", 30, CreditFormat.Exam))
            .SetDescription("Programming")
            .SetExamFormat(100)
            .Build();

        var validator = new SubjectValidator();
        var repository = new InMemoryRepository<Subject>();
        repository.Add(subject);

        ResultType<Subject> validationResult = validator.Validate(subject);

        Assert.False(validationResult.IsSuccess);
        Assert.Equal("Total points must be 100", validationResult.Error);
    }
}

