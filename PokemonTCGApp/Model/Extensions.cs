using System.ComponentModel;
using System.Reflection;

namespace PokemonTCGApp.Model
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T value, Type? type = null)
        {
            if (type is null)
            {
                type = typeof(T);
            }
            if (!type.IsEnum || !Enum.TryParse(type, value.ToString(), out _))
            {
                return value.ToString();
            }
            var name = type.GetEnumName(value);
            if (name is null)
            {
                return value.ToString();
            }
            var field = type.GetField(name);
            var attr = field is null ? default(DescriptionAttribute) : (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attr is null ? value.ToString() : attr.Description;
        }

        public class VueTableList<T>
        {
            public int Total { get; set; }
            public int Per_page { get; set; }
            public int Current_page { get; set; }
            public int Last_page { get; set; }
            public int From { get; set; }
            public int To { get; set; }

            public List<T> Data { get; set; }

            public VueTableList(List<T> list, int row, int page)
            {
                this.Total = list.Count;
                this.Per_page = row;
                this.Current_page = page;
                this.Last_page = Convert.ToInt32(Math.Ceiling((double)Total / row));

                if (page >= 1) { page = page - 1; }

                this.From = page * row + 1;
                this.Data = list.Skip(page * row).Take(row).ToList();
                this.To = From + this.Data.Count - 1;
            }

            public VueTableList(List<T> list, string sortPara, int row = 10, int page = 1)
            {
                if (row <= 0) { row = 10; }

                var dataClass = typeof(T);

                if (!string.IsNullOrEmpty(sortPara))
                {
                    var dItem = sortPara.Split('|');

                    if (dataClass.GetProperty(dItem[0]) == null)
                    {
                        //Error
                    }

                    if (dItem[1] == "asc")
                    {
                        list = list.OrderBy(c => c?.GetType().GetProperty(dItem[0])?.GetValue(c)).ToList();
                    }
                    else if (dItem[1] == "desc")
                    {
                        list = list.OrderByDescending(c => c?.GetType().GetProperty(dItem[0])?.GetValue(c)).ToList();
                    }
                }

                this.Total = list.Count;
                this.Per_page = row;
                this.Current_page = page;
                Last_page = Convert.ToInt32(Math.Ceiling((double)Total / row));

                if (page >= 1) { page = page - 1; }

                this.From = page * row + 1;
                this.Data = list.Skip(page * row).Take(row).ToList();
                this.To = From + this.Data.Count - 1;
            }

            public VueTableList(List<T> list, string sortPara, Dictionary<string, string> filterPara, int row = 10, int page = 1)
            {
                if (row <= 0) { row = 10; }

                var dataClass = typeof(T);

                if (filterPara.Count > 0)
                {
                    foreach (var o in filterPara)
                    {
                        if (string.IsNullOrEmpty(o.Value)) continue;
                        var keep = o.Key;
                        if (o.Key.Contains("_Less") || o.Key.Contains("_Greater"))
                        {
                            keep = o.Key.Replace("_Less", "|").Replace("_Greater", "|");
                        }
                        var item = keep.Split('|');
                        var value = o.Value;

                        var memberInfo = dataClass.GetProperty(item[0]);

                        if (memberInfo != null)
                        {
                            Type propertyType = memberInfo.PropertyType;
                            TypeCode typeCode = Type.GetTypeCode(propertyType);
                            switch (typeCode)
                            {
                                case TypeCode.Boolean:
                                    list = list.Where(c => (bool)c.GetType().GetProperty(item[0]).GetValue(c) == bool.Parse(value)).ToList();
                                    break;
                                case TypeCode.String:
                                    list = list.Where(c => (string)c.GetType().GetProperty(item[0]).GetValue(c) == value).ToList();
                                    break;
                                case TypeCode.Int32:
                                    if (item.Length > 1)
                                    {
                                        if (item[1] == "Greater")
                                        {
                                            list = list.Where(c => (int)c.GetType().GetProperty(item[0]).GetValue(c) >= int.Parse(value)).ToList();
                                        }
                                        else if (item[1] == "Less")
                                        {
                                            list = list.Where(c => (int)c.GetType().GetProperty(item[0]).GetValue(c) >= int.Parse(value)).ToList();
                                        }
                                    }
                                    else
                                    {
                                        list = list.Where(c => (int)c.GetType().GetProperty(item[0]).GetValue(c) == int.Parse(value)).ToList();
                                    }
                                    break;
                                case TypeCode.Decimal:
                                    if (item.Length > 1)
                                    {
                                        if (item[1] == "Greater")
                                        {
                                            list = list.Where(c => (decimal)c.GetType().GetProperty(item[0]).GetValue(c) >= decimal.Parse(value)).ToList();
                                        }
                                        else if (item[1] == "Less")
                                        {
                                            list = list.Where(c => (decimal)c.GetType().GetProperty(item[0]).GetValue(c) <= decimal.Parse(value)).ToList();
                                        }
                                    }
                                    else
                                    {
                                        list = list.Where(c => (decimal)c.GetType().GetProperty(item[0]).GetValue(c) == decimal.Parse(value)).ToList();
                                    }
                                    break;
                                case TypeCode.DateTime:
                                    if (item.Length > 1)
                                    {
                                        if (item[1] == "Greater")
                                        {
                                            list = list.Where(c => ((DateTime)c.GetType().GetProperty(item[0]).GetValue(c)) >= DateTime.Parse(value)).ToList();
                                        }
                                        else if (item[1] == "Less")
                                        {
                                            list = list.Where(c => ((DateTime)c.GetType().GetProperty(item[0]).GetValue(c)) <= DateTime.Parse(value)).ToList();
                                        }
                                    }
                                    else
                                    {
                                        list = list.Where(c => ((DateTime)c.GetType().GetProperty(item[0]).GetValue(c)) == DateTime.Parse(value)).ToList();
                                    }
                                    break;
                                default: break;
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(sortPara))
                {
                    var dItem = sortPara.Split('|');

                    if (dataClass.GetProperty(dItem[0]) == null)
                    {
                        //Error
                    }

                    if (dItem[1] == "asc")
                    {
                        list = list.OrderBy(c => c.GetType().GetProperty(dItem[0]).GetValue(c)).ToList();
                    }
                    else if (dItem[1] == "desc")
                    {
                        list = list.OrderByDescending(c => c.GetType().GetProperty(dItem[0]).GetValue(c)).ToList();
                    }
                }

                this.Total = list.Count;
                this.Per_page = row;
                this.Current_page = page;
                Last_page = Convert.ToInt32(Math.Ceiling((double)Total / row));

                if (page >= 1) { page = page - 1; }

                this.From = page * row + 1;
                this.Data = list.Skip(page * row).Take(row).ToList();
                this.To = From + this.Data.Count - 1;
            }
        }
    }
}
