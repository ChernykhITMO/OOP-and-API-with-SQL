using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lecture;

public class LectureUpdaterBuilder : IBuilder<LectureMaterial>
{
    private readonly LectureMaterial _lectureMaterial;
    private string _description;
    private string _content;
    private int _id;
    private string _name;

    public LectureUpdaterBuilder(LectureMaterial lectureMaterial)
    {
        _lectureMaterial = lectureMaterial;
        _description = lectureMaterial.Description;
        _content = lectureMaterial.Content;
        _id = lectureMaterial.Id;
        _name = lectureMaterial.Name ?? throw new ArgumentException("Lecture name cannot be null");
    }

    public LectureUpdaterBuilder SetId(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        _id = id;
        return this;
    }

    public LectureUpdaterBuilder SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty or whitespace");
        }

        _name = name;
        return this;
    }

    public LectureUpdaterBuilder SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be empty or whitespace");
        }

        _description = description;
        return this;
    }

    public LectureUpdaterBuilder SetContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentException("Content cannot be empty or whitespace");
        }

        _content = content;
        return this;
    }

    public LectureMaterial Build()
    {
        _lectureMaterial.Description = _description;
        _lectureMaterial.Content = _content;
        _lectureMaterial.Id = _id;
        _lectureMaterial.Name = _name;
        return _lectureMaterial;
    }
}