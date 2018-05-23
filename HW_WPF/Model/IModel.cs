namespace HW_WPF
{
    /// <summary>
    /// Интерфейс моделей
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// сквозное сохранение модели
        /// </summary>
        /// <param name="model">Модель "родительского" уровня или null</param>
        void SaveModel(IModel model);
        /// <summary>
        /// сквозная загрузка модели
        /// </summary>
        /// <param name="model">Модель "родительского" уровня</param>
        void LoadModel(IModel model);
        /// <summary>
        /// Удаление записи в модели
        /// </summary>
        /// <param name="name">Имя записи</param>
        void Remove(string name);
    }
}
