namespace InsuranceAdvisor.Domain.Helpers
{
    internal static class EnumHelper
    {
        public static IEnumerable<T> GetEnumList<T>()
        {
            if (!typeof(T).IsEnum)
                return Array.Empty<T>();

            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
