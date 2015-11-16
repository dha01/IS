﻿using System;

namespace IS.Model.Item.Specialty
{
    /// <summary>
    /// Класс для хранения данных о сущности cпециальности.
    /// </summary>
    public class SpecialtyItem
    {
        /// <summary>
        /// Идентификатор специальности.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное название специальности.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Сокращенное название специальности.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Код специальности.
        /// </summary>
        public char Code { get; set; }
    }
}