🔍 Подробное описание проектов

🧠 GeniyIdiot - Тест на IQ с администрированием
Особенности:
✅ Два интерфейса (Console + WinForms)
✅ Общая библиотека с логикой тестирования
✅ JSON-хранилище вопросов/результатов
✅ Система диагностики с шуточными результатами
✅ Таймер ответов (WinForms)

csharp
// Пример сериализации результатов
var results = JsonSerializer.Serialize(users);
FileManager.WriteAllText("results.json", results);
GeniyIdiot Demo

🧩 2048Game - Клон культовой головоломки
Реализовано:
✔️ Адаптивная генерация плиток
✔️ Система рекордов с JSON-хранилищем
✔️ Поддержка полей 4x4, 5x5, 6x6
✔️ Визуальные анимации перемещения
✔️ Полный цикл игры (победа/поражение)

2048 Gameplay

🎯 BallGames - Набор физических симуляторов
Включает 7 игр:

Angry Birds (2D физика, коллизии)

Fruit Ninja (таймеры, события мыши)

Салют (частицы, системы наследования)

Бильярд (обработка границ, события)
...и другие

Технические фишки:
✅ Единая библиотека BallGamesLibrary
✅ Полиморфизм объектов (Ball ← MoveBall ← SaluteBall)
✅ Кастомные события (взрыв, столкновения)

csharp
// Пример обработки взрыва
public class RocketBall : MoveBall {
    public event EventHandler<ExplosionEventArgs> Exploded;
    
    protected override void Go() {
        if(ShouldExplode) 
            Exploded?.Invoke(this, new(x, y));
    }
}
🐸 FrogPuzzle - Логическая головоломка
Особенности реализации:
✅ Кастомный контрол перетаскивания
✅ Валидация допустимых ходов
✅ Система подсчета очков
✅ Адаптивный интерфейс

Frog Puzzle

🛠 Технологический стек
Категория	Технологии
Языки	C# (.NET 6), WinForms
Хранение данных	JSON сериализация, FileSystem
Архитектура	ООП (Наследование, Полиморфизм, Инкапсуляция), MVC-паттерн
Другое	Событийная модель, Таймеры, GDI+ графика, Пользовательские контролы


📈 Извлеченные уроки
Принципы SOLID

Разделение логики (GameEngine ← UI)

Инкапсуляция хранилищ (QuestionsStorage)

Архитектурные паттерны

Переиспользование кода через библиотеки

Событийно-ориентированное программирование

Оптимизация

DoubleBuffering для плавной анимации

BackgroundWorker для тяжелых операций

🚀 Как запустить
Клонировать репозиторий

Открыть решение в Visual Studio 2022+

Выбрать стартовый проект

Собрать и запустить (Ctrl+F5)

csharp
// Пример полиморфизма из BallGames
public class Ball {
    public virtual void Draw(Graphics g) {
        g.FillEllipse(brush, GetRect());
    }
}

public class SaluteBall : Ball {
    public override void Draw(Graphics g) {
        // Кастомная отрисовка салюта
        base.Draw(g);
        g.DrawLine(pen, x, y, x+10, y+10);
    }
}


Ключевые слова для поиска:
C#, WinForms, ООП, SOLID, JSON Serialization, Game Development, Desktop Applications, Event Handling, 2D Physics, MVC Pattern, Educational Projects
