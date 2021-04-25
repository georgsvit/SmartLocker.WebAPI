using System.Collections.Generic;

namespace SmartLocker.WebAPI.Domain.Constants
{
    public static class LocalizationResourse
    {
        public static Dictionary<string, string> GetUkrainianLocalization()
        {
            Dictionary<string, string> messages = new();

            // Errors

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
            
            messages.Add("Note already exists.", "Запис вже існує.");
            messages.Add("Note with this identifier doesn`t exist.", "Запис з таким ідентифікатором не існує.");
            messages.Add("Tool can`t be returned.", "Інструмент не може бути повернутий.");
            messages.Add("Tool can`t be taken.", "Інструмент не може бути отриманий.");

            // Report strings

            messages.Add("Date", "Дата");
            messages.Add("Tool was taken", "був переданий до сервісного центру");
            messages.Add("Tool was maintened", "було обслуговано");
            messages.Add("Cost", "Вартість");

            messages.Add("Serviceman details", "Відомості про майстра:");
            messages.Add("Fullname", "Повне ім'я");
            messages.Add("AccessLevel", "Рівень доступу");
            messages.Add("ServiceReportTitle", "    Журнал сервісного обслуговування\nДата формування:");

            messages.Add("Tool was taken by", "було взято");
            messages.Add("From", "із комірки");
            messages.Add("ViolationReportTitle", "    Журнал порушень\nДата формування:");
            messages.Add("Violator details", "Відомості про порушника:");

            messages.Add("AccountingReportTitle", "    Журнал обліку\nДата формування:");
            messages.Add("At", "у");
            messages.Add("Tool was returned at", "Та було повернуто у");
            messages.Add("User details", "Відомості про співробітника:");

            return messages;
        }

        public static Dictionary<string, string> GetEnglishLocalization()
        {
            Dictionary<string, string> messages = new();

            // Errors

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
            
            messages.Add("Note already exists.", "Note already exists.");
            messages.Add("Note with this identifier doesn`t exist.", "Note with this identifier doesn`t exist.");
            messages.Add("Tool can`t be returned.", "Tool can`t be returned.");
            messages.Add("Tool can`t be taken.", "Tool can`t be taken.");


            // Report strings

            messages.Add("Date", "Date");
            messages.Add("Tool was taken", "was taken to service");
            messages.Add("Tool was maintened", "was maintened by");
            messages.Add("Cost", "Cost");

            messages.Add("Serviceman details", "Serviceman details:");
            messages.Add("Fullname", "Full name");
            messages.Add("AccessLevel", "Access level");
            messages.Add("ServiceReportTitle", "    Service Register\nFormation date:");

            messages.Add("Tool was taken by", "was taken by");
            messages.Add("From", "from");
            messages.Add("ViolationReportTitle", "    Violation Register\nFormation date:");
            messages.Add("Violator details", "Violator details:");

            messages.Add("AccountingReportTitle", "    Accounting Register\nFormation date:");
            messages.Add("At", "at");
            messages.Add("Tool was returned at", "And was returned at");
            messages.Add("User details", "User details:");

            return messages;
        }
    }
}
