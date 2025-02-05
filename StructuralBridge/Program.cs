using RR.DesignPattern.Structural.Bridge;

var mustang = new Mustang(new EngineV8());
var maverick = new Maverick(new EngineV6());
var tracker = new Tracker(new EngineV4());

mustang.Start();
mustang.Drive();
mustang.Stop();
maverick.Start();
maverick.Drive();
maverick.Stop();
tracker.Start();
tracker.Drive();
tracker.Stop();

namespace RR.DesignPattern.Structural.Bridge
{
    abstract class Vehicle(IEngine engine)
    {
        protected IEngine engine = engine;

        public virtual void Drive()
        {
            engine.IncreasePower();
            engine.DecreasePower();
        }
        public abstract void Start();
        public abstract void Stop();
    }

    interface IEngine
    {
        void Start();
        void Stop();
        void IncreasePower();
        void DecreasePower();
    }

    class EngineV8 : IEngine
    {
        public void Start() => Console.WriteLine("Starting V8 engine");  
        public void Stop() => Console.WriteLine("Stopping V8 engine");
        public void IncreasePower() => Console.WriteLine("Increasing power of V8 engine");
        public void DecreasePower() => Console.WriteLine("Decreasing power of V8 engine");
    }

    class EngineV6 : IEngine
    {
        public void Start() => Console.WriteLine("Starting V6 engine");
        public void Stop() => Console.WriteLine("Stopping V6 engine");
        public void IncreasePower() => Console.WriteLine("Increasing power of V6 engine");
        public void DecreasePower() => Console.WriteLine("Decreasing power of V6 engine");
    }

    class EngineV4 : IEngine
    {
        public void Start() => Console.WriteLine("Starting V4 engine");
        public void Stop() => Console.WriteLine("Stopping V4 engine");
        public void IncreasePower() => Console.WriteLine("Increasing power of V4 engine");
        public void DecreasePower() => Console.WriteLine("Decreasing power of V4 engine");
    }

    class Mustang(IEngine engine) : Vehicle(engine)
    {
        public override void Drive()
        {
            Console.WriteLine("Mustang is driving");
            base.Drive();
        }
        public override void Start()
        {
            engine.Start();
        }
        public override void Stop()
        {
            engine.Stop();
        }
    }

    class Maverick(IEngine engine) : Vehicle(engine)
    {
        public override void Drive()
        {
            Console.WriteLine("Maverick is driving");
            base.Drive();
        }
        public override void Start()
        {
            engine.Start();
        }
        public override void Stop()
        {
            engine.Stop();
        }
    }

    class Tracker(IEngine engine) : Vehicle(engine)
    {
        public override void Drive()
        {
            Console.WriteLine("Tracker is driving");
            base.Drive();
        }
        public override void Start()
        {
            engine.Start();
        }
        public override void Stop()
        {
            engine.Stop();
        }
    }
}