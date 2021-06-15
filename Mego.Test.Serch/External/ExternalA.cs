namespace Mego.Test.Serch
{
    public class ExternalA : External
    {
        public ExternalA(string name) => Name = name;
        protected override string Name { get; }
    }
}

