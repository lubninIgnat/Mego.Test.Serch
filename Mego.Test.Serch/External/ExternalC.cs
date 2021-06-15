namespace Mego.Test.Serch
{
    public class ExternalC : External
    {
        public ExternalC(string name) => Name = name;
        protected override string Name { get; }
    }
}

