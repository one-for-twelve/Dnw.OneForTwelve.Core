using Dnw.OneForTwelve.Core.Mappers;
using Dnw.OneForTwelve.Core.Models;
using Dnw.OneForTwelve.Core.Utils;

namespace Dnw.OneForTwelve.Core.Repositories;

internal interface IQuestionRepository
{
    public IEnumerable<Question> GetQuestions();
}

internal class QuestionRepository : IQuestionRepository
{
    private readonly IEmbeddedFile _embeddedFile;
    private readonly IQuestionMapper _questionMapper;

    public QuestionRepository(IEmbeddedFile embeddedFile, IQuestionMapper questionMapper)
    {
        _embeddedFile = embeddedFile;
        _questionMapper = questionMapper;
    }

    public IEnumerable<Question> GetQuestions()
    {
        using var reader = _embeddedFile.Read("questions.csv");
        
        reader.ReadLine();

        var questions = new List<Question>();
        while (reader.ReadLine() is { } line)
        {
            questions.Add(_questionMapper.MapFrom(line));
        }

        return questions;
    }
}