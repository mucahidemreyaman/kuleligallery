using ArxOne.MrAdvice.Advice;
using Microsoft.Identity.Client;
using Serilog;
using System.Diagnostics;

namespace Kuleli.Shop.Application.Behaviors
{
    public class PerformanceBehavior : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
         Stopwatch watch= new Stopwatch();

            //kronometreyi baslat
            watch.Start();

            context.Proceed();

            //kronometreyi durdur
            watch.Stop();

            var totalDuration = watch.Elapsed.TotalSeconds;

         Log.Information($"{context.TargetName} metodu {totalDuration}");
        }
    }
}
