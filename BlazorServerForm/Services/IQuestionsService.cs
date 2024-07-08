using BlazorServerForm.Data;

namespace BlazorServerForm.Services;

public interface IQuestionsService
{
    List<Question> GetQuestions();

    void SetAnswer(int questionId, int? selectedOption);

    Dictionary<int, int?> GetSelectedAnswersByQuestion();
}