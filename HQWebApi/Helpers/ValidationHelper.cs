namespace HQWebApi.Helpers
{
    public class ValidationHelper
    {
        public static int GetInt(object obj)
        {
            var result = 0;
            int.TryParse(obj.ToString().Trim(), out result);

            return result;
        }

        public static long GetLong(object obj)
        {
            var result = 0L;
            long.TryParse(obj.ToString().Trim(), out result);

            return result;
        }

        public static string GetString(object obj)
        {
            return obj.ToString().Trim();
        }
    }
}