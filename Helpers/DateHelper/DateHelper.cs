using System;

namespace Helpers.DateHelper {
    public static class DateHelper {
        private static Random gen = new();
        public static DateTime RandomDay() {
            DateTime start = new(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
