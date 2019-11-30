using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.ViewModels
{
    public class SortViewModel
    {
        public SortKey PriceSort { get; set; } // значение для сортировки по имени
        public SortKey Current { get; set; }
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortKey sortKey)
        {
            // значения по умолчанию
            PriceSort = SortKey.OrderByDesc;
            Up = true;

            if (sortKey == SortKey.OrderBy)
            {
                Up = false;
            }

            switch (sortKey)
            {
                case SortKey.OrderBy:
                    Current = PriceSort = SortKey.OrderByDesc;
                    break;
                case SortKey.OrderByDesc:
                    Current = PriceSort = SortKey.OrderBy;
                    break;
                default:
                    Current = PriceSort = SortKey.OrderByDesc;
                    break;
            }
        }
    }
}

