using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace TaskBuilder_WPF.Classes
{
    public class DatabaseReader3
    {
        private const int FieldsCount = 2; // Category  + SubCategoryContent

        private static void ValidateRow(int row, IExcelDataReader reader)
        {
            if (reader.FieldCount != FieldsCount)
            {
                throw new Exception($"Spreadsheet has invalid format. Row {row}: Expected {FieldsCount} columns got {reader.FieldCount}");
            }
        }

        private static Dictionary<string, List<string>> ReadCategories(string path)
        {
            var categories = new Dictionary<string, List<string>>();

            using var stream = File.OpenRead(path);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            while (true)
            {
                var currentRow = 0;

                // Skip first row (just captions)
                reader.Read();

                // Read rows
                while (reader.Read())
                {
                    ValidateRow(++currentRow, reader);

                    var categoryName = reader.GetValue(0).ToString() ?? throw new Exception("Invalid format");
                    if (!categories.TryGetValue(categoryName, out var subCategories))
                    {
                        categories.Add(categoryName, subCategories = new List<string>());
                    }

                    subCategories.Add(reader.GetValue(1).ToString() ?? throw new Exception("Invalid format"));
                }

                // Next sheet (can omit if only one sheet should be processed)
                if (!reader.NextResult())
                {
                    break;
                }
            }

            return categories;
        }

        public List<CategoryModel> ReadToListOf_CategoryModel(string path)
        {
            var categoryModel = new List<CategoryModel>();
            // setup codepages
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var categoriesList = ReadCategories(path);

            foreach (var (category, subcategories) in categoriesList)
            {
                //Console.WriteLine(category);

                foreach (var sub in subcategories)
                {
                    //Console.WriteLine($"\t{sub}");
                    categoryModel.Add(new CategoryModel() { CategoryName = category, CheckBoxContent = new ObservableCollection<SubcategoryContentModel> { new SubcategoryContentModel { Content = sub, IsSelected = false } } });
                }
            }
            return categoryModel;
        }
    }
}