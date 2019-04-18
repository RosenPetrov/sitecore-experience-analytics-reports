namespace CustomReport.Demo.FlexibleDimensions
{
    using Sitecore.Analytics.Aggregation.Data.Model;
    using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Metrics;
    using System;

    public class OperatingSystemMetrics : DictionaryValue, IMergeableMetric<OperatingSystemMetrics> // All implement this interface and inherit from this base class
    {
        public int Visits { get; set; }

        public T MergeWith<T>(T other) where T : OperatingSystemMetrics, new()
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            T instance = Activator.CreateInstance<T>();
            instance.Visits = Visits + other.Visits;
            return instance;
        }
    }
}