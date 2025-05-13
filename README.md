# 🚀 Учебные проекты по C# и ООП

<div align="center">
  <img ![vs_programming](https://github.com/user-attachments/assets/39738078-89b3-4b3e-b98e-55842b35b813)
>
  <br>
  <sub>Набор приложений, созданных в рамках курса "ООП на практике"</sub>
</div>

---

## 📂 Содержание
- [Архитектура репозитория](#-архитектура-репозитория)
- [Ключевые проекты](#-ключевые-проекты)
- [Технологический стек](#-технологический-стек)
- [Архитектурные решения](#-архитектурные-решения)
- [Демонстрация](#-демонстрация)
- [Запуск проектов](#-запуск-проектов)

---

## 🏛️ Архихитектура репозитория
📁 mystudyprojects
├── 📁 BallGamesWinFormsApp # Библиотека игр с физикой объектов
│ ├── AngryBirdsWinFormsApp # Игра "Angry Birds"
│ ├── BillyardBallsWinFormsApp # Модель диффузии газа
│ └── FruitNinjaWinFormsApp # Аркадная игра
├── 📁 GeniyIdiotConsoleApp # Тестирующая система
└── 📁 2048WinFormsApp # Клон игры 2048


---

## 💡 Ключевые проекты

### 🧠 GeniyIdiot
**Особенности:**
- Два интерфейса (консольный + графический)
- Динамическая генерация тестовых вопросов
- Система оценки ответов "диагнозом"
- Хранение данных в JSON
- История результатов тестирования
- Возможность добавления и удаления вопросов и ответов
- 🔧 Пример кода:
```csharp
// Пример сериализации результатов
public static void SaveTestResult(TestResult result)
{
    var results = ReadTestResults();
    results.Add(result);
    var json = JsonSerializer.Serialize(results);
    FileManager.WriteAllText(resultsPath, json);
}
```
 

### 🎮 2048
**Особенности:**
- Механика слияния одинаковых блоков
- Система подсчета очков
- Сохранение рекордов
- Адаптивный интерфейс
  📌 Правила:
- Используйте стрелки для перемещения плиток
- Совмещайте одинаковые числа, чтобы получить 2048
- Игра заканчивается, когда ходы невозможны
- 🔧 Пример кода:
```csharp
private void MoveRight()
{
    for (int i = 0; i < mapSize; i++)
    {
        for (int j = mapSize - 1; j >= 0; j--)
        {
            if (labelsMap[i, j].Text != string.Empty)
            {
                for (int k = j - 1; k >= 0; k--)
                {
                    if (labelsMap[i, k].Text == labelsMap[i, j].Text)
                    {
                        var number = int.Parse(labelsMap[i, j].Text);
                        score += number * 2;
                        labelsMap[i, j].Text = (number * 2).ToString();
                        labelsMap[k, j].Text = string.Empty;
                    }
                }
            }
        }
    }
}
```

### ⚽ BallGames
**Особенности:**
- Физика отскока мяча
- Несколько режимов игры:
  - Сбиваем рандомного сгенерированный шарик другим 
  - Феерверк
  - Модель диффузии газа
- Управление мышью/клавиатурой
- 🔧 Пример кода:
```csharp
// Базовый класс
public class Ball
{
    // ... 
    
    protected virtual void Go() // Полиморфизм
    {
        centerX += vx;
        centerY += vy;
    }

    public virtual void Draw(Graphics graphics) // Расширяемость
    {
        var rectangle = new RectangleF(centerX - radius, centerY - radius, 2 * radius, 2 * radius);
        graphics.FillEllipse(brush, rectangle);
    }

    public void Clear() // Работа с ресурсами
    {
        using (var g = form.CreateGraphics())
        {
            var oldBrush = brush;
            brush = new SolidBrush(form.BackColor);
            Draw(g);
            brush = oldBrush;
        }
    }
}
```

### 🐸 Frog Puzzle
**Особенности:**
- Логика перемещения между листьями
- Поддержание стремления к лучшему результату
- Визуальная индикация правильных ходов
- Правила игры
- 🔧 Пример кода:
```csharp
// Движение лягушек и увеличение счёта ходов
private void Swap(PictureBox clickedPicture)
{
    var distance = Math.Abs(clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;
    if (distance > 2)
    {
        MessageBox.Show("Так ходить нельзя!");
        return;
    }

    var location = clickedPicture.Location;
    clickedPicture.Location = emptyPictureBox.Location;
    emptyPictureBox.Location = location;
    moveCount++;
}
```

---

## 🔧 Технологический стек
- **C# 9.0** (ООП, LINQ, события, работа с классами и наследованием)
- **Windows Forms** (Создание графического интерфейса, обработка событий, пользовательские контролы)
- **JSON** (Сериализация и десериализация данных для хранения вопросов, результатов тестирования и рекордов)
- **Entity Framework** (Использовалась альтернатива - ручная работа с файловой системой через System.IO и JsonSerializer, без подключения полноценной БД)
- **GDI+** (Рисование графических элементов: шариков, плиток, анимаций, эффектов столкновений и частиц)

---

## 📂 Архитектурные решения

1. Общая библиотека игр
 ```csharp
public abstract class Ball
{
    protected virtual void Go() // Полиморфизм
    {
        // Базовая физика движения
    }
    
    public void Clear() // Инкапсуляция ресурсов
    {
        using (var g = form.CreateGraphics())
        {
            // Очистка предыдущей позиции
        }
    }
}
```

2. Event-driven архитектура
```csharp
public class BillyardBall : MoveBall
{
    public event EventHandler<HitEventArgs> OnHited;
    
    protected override void Go()
    {
        if (centerX <= LeftSide())
        {
            OnHited?.Invoke(this, new HitEventArgs(Side.Left));
        }
    }
}
```

3. Шаблон Repository
```csharp
public static class UsersResultStorage
{
    public static List<TestResult> ReadTestResults()
    {
        var json = FileManager.ReadAllText(resultsPath);
        return JsonSerializer.Deserialize<List<TestResult>>(json);
    }
}
```

---

## 📸 Демонстрация

| GeniyIdiot | 2048 | Frog Puzzle |
|------------|------|-------------|
| ![GeniyIdiot](https://github.com/user-attachments/assets/e700c607-94a6-4ced-822b-24f0543d1af4) | ![2048](https://github.com/user-attachments/assets/7861f03a-f479-4181-901d-40bb37861397) | ![Frog](https://github.com/user-attachments/assets/9d2b1a2f-4e71-465f-8221-b854921ef0ce) |

---

## 🚀 Запуск проектов

Клонировать репозиторий:

bash
git clone https://github.com/PaulPomogaev/mystudyprojects.git
cd mystudyprojects

Сборка в Visual Studio:

Открыть mystudyprojects.sln

Выбрать стартовый проект в Solution Explorer

Собрать решение (Ctrl+Shift+B)

Запустить (F5)


🔑 Ключевые слова
C# | ООП | WinForms | Игровая разработка | JSON | SOLID | Event-driven | Физика | Многопоточность | GDI+ | LINQ | Паттерны проектирования | Сериализация
   
