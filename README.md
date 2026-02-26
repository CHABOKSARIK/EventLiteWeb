# 🎉 EventLite Web

**Менеджер мероприятий на ASP.NET Core Blazor Server**

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?logo=blazor)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?logo=docker)](https://www.docker.com/)
[![Tests](https://img.shields.io/badge/Tests-xUnit-green)](https://xunit.net/)

---

## 📖 О проекте

EventLite Web — это веб-приложение для управления мероприятиями. Разработано с соблюдением принципов чистой архитектуры, покрытием unit-тестами и готовностью к контейнеризации.

**Цель проекта:** Демонстрация навыков Full-Stack разработки на .NET для позиции Junior Developer.

---

## 🛠 Стек технологий

| Категория | Технология |
|-----------|------------|
| **Язык** | C# (.NET 10) |
| **UI Framework** | Blazor Server |
| **База данных** | SQLite |
| **ORM** | Entity Framework Core |
| **Тесты** | xUnit + EF Core InMemory |
| **Контейнеризация** | Docker |
| **Архитектура** | Многослойная (UI → Service → Data) |
| **DI** | Built-in .NET Dependency Injection |

---

## ✨ Функционал

- ✅ Создание мероприятий с валидацией
- ✅ Просмотр списка мероприятий
- ✅ Сохранение данных в базу данных
- ✅ Unit-тесты на бизнес-логику
- ✅ Docker-контейнеризация для развёртывания

---

## 📁 Структура проекта

```
EventLiteWeb/
├── src/
│   └── EventLiteWeb/           # Основное приложение
│       ├── Components/         # Blazor компоненты (.razor)
│       ├── Data/               # DbContext и конфигурация БД
│       ├── Models/             # Модели данных (Event)
│       ├── Services/           # Бизнес-логика (EventService)
│       ├── wwwroot/            # Статические файлы
│       ├── appsettings.json    # Конфигурация
│       └── Program.cs          # Точка входа
├── tests/
│   └── EventLiteTests/         # Unit-тесты (xUnit)
├── .dockerignore               # Исключения для Docker
├── Dockerfile                  # Инструкция сборки контейнера
└── README.md                   # Этот файл
```

---

## 🚀 Быстрый старт

### Вариант 1: Через Docker (рекомендуется)

```bash
# Сборка образа
docker build -t eventlite-web .

# Запуск контейнера
docker run -d -p 80:8080 --name eventlite eventlite-web
```

**Приложение доступно:** http://localhost

### Вариант 2: Локальный запуск

```bash
# Восстановление пакетов
dotnet restore

# Сборка проекта
dotnet build

# Запуск приложения
dotnet run --project src/EventLiteWeb/EventLiteWeb.csproj
```

**Приложение доступно:** http://localhost:5000 (или порт из вывода)

---

## 🧪 Запуск тестов

```bash
# Запустить все тесты
dotnet test tests/EventLiteTests/EventLiteTests.csproj

# Запустить с подробным выводом
dotnet test tests/EventLiteTests/EventLiteTests.csproj --logger "console;verbosity=detailed"
```

---

## 🐳 Docker команды

| Команда | Описание |
|---------|----------|
| `docker build -t eventlite-web .` | Сборка образа |
| `docker run -d -p 80:8080 --name eventlite eventlite-web` | Запуск контейнера |
| `docker ps` | Показать запущенные контейнеры |
| `docker logs eventlite` | Просмотр логов |
| `docker stop eventlite` | Остановить контейнер |
| `docker rm eventlite` | Удалить контейнер |

---

## 🏗️ Архитектурные решения

### Многослойная архитектура

```
┌─────────────────┐
│   UI Layer      │  ← Blazor компоненты (.razor)
│   (EventLiteWeb)│
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  Service Layer  │  ← Бизнес-логика (IEventService)
│   (Services/)   │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│   Data Layer    │  ← Доступ к данным (DbContext)
│    (Data/)      │
└─────────────────┘
```

### Почему так?

| Преимущество | Описание |
|--------------|----------|
| **Разделение ответственности** | Каждый слой отвечает за свою задачу |
| **Тестируемость** | Сервисный слой легко покрыть unit-тестами |
| **Поддерживаемость** | Изменения в одном слое не ломают другие |
| **Гибкость** | Можно заменить БД или UI без переписывания логики |

---

## 📸 Скриншоты

### Главная страница
*(Добавь скриншот главной страницы)*

### Создание мероприятия
*(Добавь скриншот формы создания)*

### Список мероприятий
*(Добавь скриншот списка)*

> 💡 **Как добавить скриншоты:**
> 1. Сделай скриншоты работающего приложения
> 2. Создай папку `screenshots/` в корне
> 3. Положи туда изображения
> 4. Обнови пути выше: `![Описание](screenshots/filename.png)`

---

## 🎯 Чему научился в этом проекте

- ✅ Работа с **Blazor Server** и компонентной моделью
- ✅ Настройка **Entity Framework Core** с SQLite
- ✅ Реализация **Dependency Injection**
- ✅ Написание **Unit-тестов** с xUnit и InMemory базой
- ✅ **Docker-контейнеризация** .NET приложений
- ✅ **Multi-stage build** для оптимизации образов
- ✅ Работа с **Git** и GitHub
- ✅ Чистая архитектура и разделение ответственности

---

## 🔧 Требования к окружению

| Компонент | Версия |
|-----------|--------|
| .NET SDK | 10.0+ |
| Docker | 20.10+ |
| IDE | Visual Studio 2022 / Rider / VS Code |

---

## 📝 Лицензия

Этот проект создан в учебных целях для портфолио.

---

## 👨‍ Автор

**[Твоё Имя]**

- 📧 Email: [твой@email.com]
- 💼 LinkedIn: [ссылка]
- 🐙 GitHub: [ссылка на профиль]
- 📍 Локация: [Город, Страна]

---

## 📬 Контакты

Открыт к предложениям на позицию **Junior .NET Developer**!

Если у вас есть вакансия или вопросы по проекту — свяжитесь со мной через GitHub Issues или по email.

---

<div align="center">

**Спасибо за внимание!** 🙏

[⬆ Вернуться к началу](#-eventlite-web)

</div>
