using System.Collections.Generic;


namespace GeniyIdiotConsoleApp
{
    public class QuestionsStorage
    {
        public List<Question> GetAllQuestions()
        {
            return new List<Question>
            {
            new Question("Сколько будет два плюс два умноженное на два?", 6),
            new Question("Бревно нужно распилить на 10 частей, сколько нужно сделать распилов?", 9),
            new Question("На двух руках 10 пальцев, сколько пальцев на 5 руках?", 25),
            new Question("Укол делают каждые пол часа, сколько нужно минут для трёх уколов?", 60),
            new Question("Пять свечей горело, две потухли, сколько свечей осталось?", 2)
            };
        }
    }
}
