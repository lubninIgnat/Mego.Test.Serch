namespace Mego.Test.Serch
{
    public class ExternalB : External
    {
        public ExternalB(string name) => Name = name;
        protected override string Name { get; }
    }
}

