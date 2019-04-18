namespace CustomReport.Demo.FlexibleDimensions
{
    using Sitecore.Analytics.Aggregation;
    using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
    using Sitecore.XConnect.Collection.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OperatingSystemGroupResolver : IGroupResolver<OperatingSystemData>
    {
        public IEnumerable<VisitGroupMeasurement<OperatingSystemData>> MeasureGroupOccurrences(IInteractionAggregationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Interaction == null)
            {
                throw new ArgumentNullException(nameof(context.Interaction));
            }

            // Could use the IInteractionAggregationContext depening on your needs
            // to either get some interaction event (all inhereit from Sitecore.XConnect.Event) like for example
            // context.Interaction.Events.OfType<PageViewEvent>();
            // context.Interaction.Events.OfType<DownloadEvent>();
            // or interaction Facet like WebVisit, IPInfo or other

            // Could use DotPeek to check the events facets
            // All Events inherit from Sitecore.XConnect.Event.cs withing Sitecore.XConnect.dll
            // ConvertToXConnectInteractionProcessor.cs within Sitecore.Analytics.XConnect.dll will give insights about the facets

            var webVisitFacet = context.Interaction.WebVisit();
            if (webVisitFacet?.OperatingSystem == null)
            {
                return Enumerable.Empty<VisitGroupMeasurement<OperatingSystemData>>();
            }

            return new List<VisitGroupMeasurement<OperatingSystemData>>()
            {
                new VisitGroupMeasurement<OperatingSystemData>(
                    new VisitGroup(BuildGroupId(webVisitFacet.OperatingSystem)), // could implement JSON Serializer to take care. Check DefaultDeviceInformationSerializer within Sitecore.ExperienceAnalytics.Aggregation.dll 
                    new List<OperatingSystemData>() // could have multiple values in some scenarios, for example Downloaded Assets
                    {
                        webVisitFacet.OperatingSystem
                    })
            };
        }

        private string BuildGroupId(OperatingSystemData operatingSystem)
        {
            return $"{operatingSystem.Name} {operatingSystem.MajorVersion}.{operatingSystem.MinorVersion}";
        }
    }
}