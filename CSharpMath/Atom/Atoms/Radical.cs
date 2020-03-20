using System.Text;

namespace CSharpMath.Atom.Atoms {
  public class Radical: MathAtom, IMathListContainer2 {
    public Radical(MathList degree, MathList radicand) =>
      (Degree, Radicand) = (degree, radicand);
    public MathList Degree { get; }
    /// <summary>Whatever is under the square root sign</summary>
    public MathList Radicand { get; }
    MathList IMathListContainer2.InnerList1 => Degree;
    MathList IMathListContainer2.InnerList2 => Radicand;
    public new Radical Clone(bool finalize) => (Radical)base.Clone(finalize);
    protected override MathAtom CloneInside(bool finalize) =>
      new Radical(Degree.Clone(finalize), Radicand.Clone(finalize));
    public override bool ScriptsAllowed => true;
    public override string DebugString =>
      new StringBuilder(@"\sqrt")
      .AppendInBracketsOrNothing(Degree?.DebugString)
      .AppendInBracesOrLiteralNull(Radicand?.DebugString)
      .AppendDebugStringOfScripts(this).ToString();
    public override int GetHashCode() =>
      (base.GetHashCode(), Degree, Radicand).GetHashCode();
  }
}