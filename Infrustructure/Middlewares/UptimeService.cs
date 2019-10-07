using System.Diagnostics;

namespace AspNetCore_Settings.Infrustructure.Middlewares
{
    public class UptimeService
    {
        private Stopwatch _timer;

        public UptimeService()
        {
            _timer = Stopwatch.StartNew();
        }

        public long Uptime => _timer.ElapsedMilliseconds;
    }
}
