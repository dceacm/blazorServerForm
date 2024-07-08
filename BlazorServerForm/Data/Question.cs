namespace BlazorServerForm.Data;

public sealed class Question
{
    public int Id { get; private set; } = 0;
    public string Text { get; private set; }
    public Dictionary<int, string> Options { get; private set; }
    public int? SelectedOption { get; set; }

    public string? SelectedOptionText
    {
        get
        {
            if (SelectedOption.HasValue && Options.ContainsKey(SelectedOption.Value))
            {
                return Options[SelectedOption.Value];
            }
            return null;
        }
    }

    private Question(int id, string text, Dictionary<int, string> options)
    {

        Id = id;
        Text = text;
        Options = options;
    }

    public static Question CreateQuestion(int id, string text, Dictionary<int, string> options) 
    {
        Validate(id, text, options);
        return new Question(id, text, options);
    }

    private static void Validate(int id, string text, Dictionary<int, string> options)
    {
        var errors = new Dictionary<string, string>();

        if (id <= 0)
        {
            errors.Add(nameof(id),$"El valor de {nameof(id)} no puede ser menor o igual que cero.");
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            errors.Add(nameof(text), $"El valor de {nameof(text)} no puede ser nulo o vacío. El texto de la pregunta es obligatorio");
        }

        if (!options.Any())
        {
            errors.Add(nameof(options), $"El valor de {nameof(options)} no puede estar vacía. Las respuestas son obligatorias.");
        }

        if (errors.Count > 0)
        {
            throw new InvalidOperationException(string.Join(Environment.NewLine, errors));
        }
    }
}