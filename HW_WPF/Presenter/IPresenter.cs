namespace HW_WPF
{
    /// <summary>
    /// Интерфейс Презентера
    /// </summary>
    interface IPresenter
    {
        /// <summary>
        /// Создание нового окна редактирования, дочерняя цепочка MVP
        /// </summary>
        void Show();
        /// <summary>
        /// Скрытие нового окна редактирования, дочерняя цепочка MVP, пока что не используется TO DO
        /// </summary>
        void Hide();
        /// <summary>
        /// Загрузка данных из модели в представление
        /// </summary>
        void LoadData();
        /// <summary>
        /// Сохранение данных из представления в модель
        /// </summary>
        void SaveData();
        /// <summary>
        /// Удаление выбранной записи
        /// </summary>
        void Remove();
        /// <summary>
        /// Изменение выбранной записи
        /// </summary>
        void Edit();
    }
}
