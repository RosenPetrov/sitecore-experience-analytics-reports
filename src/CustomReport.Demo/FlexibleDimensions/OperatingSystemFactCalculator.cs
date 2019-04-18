namespace CustomReport.Demo.FlexibleDimensions
{
    using Sitecore.Analytics.Aggregation;
    using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.FactCalculation;
    using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
    using Sitecore.XConnect.Collection.Model;

    public class OperatingSystemFactCalculator : IFactCalculator<OperatingSystemMetrics, OperatingSystemData>
    {
        public OperatingSystemMetrics CalculateFactsForGroup(VisitGroupMeasurement<OperatingSystemData> groupMeasurement, IInteractionAggregationContext context)
        {
            return new OperatingSystemMetrics
            {
                Visits = 1

                // Depending on our Metric we could use the context to Calculate some other values
                // (example) instance.Value = context.Interaction.EngagementValue;
                // (example) instance.Count = groupMeasurement.Occurrences.Count<DownloadEvent>();
                // (example) instance.Conversions = context.Interaction.Events.OfType<Goal>().ToList<Goal>();
            };
        }
    }
}