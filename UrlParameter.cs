
namespace Rin.MyNet
{
    class UrlParameter
    {
        public string Val { get; private set; }
        public string[] Values { get; private set; }
        public string Key { get; private set; }

        bool IsValue = false;
        bool IsArray = false;

        public UrlParameter(string Key, string Val)
        {
            this.Key = Key;
            this.Val = Val;
            IsValue = true;
        }

        public UrlParameter(string Key, string[] Values)
        {
            this.Key = Key;
            this.Values = Values;
            IsArray = true;
        }

        public static implicit operator UrlParameter((string key, string val) p)
        {
            return new UrlParameter(p.key, p.val);
        }

        public static implicit operator UrlParameter((string key, string[] arr) p)
        {
            return new UrlParameter(p.key, p.arr);
        }

        public override string ToString()
        {
            if (IsValue)
                return this.Key + "=" + System.Web.HttpUtility.UrlEncode(this.Val);
            if (IsArray)
                return this.Key + "=" + System.Web.HttpUtility.UrlEncode(String.Join(",", this.Values));
            return null;
        }

        public static string Join(params UrlParameter[] param)
        {
            return "?" + string.Join("&", param.Select(x => x.ToString()));
        }
    }
}
