using Elsa.Activities.Console;
using Elsa.Activities.Temporal;
using Elsa.Builders;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi1.Application;
public class HeartbeatWorkflow :IWorkflow
{
    private readonly IClock _clock;
    public HeartbeatWorkflow(IClock clock) => _clock = clock;

    public void Build(IWorkflowBuilder builder) =>
        builder
            .Timer(Duration.FromSeconds(10))
            .WriteLine(context => $"Heartbeat at {_clock.GetCurrentInstant()}");
}
