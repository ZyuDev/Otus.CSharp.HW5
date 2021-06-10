using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Helpers
{
    public class CsvSerializer<T>
    {

        private StringBuilder _sb;
        private string _delimeter = "|";
        private bool _allowSetPrivateFields;

        private FieldInfo[] _fields;
        private PropertyInfo[] _properties;

        public CsvSerializer(bool allowSetPrivateFields)
        {
            _sb = new StringBuilder();
            _allowSetPrivateFields = allowSetPrivateFields;

            GetMembers(typeof(T));

        }

        public string SerializeObject(T objectToSerialize)
        {
            if (objectToSerialize == null)
            {
                return "";
            }

            _sb.Clear();

            AppendHeader();
            AppendDataRow(objectToSerialize);

            return _sb.ToString();

        }

        public string SerializeCollection(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                return "";
            }

            _sb.Clear();

            AppendHeader();

            foreach (var objectToSerialize in collection)
            {
                AppendDataRow(objectToSerialize);
            }

            return _sb.ToString();
        }

        public T DeserializeObject(string csvString)
        {
            if (string.IsNullOrEmpty(csvString))
            {
                return default(T);
            }

            var stringArray = csvString.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (stringArray.Length < 2)
            {
                return default(T);
            }

            var namesRow = stringArray[0];
            var names = namesRow.Split(_delimeter, StringSplitOptions.RemoveEmptyEntries);

            var valuesRow = stringArray[1];
            var values = valuesRow.Split(_delimeter, StringSplitOptions.RemoveEmptyEntries);

            var resultObject = DeserializeObject(names, values);

            return resultObject;
        }

        public IList<T> DeserializeCollection(string csvString)
        {
            var collection = new List<T>();

            if (string.IsNullOrEmpty(csvString))
            {
                return collection;
            }

            var stringArray = csvString.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (stringArray.Length < 2)
            {
                return collection;
            }

            var namesRow = stringArray[0];
            var names = namesRow.Split(_delimeter, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 1; i < stringArray.Length; i++)
            {
                var valuesRow = stringArray[i];
                var values = valuesRow.Split(_delimeter, StringSplitOptions.RemoveEmptyEntries);
                var resultObject = DeserializeObject(names, values);

                collection.Add(resultObject);
            }

            return collection;
        }

        private T DeserializeObject(IList<string> names, IList<string> values)
        {

            T resultObject = default(T);


            resultObject = (T)Activator.CreateInstance(typeof(T));

            for (var i = 0; i < names.Count; i++)
            {
                var name = names[i];
                var valueStr = values[i];

                var fld = _fields.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (fld != null)
                {
                    var currentVal = ValueParser.Parse(valueStr, fld.FieldType);
                    fld.SetValue(resultObject, currentVal);
                    continue;
                }

                var prop = _properties.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (prop != null)
                {
                    var currentVal = ValueParser.Parse(valueStr, prop.PropertyType);
                    prop.SetValue(resultObject, currentVal);

                }

            }

            return resultObject;
        }

        private void GetMembers(Type objectType)
        {
            if (_allowSetPrivateFields)
            {
                _fields = objectType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            }
            else
            {
                _fields = objectType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            }
            _properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        }

        private void AppendDataRow(T objectToSerialize)
        {

            var n = 1;
            foreach (var fld in _fields)
            {
                if (n > 1)
                {
                    _sb.Append(_delimeter);
                }

                var val = fld.GetValue(objectToSerialize);
                var valStr = val?.ToString() ?? "";

                _sb.Append(valStr);

                n++;


            }

            foreach (var prop in _properties)
            {
                var val = prop.GetValue(objectToSerialize);

                if (n > 1)
                {
                    _sb.Append(_delimeter);
                }

                var valStr = val?.ToString() ?? "";
                _sb.Append(valStr);

                n++;
            }
            _sb.Append(Environment.NewLine);

        }

        private void AppendHeader()
        {

            var currentPosition = AppendCollectionToHeader(_fields, 1);
            AppendCollectionToHeader(_properties, currentPosition);
            _sb.Append(Environment.NewLine);

        }

        private int AppendCollectionToHeader(MemberInfo[] collection, int currentNumber)
        {
            var n = currentNumber;
            foreach (var member in collection)
            {
                if (n > 1)
                {
                    _sb.Append(_delimeter);
                }
                _sb.Append(member.Name);
                n++;
            }

            return n;
        }
    }
}
