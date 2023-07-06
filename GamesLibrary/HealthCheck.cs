using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GamesLibrary.HealthCheck;

public class GamesLibraryHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
      HealthCheckContext context,
      CancellationToken cancellationToken = default(CancellationToken))
    {
        var healthCheckResultHealthy = true;

        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (healthCheckResultHealthy)
        {
            return Task.FromResult(
              HealthCheckResult.Healthy("A healthy result."));
        }

        return Task.FromResult(
          HealthCheckResult.Unhealthy("An unhealthy result."));
    }
}