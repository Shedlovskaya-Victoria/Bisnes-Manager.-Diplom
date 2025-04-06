using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_сотрудников._Дипломный_проект.Tools
{
    public class SystemMessages
    {
        public const string BadAuth = "Логин или пароль не верны! Проверьте их заполнение!";
        public const string SuccessAuth = "Вы успешно авторизованы!";
        public const string UserNotFound = "Такой пользователь не найден!";


        public const string SuccessUpdate = "Данные успешно обновлены!";
        public const string SuccessDelete = "Данные успешно удалены!";
        public const string SuccesSave = "Данные успешно сохранены!";
        public const string FalseRequest = "Упс! Ошибка!";


        public const string SatisticIsNull = "Еще нет ни одной статистики! Создайте ее!";
        public const string UserIsNull = "По непредвиденным причинам пользователь не найден в БД!";
        public const string RolesIsNull = "Еще нет ни одной роли! Создайте ее!";
    }
}
