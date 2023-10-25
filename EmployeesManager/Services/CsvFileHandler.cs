using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Services
{
    public class CsvFileHandler : FileHandler
    {
        public override async Task SaveFile<T>(List<T> collection, string path)
        {
            var content = await GenerateCsvFile<T>(collection);

            await File.WriteAllLinesAsync(path, content);
        }

        private async Task<IEnumerable<string>> GenerateCsvFile<T>(List<T> collection)
        {
            var stringBuilder = new StringBuilder();
            List<string> content = new List<string>();
            content.Add("sep=;");

            var headers = GetHeaders<T>()?.ToList();

            for (int i = 0; i < headers.Count; i++)
            {
                if (i == headers.Count - 1)
                {
                    stringBuilder.Append($"{headers[i]}");
                    break;
                }
                stringBuilder.Append($"{headers[i]};");
            }

            content.Add(stringBuilder.ToString());

            stringBuilder.Clear();

            content.AddRange(GetContent(collection));

            return content;
        }

        private IEnumerable<string> GetHeaders<T>()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public
                | BindingFlags.Static
                | BindingFlags.Instance)
                .Select(a => a.Name);

            return properties;
        }

        private IEnumerable<string> GetContent<T>(List<T> collection)
        {
            List<string> content = new List<string>();

            var properties = typeof(T).GetProperties(BindingFlags.Public
                | BindingFlags.Static
                | BindingFlags.Instance)
                .ToList();

            foreach (var item in collection)
            {
                string s = "";
                for (int i = 0; i < properties.Count; i++)
                {
                    if (i == properties.Count - 1)
                    {
                        s += $"{properties[i].GetValue(item)}";
                        break;
                    }

                    s += $"{properties[i].GetValue(item)};";
                }
                content.Add(s);
            }

            return content;
        }

    }
}
