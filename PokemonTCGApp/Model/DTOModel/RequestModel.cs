using Microsoft.AspNetCore.Http;

namespace PokemonTCGApp.Model.DTOModel
{
    public class VueTableList<T>
    {
        public int total { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
        public int last_page { get; set; }
        public int from { get; set; }
        public int to { get; set; }

        public List<T> data { get; set; }

        public VueTableList(List<T> list, int row, int page)
        {
            this.total = list.Count;
            this.per_page = row;
            this.current_page = page;
            this.last_page = Convert.ToInt32(Math.Ceiling((double)total / row));

            if (page >= 1) { page = page - 1; }

            this.from = page * row + 1;
            this.data = list.Skip(page * row).Take(row).ToList();
            this.to = from + this.data.Count - 1;
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

            this.total = list.Count;
            this.per_page = row;
            this.current_page = page;
            last_page = Convert.ToInt32(Math.Ceiling((double)total / row));

            if (page >= 1) { page = page - 1; }

            this.from = page * row + 1;
            this.data = list.Skip(page * row).Take(row).ToList();
            this.to = from + this.data.Count - 1;
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

            this.total = list.Count;
            this.per_page = row;
            this.current_page = page;
            last_page = Convert.ToInt32(Math.Ceiling((double)total / row));

            if (page >= 1) { page = page - 1; }

            this.from = page * row + 1;
            this.data = list.Skip(page * row).Take(row).ToList();
            this.to = from + this.data.Count - 1;
        }
    }

    public class RequestVueTable
    {
        public Params @params { get; set; }
    }

    public class Params
    {
        public string sort { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public Dictionary<string, object> filterQuery { get; set; }
    }

    public class  RequestSaveSet
    {
        public string? SeriesId { get; set; }

        public string? Name { get; set; }

        public string? Series { get; set; }

        public DateTime ReleaseTime { get; set; }

        public IFormFile? File { get; set; }
    }
}
