using Xunit; // 1. Библиотека для тестов
using EventLiteWeb.Services; // 2. Твой сервис
using EventLiteWeb.Data; // 3. Твоя база данных
using EventLiteWeb.Models; // 4. Твоя модель Event
using Microsoft.EntityFrameworkCore; // 5. Инструменты для базы

namespace EventLiteTests; // 6. Имя пространства тестов

public class EventServiceTests // 7. Класс-контейнер для тестов
{
    // 8. Метод-помощник: создаёт тестовую базу данных в памяти
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // 9. Уникальное имя, чтобы тесты не мешали друг другу
            .Options;

        return new AppDbContext(options);
    }

    // 10. [Fact] говорит компьютеру: "ЭТО TEST! Запусти меня!"
    [Fact]
    public async Task CreateEventAsync_ValidData_SavesSuccessfully()
    {
        // --- ARRANGE (ПОДГОТОВКА) ---
        // 11. Создаём чистую базу для этого теста
        using var context = GetDbContext();
        // 12. Создаём сервис и даём ему эту базу
        var service = new EventService(context);

        // 13. Готовим данные (как продукты перед готовкой)
        var newEvent = new Event
        {
            Name = "День Рождения",
            Location = "Дом",
            Date = DateTime.UtcNow.AddDays(1)
        };

        // --- ACT (ДЕЙСТВИЕ) ---
        // 14. Вызываем метод, который хотим проверить
        var result = await service.CreateEventAsync(newEvent);

        // --- ASSERT (ПРОВЕРКА) ---
        // 15. Проверяем, что метод вернул результат
        Assert.NotNull(result);

        // 16. Проверяем, что в базе появилась 1 запись
        var count = await context.Events.CountAsync();
        Assert.Equal(1, count);

        // 17. Проверяем, что имя сохранилось верно
        Assert.Equal("День Рождения", result.Name);
    }
}