using ArxOne.MrAdvice.Advice;
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
        }
    }
}
