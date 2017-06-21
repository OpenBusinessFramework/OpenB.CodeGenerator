namespace OpenB.CodeGenerator.Core
{
    public class MemberDetails
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Cardinality Cardinality { get; set; }
    }

    public enum Cardinality
    {
        OneToOne,
        OneToMany
    }
}