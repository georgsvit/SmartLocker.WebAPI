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

            return messages;
        }
    }
}
