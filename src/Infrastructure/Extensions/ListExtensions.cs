using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static List<List<DataRow>> GroupDataRowListByColumn<T>(this List<DataRow> list, int columnName, int groupSize)
        {
            var groupedRecords = list.GroupBy(item =>
            {
                return item[columnName];
            })
                                     .SelectMany(g => g.Select((item, index) => new { GroupIndex = index / groupSize, Item = item }))
                                     .GroupBy(item => item.GroupIndex)
                                     .Select(g => g.Select(item => item.Item).ToList())
                                     .ToList();

            return groupedRecords;
        }

        public static List<List<T>> GroupListByColumn<T>(this List<T> list, string columnName, int groupSize)
        {
            var property = typeof(T).GetProperty(columnName);

            if (property == null)
                throw new ArgumentException($"Column '{columnName}' not found in the object type.");

            var groupedRecords = list.GroupBy(item => property.GetValue(item))
                                     .SelectMany(g => g.Select((item, index) => new { GroupIndex = index / groupSize, Item = item }))
                                     .GroupBy(item => item.GroupIndex)
                                     .Select(g => g.Select(item => item.Item).ToList())
                                     .ToList();

            return groupedRecords;
        }


    }
}
