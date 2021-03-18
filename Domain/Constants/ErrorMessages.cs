using System.Collections.Generic;

namespace SmartLocker.WebAPI.Domain.Constants
{
    public static class ErrorMessages
    {
        public static Dictionary<string, string> GetUkrainianLocalization()
        {
            Dictionary<string, string> messages = new();

            messages.Add("The user with such login is already registered.", "Користувач з таким логіном вже існує.");
            messages.Add("Login failed.", "Помилка входу.");
            messages.Add("The user with such login doesn`t exist.", "Користувач з таким логіном не існує.");
            messages.Add("The password isn`t correct.", "Невірний пароль.");

            messages.Add("Role doesn`t exist.", "Роль не існує.");
            messages.Add("User with this identifier doesn`t exist.", "Користувач з таким ідентифікатором не існує.");
            messages.Add("Locker already exists.", "Така шафа вже існує.");
            messages.Add("Locker with this identifier doesn`t exist.", "Шафа з таким ідентифікатором не існує.");

            messages.Add("Service book already exists.", "Така сервісна книжка вже існує.");
            messages.Add("Service book with this identifier doesn`t exist.", "Сервісна книжка з таким ідентифікатором не існує.");
            messages.Add("Tool already exists.", "Інструмент вже існує.");
            messages.Add("Tool with this identifier doesn`t exist.", "Інструмент з таким ідентифікатором не існує.");

            return messages;
        }

        public static Dictionary<string, string> GetEnglishLocalization()
        {
            Dictionary<string, string> messages = new();

            messages.Add("The user with such login is already registered.", "The user with such login is already registered.");
            messages.Add("Login failed.", "Login failed.");
            messages.Add("The user with such login doesn`t exist.", "The user with such login doesn`t exist.");
            messages.Add("The password isn`t correct.", "The password isn`t correct.");

            messages.Add("Role doesn`t exist.", "Role doesn`t exist.");
            messages.Add("User with this identifier doesn`t exist.", "User with this identifier doesn`t exist.");
            messages.Add("Locker already exists.", "Locker already exists.");
            messages.Add("Locker with this identifier doesn`t exist.", "Locker with this identifier doesn`t exist.");

            messages.Add("Service book already exists.", "Service book already exists.");
            messages.Add("Service book with this identifier doesn`t exist.", "Service book with this identifier doesn`t exist.");
            messages.Add("Tool already exists.", "Tool already exists.");
            messages.Add("Tool with this identifier doesn`t exist.", "Tool with this identifier doesn`t exist.");

            return messages;
        }
    }
}
