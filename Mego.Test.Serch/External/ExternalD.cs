namespace Mego.Test.Serch
{
    public class ExternalD : External
    {
        public ExternalD(string name) => Name = name;
        protected override string Name { get; }
    }
}

