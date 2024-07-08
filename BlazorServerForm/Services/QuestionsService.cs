using BlazorServerForm.Data;

namespace BlazorServerForm.Services;

public class QuestionsService : IQuestionsService
{
    public List<Question> Questions { get; private set; }

    public QuestionsService()
    {
        Questions = SetQuestions();
    }

    public List<Question> GetQuestions() => Questions;

    public void SetAnswer(int questionId, int? selectedOption)
    {
        // Si hay respuesta
        if (selectedOption.HasValue)
        {
            // Si existe la pregunta y existe la respuesta
            var question = Questions.Find(q => q.Id == questionId);
            if (question != null && question.Options.ContainsKey(selectedOption.Value))
            {
                question.SelectedOption = selectedOption;
            }
        }
    }

    public Dictionary<int, int?> GetSelectedAnswersByQuestion()
    {
        return Questions.ToDictionary(q => q.Id, q => q.SelectedOption);
    }

    private List<Question> SetQuestions()
    {
        return new List<Question>
        {
            Question.CreateQuestion(1, "Pregunta 1", new Dictionary<int, string>
                {
                    { 1, $"Opción A de la pregunta 1" },
                    { 2, $"Opción B de la pregunta 1" },
                    { 3, $"Opción C de la pregunta 1" }
                }
            ),
            Question.CreateQuestion(2, "Pregunta 2", new Dictionary<int, string>
                {
                    { 1, $"Opción A de la pregunta 2" },
                    { 2, $"Opción B de la pregunta 2" },
                    { 3, $"Opción C de la pregunta 2" },
                    { 4, $"Opción D de la pregunta 2" },
                }
            ),
            Question.CreateQuestion(3, "Pregunta 3", new Dictionary<int, string>
                {
                    { 1, $"Opción A de la pregunta 3" },
                    { 2, $"Opción B de la pregunta 3" }
                }
            )
        };
    }
}