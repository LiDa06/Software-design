using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public enum CategoryType { Income, Expense }
    public class Category(Guid id, CategoryType type, string name)
    {
        public Guid Id { get; } = id;
        public CategoryType Type { get; } = type;
        public string Name { get; private set; } = name;

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
